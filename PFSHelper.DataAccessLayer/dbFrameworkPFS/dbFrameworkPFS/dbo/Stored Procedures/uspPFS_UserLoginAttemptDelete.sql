/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLoginAttemptDelete
	Desc    		:	This store procedure is use to delete PFS_USER_LOGIN_ATTEMPT
	Create Date 	:	31 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	31 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLoginAttemptDelete]
(
	@iUserLoginAttemptID INT
)
AS
BEGIN

	DELETE [PFS_USER_LOGIN_ATTEMPT] 
    WHERE
      [PFS_USER_LOGIN_ATTEMPT_ID] = @iUserLoginAttemptID	
	
END
