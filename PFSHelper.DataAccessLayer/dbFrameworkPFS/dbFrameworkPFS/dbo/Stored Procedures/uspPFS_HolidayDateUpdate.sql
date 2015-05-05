/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayDateUpdate
	Desc    		:	This store procedure is use to update PFS_HOLIDAY_DATE
	Create Date 	:	03 Oct 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayDateUpdate]
(
	@iHolidayDateID INT,
	@iHolidayID INT,
	@dtHolidayDate DATETIME
)
AS
BEGIN
	UPDATE PFS_HOLIDAY_DATE SET
		pfs_holiday_id = @iHolidayID,
		holiday_date = @dtHolidayDate
	WHERE
      	pfs_holiday_date_id = @iHolidayDateID

	SELECT @@ERROR
END
