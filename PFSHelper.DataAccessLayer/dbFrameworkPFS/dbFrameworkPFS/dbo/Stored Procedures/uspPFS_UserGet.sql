/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGet
	Desc    		:	This store procedure is use to get PFS_USER by id
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	20 Aug 2013		- Modified By : Alvin
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserGet]
(
	@iUserID INT = NULL
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
			pu0.allow_weekend_login,
			pu0.security_question,
			pu0.security_answer,
			pu0.today_failed_login_attempts,
			pu0.last_failed_login_date,
			pu0.is_blocked
		FROM
			pfs_user pu0 WITH (NOLOCK)
		WHERE
			(@iUserID IS NULL OR pu0.pfs_user_id = @iUserID) 

END
