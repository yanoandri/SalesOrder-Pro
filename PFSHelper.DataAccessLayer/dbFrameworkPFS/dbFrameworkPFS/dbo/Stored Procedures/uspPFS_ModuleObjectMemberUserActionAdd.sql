/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberUserActionAdd
	Desc    		:	This store procedure is use to add PFS_MODULE_OBJECT_MEMBER_USER_ACTION
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberUserActionAdd]
(
	@iModuleObjectMemberID INT,
	@iModuleObjectID INT,
	@iUserActionType INT
)
AS
BEGIN

	DECLARE @iModuleObjectMemberUserActionID INT
	INSERT INTO [PFS_MODULE_OBJECT_MEMBER_USER_ACTION] 
    ( 	
		pfs_module_object_member_id,
		pfs_module_object_id,
		user_action_type
	)
	VALUES
	(
		@iModuleObjectMemberID,
		@iModuleObjectID,
		@iUserActionType
	)
	
	SET  @iModuleObjectMemberUserActionID = ISNULL(@@IDENTITY, 0)
	SELECT @iModuleObjectMemberUserActionID
	
END
