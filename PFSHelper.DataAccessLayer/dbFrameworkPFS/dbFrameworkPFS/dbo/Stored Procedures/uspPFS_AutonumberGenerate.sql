/*****************************************************************************
  Copyright (c) 2011, PT. Profescipta Wahanatehnik. All Rights Reserved.
 
  This software, all associated documentation, and all copies
  are CONFIDENTIAL INFORMATION of PT. Profescipta Wahanatehnik.
 
 
  DESCRIPTION
	Name    	:   uspPFS_AutonumberGenerate
	Desc    	:	This procedure is used to generate autonumber.
	Input   	: 	@sObjectCode, @dtBaseDate
	Output  	:	@sNewCode
	Comments	:	
	Status  	: 	
	Sample Data :	DECLARE @sNewCode VARCHAR(50)
					EXECUTE uspPFS_AutonumberGenerate 'TEST_SEPEDA', 0, '10 January 2005', @sNewCode OUTPUT
					SELECT @sNewCode
******************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_AutonumberGenerate] 
(
	@sObjectCode AS VARCHAR(50), 
	@iRefID AS INT,
	@dtBaseDate AS DATETIME,
	@sQuarterCode AS VARCHAR(2),
	@sNewCode AS VARCHAR(50) OUTPUT
)
AS
DECLARE @iErrorFlag INT
SET @iErrorFlag = 0
--BEGIN TRANSACTION	
/**********************************************************************************
	1. This part get pattern information
***********************************************************************************/
DECLARE @iPatternID INT, @iFormatCounter TINYINT, @iFormatCharacter TINYINT, @sResetType AS VARCHAR(4)
DECLARE @sFormatPattern VARCHAR(50), @sFormatYear VARCHAR(4), @sFormatMonth VARCHAR(4), @sFormatDay VARCHAR(2)
SELECT 
	@iPatternID = PFS_autonumber_pattern_id, 
	@sFormatPattern = format_pattern, 
	@sFormatYear= format_year, 
	@sFormatMonth = format_month, 
	@sFormatDay = format_day, 
	@iFormatCounter = format_counter, 
	@iFormatCharacter = format_character,
	@sResetType = reset_type
FROM PFS_autonumber_pattern
WHERE PFS_autonumber_object_id = 
	(SELECT PFS_autonumber_object_id FROM PFS_AUTONUMBER_OBJECT WHERE [object_code] = @sObjectCode)
	AND reference_id = @iRefID
