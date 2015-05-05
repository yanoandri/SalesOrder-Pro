/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_HolidayDateCheckToDeleteExistingHoliday]
	Desc    		:	This store procedure is use to delete PFS_HOLIDAY_DATE
	Create Date 	:	03 Oct 2012		- Created By  : slimanto
	Modified Date 	:	03 Oct 2012		- Modified By : slimanto
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayDateCheckToDeleteExistingHoliday]
(
	@iHolidayID INT
)
AS
BEGIN
	IF EXISTS(SELECT * FROM dbo.PFS_HOLIDAY_DATE WHERE pfs_holiday_id = @iHolidayID)
	BEGIN 
		DELETE FROM dbo.PFS_HOLIDAY_DATE
		WHERE pfs_holiday_id = @iHolidayID
	END 
END
