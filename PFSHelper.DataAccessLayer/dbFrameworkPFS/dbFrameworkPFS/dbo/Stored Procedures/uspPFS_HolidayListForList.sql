/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayListForList
	Desc    		:	This store procedure is use to get list of PFS_HOLIDAY by id
	Create Date 	:	2 Jan 2012		- Created By  : kprasetyo
	Modified Date 	:	2 Jan 2012		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
						uspPFS_HolidayListForList null,'2011-11-28','2011-11-29',null,null,null
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayListForList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@dtHolidayStartdate DATETIME = NULL,
	@dtHolidayEnddate DATETIME = NULL,
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
			(@sKeyWords IS NULL OR
			ph0.pfs_holiday_desc LIKE '%' + @sKeyWords + '%') AND
			(@dtHolidayStartdate IS NULL OR @dtHolidayStartdate BETWEEN ph0.PFS_HOLIDAY_STARTDATE AND ph0.PFS_HOLIDAY_ENDDATE ) AND
			(@dtHolidayEnddate IS NULL OR @dtHolidayEnddate BETWEEN ph0.PFS_HOLIDAY_STARTDATE AND ph0.PFS_HOLIDAY_ENDDATE )
			AND
			(@iHolidayID IS NULL OR ph0.pfs_holiday_id = @iHolidayID)
	
END
