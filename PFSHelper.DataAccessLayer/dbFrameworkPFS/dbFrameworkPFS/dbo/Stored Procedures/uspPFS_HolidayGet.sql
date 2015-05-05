/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayGet
	Desc    		:	This store procedure is use to get PFS_HOLIDAY by id
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayGet]
(
	@iHolidayID INT = NULL
)
AS
BEGIN

	SELECT
			ph0.pfs_holiday_id,
			ph0.pfs_holiday_startdate,
			ph0.pfs_holiday_enddate,
			ph0.pfs_holiday_desc,
			ph0.recurrance,
			ph0.recurrance_parent_id,
			ph0.is_need_approval,
			ph0.create_by_user_id,
			ph0.create_date,
			ph0.update_by_user_id,
			ph0.update_date
		FROM
			pfs_holiday ph0 WITH (NOLOCK)
		WHERE
			(@iHolidayID IS NULL OR ph0.pfs_holiday_id = @iHolidayID) 
END
