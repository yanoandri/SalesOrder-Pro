/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserPasswordHistoryUpdate
	Desc    		:	This store procedure is use to update PFS_USER_PASSWORD_HISTORY
	Create Date 	:	12 Sep 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserPasswordHistoryUpdate]
(
	@lUserPasswordHistoryID BIGINT,
	@iUserID INT,
	@sPassword VARCHAR(255),
	@dtCreateDate DATETIME
)
AS
BEGIN
	UPDATE PFS_USER_PASSWORD_HISTORY SET
		pfs_user_id = @iUserID,
		password = @sPassword,
		create_date = @dtCreateDate
	WHERE
      	pfs_user_password_history_id = @lUserPasswordHistoryID

	SELECT @@ERROR
END
