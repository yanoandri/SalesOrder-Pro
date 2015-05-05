/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLoginAttemptAdd
	Desc    		:	This store procedure is use to add PFS_USER_LOGIN_ATTEMPT
	Create Date 	:	31 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	31 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLoginAttemptAdd]
(
	@sUserName VARCHAR(50),
	@dtLastSuccessfullLoginDate DATETIME,
	@dtLastFailedLoginDate DATETIME,
	@iTotalSuccess INT,
	@iTotalFailed INT,
	@sLastFailedDescription VARCHAR(500)
)
AS
BEGIN

	DECLARE @iUserLoginAttemptID INT
	INSERT INTO [PFS_USER_LOGIN_ATTEMPT] 
    ( 	
		user_name,
		last_successfull_login_date,
		last_failed_login_date,
		total_success,
		total_failed,
		last_failed_description
	)
	VALUES
	(
		@sUserName,
		@dtLastSuccessfullLoginDate,
		@dtLastFailedLoginDate,
		@iTotalSuccess,
		@iTotalFailed,
		@sLastFailedDescription
	)
	
	SET  @iUserLoginAttemptID = ISNULL(@@IDENTITY, 0)
	SELECT @iUserLoginAttemptID
	
END
