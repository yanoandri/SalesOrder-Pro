/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberGroupUpdate
	Desc    		:	This store procedure is use to update PFS_MODULE_OBJECT_MEMBER_GROUP
	Create Date 	:	08 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	08 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberGroupUpdate]
(
	@iModuleObjectMemberGroupID INT,
	@iModuleID INT,
	@iModuleObjectID INT,
	@iModuleObjectMemberID INT,
	@iGroupID INT
)
AS
BEGIN

	UPDATE [PFS_MODULE_OBJECT_MEMBER_GROUP] SET
		pfs_module_id = @iModuleID,
		pfs_module_object_id = @iModuleObjectID,
		pfs_module_object_member_id = @iModuleObjectMemberID,
		pfs_group_id = @iGroupID
	WHERE
      	pfs_module_object_member_group_id = @iModuleObjectMemberGroupID
			
	SELECT @@ERROR		
END