/**********************************************************************************
	2. This part generate new autonumber
***********************************************************************************/
IF @iPatternID IS NOT NULL
BEGIN
	-- 2a. Get based period --
	DECLARE @iBaseYear SMALLINT, @iBaseMonth TINYINT, @iBaseDay TINYINT
	SET @iBaseYear = YEAR(@dtBaseDate)
	SET @iBaseMonth = MONTH(@dtBaseDate)
	SET @iBaseDay = DAY(@dtBaseDate)
	
	-- 2b. Get latest counter --
	DECLARE @iCounterID INT, @iLatestCounter INT, @sLatestCharacter VARCHAR(5)
	SELECT @iCounterID = PFS_autonumber_counter_id, @iLatestCounter = latest_counter, @sLatestCharacter = latest_character
	FROM PFS_autonumber_counter
	WHERE PFS_autonumber_pattern_id = @iPatternID
		AND (CHARINDEX('Y', @sResetType) = 0 OR period_year = @iBaseYear)
		AND (CHARINDEX('M', @sResetType) = 0 OR period_month = @iBaseMonth)
		AND (CHARINDEX('D', @sResetType) = 0 OR period_day = @iBaseDay)
	-- 2c. Increase latest counter --
	IF @iCounterID IS NOT NULL
	BEGIN
		SET @iLatestCounter = @iLatestCounter + 1
		IF CHARINDEX('A', @sResetType) <> 0 
		BEGIN
			-- Calculate maximum of counter --
			DECLARE @iMaxCounter INT, @sMaxCounter VARCHAR(10)
			SET @iMaxCounter = 0
			SET @sMaxCounter = ''
			WHILE @iMaxCounter < @iFormatCounter
			BEGIN
				SET @iMaxCounter = @iMaxCounter + 1
				SET @sMaxCounter = @sMaxCounter + '9'
			END
			SET @iMaxCounter = CAST(@sMaxCounter AS INT)
			IF @iLatestCounter > @iMaxCounter
			BEGIN
				SET @iLatestCounter = 1
				SET @sLatestCharacter = dbo.fPFS_IncreaseAlphabethCounter(@sLatestCharacter)
			END
		END
		UPDATE PFS_autonumber_counter SET 
			latest_counter = @iLatestCounter,
			latest_character = @sLatestCharacter
		WHERE PFS_autonumber_counter_id = @iCounterID
	END
	ELSE
	BEGIN
		SET @iLatestCounter = 1
		SET @sLatestCharacter = ''
		IF CHARINDEX('A', @sResetType) <> 0
		BEGIN
			DECLARE @iCharLength INT
			SET @iCharLength = 0
			WHILE @iCharLength < @iFormatCharacter
			BEGIN
				SET @iCharLength = @iCharLength + 1
				SET @sLatestCharacter = @sLatestCharacter + 'A'
			END
		END
		INSERT INTO PFS_autonumber_counter (PFS_autonumber_pattern_id, period_year, period_month, period_day, latest_counter, latest_character)
		VALUES (@iPatternID, 
			(CASE WHEN CHARINDEX('Y', @sResetType) = 0 THEN 0 ELSE @iBaseYear END), 
			(CASE WHEN CHARINDEX('M', @sResetType) = 0 THEN 0 ELSE @iBaseMonth END),
			(CASE WHEN CHARINDEX('D', @sResetType) = 0 THEN 0 ELSE @iBaseDay END),
			@iLatestCounter, @sLatestCharacter)
	END
	-- 2d. Fit year pattern --
	DECLARE @sYear VARCHAR(4)
	SET @sYear = 
		CASE @sFormatYear 
			WHEN 'YY' THEN RIGHT(CAST(@iBaseYear AS VARCHAR), 2) 
			ELSE CAST(@iBaseYear AS VARCHAR)
		END
	
	-- 2e. Fit month pattern --
	DECLARE @sMonth VARCHAR(9)
	CREATE TABLE #month(month_id TINYINT, abbr_mm VARCHAR(2), abbr_mmm VARCHAR(3), abbr_mmmm VARCHAR(9))
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(1, '01', 'JAN', 'JANUARI')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(2, '02', 'FEB', 'FEBRUARI')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(3, '03', 'MAR', 'MARET')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(4, '04', 'APR', 'APRIL')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(5, '05', 'MEI', 'MEY')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(6, '06', 'JUN', 'JUNI')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(7, '07', 'JUL', 'JULI')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(8, '08', 'AGU', 'AGUSTUS')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(9, '09', 'SEP', 'SEPTEMBER')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(10, '10', 'OKT', 'OKTOBER')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(11, '11', 'NOV', 'NOVEMBER')
	INSERT INTO #month(month_id, abbr_mm, abbr_mmm, abbr_mmmm) VALUES(12, '12', 'DES', 'DESEMBER')
	SET @sMonth =
		CASE @sFormatMonth
			WHEN 'MMM' THEN (SELECT abbr_mmm FROM #month WHERE month_id = @iBaseMonth)
			WHEN 'MMMM' THEN (SELECT abbr_mmmm FROM #month WHERE month_id = @iBaseMonth)
			ELSE (SELECT abbr_mm FROM #month WHERE month_id = @iBaseMonth)
		END
	DROP TABLE #month
	
	-- 2f. Fit day pattern --
	DECLARE @sDay VARCHAR(2)
	SET @sDay = 
		CASE @sFormatDay
			WHEN 'D' THEN CAST(@iBaseDay AS VARCHAR(2))
			ELSE dbo.fPFS_FormatIntoDigit(2, CAST(@iBaseDay AS VARCHAR(2)))
		END
	-- 2g. Fit counter patten --
	DECLARE @sCounter VARCHAR(10)
	SET @sCounter = dbo.fPFS_FormatIntoDigit(@iFormatCounter, CAST(@iLatestCounter AS VARCHAR(10)))
	-- 2h. Replace pattern --
	SET @sNewCode = @sFormatPattern
	SET @sNewCode = REPLACE(@sNewCode, '[Y]', @sYear)
	SET @sNewCode = REPLACE(@sNewCode, '[M]', @sMonth)
	SET @sNewCode = REPLACE(@sNewCode, '[D]', @sDay)
	SET @sNewCode = REPLACE(@sNewCode, '[A]', @sLatestCharacter)
	SET @sNewCode = REPLACE(@sNewCode, '[Q]', @sQuarterCode)
	SET @sNewCode = REPLACE(@sNewCode, '[#]', @sCounter)
END
ELSE
	SET @sNewCode = 'ERROR : NO PATTERN FOUND'
/**********************************************************************************
	3. Commiting Transaction if all goes well
***********************************************************************************/
IF @@ERROR <> 0 AND @iErrorFlag=0
 	SET @iErrorFlag=@@ERROR		
--IF @iErrorFlag = 0 
--	COMMIT TRANSACTION
--ELSE
--	ROLLBACK TRANSACTION
