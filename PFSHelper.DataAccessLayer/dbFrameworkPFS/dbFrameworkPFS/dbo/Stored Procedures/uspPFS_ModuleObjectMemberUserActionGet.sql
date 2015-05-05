/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberUserActionGet
	Desc    		:	This store procedure is use to get PFS_MODULE_OBJECT_MEMBER_USER_ACTION by id
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberUserActionGet]
(
	@iModuleObjectMemberUserActionID INT = NULL
)
AS
BEGIN

	SELECT
			pmomua0.pfs_module_object_member_user_action_id,
			pmomua0.pfs_module_object_member_id,
			pmomua0.pfs_module_object_id,
			pmomua0.user_action_type,
			pmom1.member_code,
			pmom1.member_name,
			pmo2.object_code,
			pmo2.object_name
		FROM
			pfs_module_object_member_user_action pmomua0 WITH (NOLOCK),
			pfs_module_object_member pmom1 WITH (NOLOCK),
			pfs_module_object pmo2 WITH (NOLOCK)
		WHERE
			pmomua0.pfs_module_object_member_id = pmom1.pfs_module_object_member_id AND 
			pmomua0.pfs_module_object_id = pmo2.pfs_module_object_id AND 
			(@iModuleObjectMemberUserActionID IS NULL OR pmomua0.pfs_module_object_member_user_action_id = @iModuleObjectMemberUserActionID) 
END
