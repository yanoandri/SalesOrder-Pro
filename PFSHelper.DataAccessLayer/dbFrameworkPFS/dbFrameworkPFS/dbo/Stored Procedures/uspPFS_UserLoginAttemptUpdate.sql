/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLoginAttemptUpdate
	Desc    		:	This store procedure is use to update PFS_USER_LOGIN_ATTEMPT
	Create Date 	:	31 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	31 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLoginAttemptUpdate]
(
	@iUserLoginAttemptID INT,
	@sUserName VARCHAR(50),
	@dtLastSuccessfullLoginDate DATETIME,
	@dtLastFailedLoginDate DATETIME,
	@iTotalSuccess INT,
	@iTotalFailed INT,
	@sLastFailedDescription VARCHAR(500)
)
AS
BEGIN

	UPDATE [PFS_USER_LOGIN_ATTEMPT] SET
		user_name = @sUserName,
		last_successfull_login_date = @dtLastSuccessfullLoginDate,
		last_failed_login_date = @dtLastFailedLoginDate,
		total_success = @iTotalSuccess,
		total_failed = @iTotalFailed,
		last_failed_description = @sLastFailedDescription
	WHERE
      	pfs_user_login_attempt_id = @iUserLoginAttemptID
			
	SELECT @@ERROR		
END
