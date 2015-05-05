/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserUpdate
	Desc    		:	This store procedure is use to update PFS_USER
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	20 Aug 2013		- Modified By : Alvin
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserUpdate]
(
	@iUserID INT,
	@sUserName VARCHAR(50),
	@sPassword VARCHAR(100),
	@sFullName VARCHAR(100),
	@sTitle VARCHAR(20),
	@sEmail VARCHAR(100),
	@bIsActive BIT,
	@bIsNeedApproval BIT,
	@dtLastAccess DATETIME,
	@bIsLogin BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT,
	@sStartLoginTime VARCHAR(5),
	@sEndLoginTime VARCHAR(5),
	@bAllowHolidayLogin BIT,
	@bAllowWeekendLogin BIT,
	@sSecurityQuestion VARCHAR(255),
	@sSecurityAnswer VARCHAR(255),
	@iTodayFailedLoginAttempts INT,
	@dtLastFailedLoginDate DATETIME,
	@bIsBlocked BIT
)
AS
BEGIN

	UPDATE [PFS_USER] SET
		user_name = @sUserName,
		password = @sPassword,
		full_name = @sFullName,
		title = @sTitle,
		email = @sEmail,
		is_active = @bIsActive,
		is_need_approval = @bIsNeedApproval,
		last_access = @dtLastAccess,
		is_login = @bIsLogin,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID,
		start_login_time = @sStartLoginTime,
		end_login_time = @sEndLoginTime,
		allow_holiday_login = @bAllowHolidayLogin,
		allow_weekend_login = @bAllowWeekendLogin,
		security_question = @sSecurityQuestion,
		security_answer = @sSecurityAnswer,
		today_failed_login_attempts = @iTodayFailedLoginAttempts,
		last_failed_login_date = @dtLastFailedLoginDate,
		is_blocked = @bIsBlocked
	WHERE
      	pfs_user_id = @iUserID
	SELECT @@ERROR
	
END
