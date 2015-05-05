/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayDateAdd
	Desc    		:	This store procedure is use to add PFS_HOLIDAY_DATE
	Create Date 	:	03 Oct 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayDateAdd]
(
	@iHolidayID INT,
	@dtHolidayDate DATETIME
)
AS
BEGIN
	DECLARE @iHolidayDateID INT
    
	INSERT INTO PFS_HOLIDAY_DATE 
    ( 	
		pfs_holiday_id,
		holiday_date
	)
	VALUES
	(
		@iHolidayID,
		@dtHolidayDate
	)
    
	SET @iHolidayDateID = ISNULL(@@IDENTITY, 0)
	SELECT @iHolidayDateID
END
