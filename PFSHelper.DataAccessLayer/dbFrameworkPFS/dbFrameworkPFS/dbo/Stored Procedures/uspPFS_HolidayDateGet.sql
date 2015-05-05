/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayDateGet
	Desc    		:	This store procedure is use to get PFS_HOLIDAY_DATE by id
	Create Date 	:	03 Oct 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayDateGet]
(
	@iHolidayDateID INT
)
AS
BEGIN
	SELECT
		phd0.pfs_holiday_date_id,
		phd0.pfs_holiday_id,
		phd0.holiday_date
	FROM
		pfs_holiday_date phd0 WITH (NOLOCK),
		pfs_holiday ph1 WITH (NOLOCK)
	WHERE
		phd0.pfs_holiday_id = ph1.pfs_holiday_id AND
		phd0.pfs_holiday_date_id = @iHolidayDateID
END
