/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLoginAttemptUpdateSuccesful
	Desc    		:	This store procedure is use to update PFS_USER_LOGIN_ATTEMPT
	Create Date 	:	16 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	16 Nov 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLoginAttemptUpdateSuccesful]
(
	@iUserLoginAttemptID INT,
	@sUserName VARCHAR(50),
	@dtLastSuccessfullLoginDate DATETIME,
	@iTotalSuccess INT
)
AS
BEGIN

	UPDATE [PFS_USER_LOGIN_ATTEMPT] SET
		user_name = @sUserName,
		last_successfull_login_date = GETDATE(),
		total_success = @iTotalSuccess
	WHERE
      	pfs_user_login_attempt_id = @iUserLoginAttemptID
			
	SELECT @@ERROR		
END
