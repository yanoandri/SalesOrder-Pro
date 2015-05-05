/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayDateGetByHolidayDate
	Desc    		:	This store procedure is use to get PFS_HOLIDAY_DATE by holiday date
	Create Date 	:	29 Nov 2013		- Created By  : slimanto
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayDateGetByHolidayDate]
(
	@dtHolidayDate datetime,
	@iHolidayID INT = null
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
		phd0.holiday_date = CONVERT(date, @dtHolidayDate) AND
		(@iHolidayID IS NULL OR phd0.pfs_holiday_id <> @iHolidayID)
END
