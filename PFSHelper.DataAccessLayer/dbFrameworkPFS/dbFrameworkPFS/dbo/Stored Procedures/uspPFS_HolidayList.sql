/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayGet
	Desc    		:	This store procedure is use to get list of PFS_HOLIDAY by id
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@dtHolidayStartdateFrom DATETIME = NULL,
	@dtHolidayStartdateTo DATETIME = NULL,
	@dtHolidayEnddateFrom DATETIME = NULL,
	@dtHolidayEnddateTo DATETIME = NULL,
	@iRecurranceParentID INT = NULL ,
	@bIsNeedApproval BIT = NULL ,
	@iCreateByUserID INT = NULL ,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL ,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL
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
			(
				@dtHolidayStartdateFrom IS NULL OR @dtHolidayStartdateTo IS NULL OR 
				FLOOR(CAST(ph0.pfs_holiday_startdate AS FLOAT)) BETWEEN FLOOR(CAST(@dtHolidayStartdateFrom AS FLOAT)) AND FLOOR(CAST(@dtHolidayStartdateTo AS FLOAT))
			) 	AND			
			(
				@dtHolidayEnddateFrom IS NULL OR @dtHolidayEnddateTo IS NULL OR 
				FLOOR(CAST(ph0.pfs_holiday_enddate AS FLOAT)) BETWEEN FLOOR(CAST(@dtHolidayEnddateFrom AS FLOAT)) AND FLOOR(CAST(@dtHolidayEnddateTo AS FLOAT))
			) 	AND			
			(@iRecurranceParentID IS NULL OR ph0.recurrance_parent_id = @iRecurranceParentID) AND
			(@bIsNeedApproval IS NULL OR ph0.is_need_approval = @bIsNeedApproval) AND
			(@iCreateByUserID IS NULL OR ph0.create_by_user_id = @iCreateByUserID) AND
			(
				@dtCreateDateFrom IS NULL OR @dtCreateDateTo IS NULL OR 
				FLOOR(CAST(ph0.create_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtCreateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtCreateDateTo AS FLOAT))
			) 	AND			
			(@iUpdateByUserID IS NULL OR ph0.update_by_user_id = @iUpdateByUserID) AND
			(
				@dtUpdateDateFrom IS NULL OR @dtUpdateDateTo IS NULL OR 
				FLOOR(CAST(ph0.update_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtUpdateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtUpdateDateTo AS FLOAT))
			) 	AND
			(@sKeyWords IS NULL OR
			ph0.pfs_holiday_desc LIKE '%' + @sKeyWords + '%' OR
			ph0.recurrance LIKE '%' + @sKeyWords + '%')
	
END
