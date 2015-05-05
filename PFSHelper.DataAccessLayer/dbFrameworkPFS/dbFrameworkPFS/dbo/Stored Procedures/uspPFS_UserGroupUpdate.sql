/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGroupUpdate
	Desc    		:	This store procedure is use to update PFS_USER_GROUP
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserGroupUpdate]
(
	@iUserGroupID INT,
	@iUserID INT,
	@iGroupID INT
)
AS
BEGIN

	UPDATE [PFS_USER_GROUP] SET
		pfs_user_id = @iUserID,
		pfs_group_id = @iGroupID
	WHERE
      	pfs_user_group_id = @iUserGroupID
			
	SELECT @@ERROR		
END
