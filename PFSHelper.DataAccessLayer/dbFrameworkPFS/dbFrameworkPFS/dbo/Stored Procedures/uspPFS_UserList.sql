/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGet
	Desc    		:	This store procedure is use to get list of PFS_USER by id
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsActive BIT = NULL ,
	@bIsNeedApproval BIT = NULL ,
	@dtLastAccessFrom DATETIME = NULL,
	@dtLastAccessTo DATETIME = NULL,
	@bIsLogin BIT = NULL ,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL ,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL ,
	@bAllowHolidayLogin BIT = NULL ,
	@bAllowWeekendLogin BIT = NULL 
)
AS
BEGIN

                
	SELECT
			pu0.pfs_user_id,
			pu0.user_name,
			pu0.password,
			pu0.full_name,
			pu0.title,
			pu0.email,
			pu0.is_active,
			pu0.is_need_approval,
			pu0.last_access,
			pu0.is_login,
			pu0.create_date,
			pu0.create_by_user_id,
			pu0.update_date,
			pu0.update_by_user_id,
			pu0.start_login_time,
			pu0.end_login_time,
			pu0.allow_holiday_login,
			pu0.allow_weekend_login
		FROM
			pfs_user pu0 WITH (NOLOCK)
		WHERE
			(@bIsActive IS NULL OR pu0.is_active = @bIsActive) AND
			(@bIsNeedApproval IS NULL OR pu0.is_need_approval = @bIsNeedApproval) AND
			(
				@dtLastAccessFrom IS NULL OR @dtLastAccessTo IS NULL OR 
				FLOOR(CAST(pu0.last_access AS FLOAT)) BETWEEN FLOOR(CAST(@dtLastAccessFrom AS FLOAT)) AND FLOOR(CAST(@dtLastAccessTo AS FLOAT))
			) 				AND
			(@bIsLogin IS NULL OR pu0.is_login = @bIsLogin) AND
			(
				@dtCreateDateFrom IS NULL OR @dtCreateDateTo IS NULL OR 
				FLOOR(CAST(pu0.create_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtCreateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtCreateDateTo AS FLOAT))
			) 				AND
			(@iCreateByUserID IS NULL OR pu0.create_by_user_id = @iCreateByUserID) AND
			(
				@dtUpdateDateFrom IS NULL OR @dtUpdateDateTo IS NULL OR 
				FLOOR(CAST(pu0.update_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtUpdateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtUpdateDateTo AS FLOAT))
			) 				AND
			(@iUpdateByUserID IS NULL OR pu0.update_by_user_id = @iUpdateByUserID) AND
			(@bAllowHolidayLogin IS NULL OR pu0.allow_holiday_login = @bAllowHolidayLogin) AND
			(@bAllowWeekendLogin IS NULL OR pu0.allow_weekend_login = @bAllowWeekendLogin) AND
			(@sKeyWords IS NULL OR
			pu0.user_name LIKE '%' + @sKeyWords + '%' OR
			pu0.password LIKE '%' + @sKeyWords + '%' OR
			pu0.full_name LIKE '%' + @sKeyWords + '%' OR
			pu0.title LIKE '%' + @sKeyWords + '%' OR
			pu0.email LIKE '%' + @sKeyWords + '%' OR
			pu0.start_login_time LIKE '%' + @sKeyWords + '%' OR
			pu0.end_login_time LIKE '%' + @sKeyWords + '%')
	
END
