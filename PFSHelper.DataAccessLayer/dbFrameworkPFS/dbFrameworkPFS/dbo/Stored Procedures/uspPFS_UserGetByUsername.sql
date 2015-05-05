/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGet
	Desc    		:	This store procedure is use to get PFS_USER by id
	Create Date 	:	14 Oct 2011		- Created By  : kprasetyo
	Modified Date 	:	20 Aug 2013		- Modified By : Alvin
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserGetByUsername]
(
	@sUserName varchar(max) = NULL,
	@bIsLogin bit = null,
	@iUserID INT = null
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
			pu0.START_LOGIN_TIME,
			pu0.END_LOGIN_TIME,
			pu0.ALLOW_HOLIDAY_LOGIN,
			pu0.ALLOW_WEEKEND_LOGIN,
			pu0.is_active,
			pu0.is_need_approval,
			pu0.last_access,
			pu0.is_login,
			pu0.create_date,
			pu0.create_by_user_id,
			pu0.update_date,
			pu0.update_by_user_id,
			pu0.security_question,
			pu0.security_answer,
			pu0.today_failed_login_attempts,
			pu0.last_failed_login_date,
			pu0.is_blocked
		FROM
			pfs_user pu0 WITH (NOLOCK)
		WHERE
			(@sUserName IS NULL OR pu0.user_name = @sUserName) and
			(@bIsLogin is null or pu0.is_login = @bIsLogin) and
			(@iUserID is null or pu0.pfs_user_id <> @iUserID)
END
