/*****************************************************************************
  Copyright (c) 2012,PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    	:	[fPFS_CountBussinessDay]
	Desc    	:	This  Function is Used to count Bussiness Aging Day (Turn Around Table)
	Input   	:   @dtStartDate, @dtEndDate
	Output  	:   @iBussinessDay
	Comments	:
	Sample Data :   SELECT dbo.[fPFS_CountBussinessDay]('2014-02-01','2014-02-10')
	Author		:	Muh Zulcham Pr
***********************************************************************************************************************/
CREATE FUNCTION [dbo].[fPFS_CountBussinessDay] 
(
	@dtStartDate DATETIME,
	@dtEndDate DATETIME
)
RETURNS INT
AS
BEGIN


DECLARE @iBussinessDay INT

SELECT @iBussinessDay =
   (DATEDIFF(dd, @dtStartDate, @dtEndDate) + 1)
  -(DATEDIFF(wk, @dtStartDate, @dtEndDate) * 2)
  -(CASE WHEN DATENAME(dw, @dtStartDate) = 'Sunday' THEN 1 ELSE 0 END)
  -(CASE WHEN DATENAME(dw, @dtEndDate) = 'Sunday' THEN 1 ELSE 0 END)
  -(CASE WHEN DATENAME(dw, @dtStartDate) = 'Saturday' THEN 1 ELSE 0 END)
  -(CASE WHEN DATENAME(dw, @dtEndDate) = 'Saturday' THEN 1 ELSE 0 END)
  -(SELECT COUNT(HOLIDAY_DATE) FROM dbo.PFS_HOLIDAY_DATE where @dtStartDate <= HOLIDAY_DATE AND HOLIDAY_DATE <= @dtEndDate)

--SELECT @iBussinessDay=(COUNT(1)) 
--FROM (
--		SELECT		DATEADD(day,z.num , @dtStartDate) AS DATE_COLLECTION
--		FROM		
--		(
--					SELECT		b10.i + b9.i + b8.i + b7.i + b6.i + b5.i + b4.i + b3.i + b2.i + b1.i + b0.i num 
--					FROM		(SELECT 0 i UNION ALL SELECT 1) b0
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 2) b1
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 4) b2
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 8) b3
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 16) b4
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 32) b5
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 64) b6
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 128) b7
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 256) b8
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 512) b9
--					CROSS JOIN	(SELECT 0 i UNION ALL SELECT 1024) b10
--				) z
--		WHERE		z.num  <= DATEDIFF(day, @dtStartDate, @dtEndDate)
--		) x	
--		WHERE x.DATE_COLLECTION NOT IN (SELECT DISTINCT(HOLIDAY_DATE) FROM dbo.PFS_HOLIDAY_DATE)
--		AND DATENAME(weekday,x.DATE_COLLECTION) NOT IN ('Saturday','Sunday')

IF (@iBussinessDay -1) < 0
BEGIN
  SET @iBussinessDay=1
END

RETURN @iBussinessDay 
	
END
