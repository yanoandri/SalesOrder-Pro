/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberGroupDeleteByGroupID
	Desc    		:	This store procedure is use to add PFS_MODULE_OBJECT_MEMBER_GROUP
	Create Date 	:	08 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	08 Nov 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberGroupDeleteByGroupID] 
(
	@iGroupID INT
)
AS
BEGIN
	DELETE FROM 
		pfs_module_object_member_group 
	WHERE 
		pfs_group_id = @iGroupID
		
		SELECT @@error
END
