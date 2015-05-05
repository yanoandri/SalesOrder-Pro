/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberGroupAdd
	Desc    		:	This store procedure is use to add PFS_MODULE_OBJECT_MEMBER_GROUP
	Create Date 	:	08 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	08 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberGroupAdd]
(
	@iModuleID INT,
	@iModuleObjectID INT,
	@iModuleObjectMemberID INT,
	@iGroupID INT
)
AS
BEGIN

	DECLARE @iModuleObjectMemberGroupID INT
	INSERT INTO [PFS_MODULE_OBJECT_MEMBER_GROUP] 
    ( 	
		pfs_module_id,
		pfs_module_object_id,
		pfs_module_object_member_id,
		pfs_group_id
	)
	VALUES
	(
		@iModuleID,
		@iModuleObjectID,
		@iModuleObjectMemberID,
		@iGroupID
	)
	
	SET  @iModuleObjectMemberGroupID = ISNULL(@@IDENTITY, 0)
	SELECT @iModuleObjectMemberGroupID
	
END
