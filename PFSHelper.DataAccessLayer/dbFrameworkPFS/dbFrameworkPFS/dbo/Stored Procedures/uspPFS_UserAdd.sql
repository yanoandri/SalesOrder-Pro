/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserAdd
	Desc    		:	This store procedure is use to add PFS_USER
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	20 Aug 2013		- Modified By : Alvin
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserAdd]
(
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

	DECLARE @iUserID INT
	INSERT INTO [PFS_USER] 
    ( 	
		user_name,
		password,
		full_name,
		title,
		email,
		is_active,
		is_need_approval,
		last_access,
		is_login,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id,
		start_login_time,
		end_login_time,
		allow_holiday_login,
		allow_weekend_login,
		security_question,
		security_answer,
		today_failed_login_attempts,
		last_failed_login_date,
		is_blocked
	)
	VALUES
	(
		@sUserName,
		@sPassword,
		@sFullName,
		@sTitle,
		@sEmail,
		@bIsActive,
		@bIsNeedApproval,
		@dtLastAccess,
		@bIsLogin,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID,
		@sStartLoginTime,
		@sEndLoginTime,
		@bAllowHolidayLogin,
		@bAllowWeekendLogin,
		@sSecurityQuestion,
		@sSecurityAnswer,
		@iTodayFailedLoginAttempts,
		@dtLastFailedLoginDate,
		@bIsBlocked
	)
	
	SET  @iUserID = ISNULL(@@IDENTITY, 0)
	SELECT @iUserID

	
END
