/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayDateList
	Desc    		:	This store procedure is use to get list of PFS_HOLIDAY_DATE
	Create Date 	:	03 Oct 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayDateList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iHolidayID INT = NULL,
	@dtHolidayDateFrom DATETIME = NULL,
	@dtHolidayDateTo DATETIME = NULL
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
		(@iHolidayID IS NULL OR phd0.pfs_holiday_id = @iHolidayID) AND
		(@dtHolidayDateFrom IS NULL OR CONVERT(VARCHAR, phd0.holiday_date, 12) >= CONVERT(VARCHAR, @dtHolidayDateFrom, 12)) AND
		(@dtHolidayDateTo IS NULL OR CONVERT(VARCHAR, phd0.holiday_date, 12) <= CONVERT(VARCHAR, @dtHolidayDateTo, 12)) AND
		(@sKeyWords IS NULL)
END
