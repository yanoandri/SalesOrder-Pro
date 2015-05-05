/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserPasswordHistoryDelete
	Desc    		:	This store procedure is use to delete PFS_USER_PASSWORD_HISTORY
	Create Date 	:	12 Sep 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserPasswordHistoryDelete]
(
	@lUserPasswordHistoryID BIGINT
)
AS
BEGIN
	DELETE PFS_USER_PASSWORD_HISTORY
    WHERE PFS_USER_PASSWORD_HISTORY_ID = @lUserPasswordHistoryID
END
