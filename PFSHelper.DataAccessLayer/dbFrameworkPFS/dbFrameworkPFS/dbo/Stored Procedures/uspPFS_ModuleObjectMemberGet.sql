/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberGet
	Desc    		:	This store procedure is use to get PFS_MODULE_OBJECT_MEMBER by id
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberGet]
(
	@iModuleObjectMemberID INT = NULL
)
AS
BEGIN

	SELECT
			pmom0.pfs_module_object_member_id,
			pmom0.pfs_module_object_id,
			pmom0.member_code,
			pmom0.member_name,
			pmom0.member_descr,
			pmom0.index_order,
			pmom0.is_with_approval_proccess,
			pmo1.object_code,
			pmo1.object_name
		FROM
			pfs_module_object_member pmom0 WITH (NOLOCK),
			pfs_module_object pmo1 WITH (NOLOCK)
		WHERE
			pmom0.pfs_module_object_id = pmo1.pfs_module_object_id AND 
			(@iModuleObjectMemberID IS NULL OR pmom0.pfs_module_object_member_id = @iModuleObjectMemberID) 
END
