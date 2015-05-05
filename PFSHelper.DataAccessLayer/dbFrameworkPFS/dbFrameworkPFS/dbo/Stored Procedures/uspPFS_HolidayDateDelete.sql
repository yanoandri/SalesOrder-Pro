/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayDateDelete
	Desc    		:	This store procedure is use to delete PFS_HOLIDAY_DATE
	Create Date 	:	03 Oct 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayDateDelete]
(
	@iHolidayDateID INT
)
AS
BEGIN
	DELETE PFS_HOLIDAY_DATE
    WHERE PFS_HOLIDAY_DATE_ID = @iHolidayDateID
END
