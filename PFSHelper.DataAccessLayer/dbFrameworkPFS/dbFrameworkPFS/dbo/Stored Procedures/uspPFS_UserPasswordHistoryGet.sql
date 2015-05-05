/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserPasswordHistoryGet
	Desc    		:	This store procedure is use to get PFS_USER_PASSWORD_HISTORY by id
	Create Date 	:	12 Sep 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserPasswordHistoryGet]
(
	@lUserPasswordHistoryID BIGINT
)
AS
BEGIN
	SELECT
		puph0.pfs_user_password_history_id,
		puph0.pfs_user_id,
		puph0.password,
		puph0.create_date,
		pu1.user_name,
		pu1.full_name
	FROM
		pfs_user_password_history puph0 WITH (NOLOCK),
		pfs_user pu1 WITH (NOLOCK)
	WHERE
		puph0.pfs_user_id = pu1.pfs_user_id AND
		puph0.pfs_user_password_history_id = @lUserPasswordHistoryID
END
