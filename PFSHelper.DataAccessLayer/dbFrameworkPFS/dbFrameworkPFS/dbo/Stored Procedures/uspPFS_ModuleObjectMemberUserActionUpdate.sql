/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberUserActionUpdate
	Desc    		:	This store procedure is use to update PFS_MODULE_OBJECT_MEMBER_USER_ACTION
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberUserActionUpdate]
(
	@iModuleObjectMemberUserActionID INT,
	@iModuleObjectMemberID INT,
	@iModuleObjectID INT,
	@iUserActionType INT
)
AS
BEGIN

	UPDATE [PFS_MODULE_OBJECT_MEMBER_USER_ACTION] SET
		pfs_module_object_member_id = @iModuleObjectMemberID,
		pfs_module_object_id = @iModuleObjectID,
		user_action_type = @iUserActionType
	WHERE
      	pfs_module_object_member_user_action_id = @iModuleObjectMemberUserActionID
			
	SELECT @@ERROR		
END
