/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberGroupGet
	Desc    		:	This store procedure is use to get list of PFS_MODULE_OBJECT_MEMBER_GROUP by id
	Create Date 	:	08 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	08 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberGroupList] 
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iModuleID INT = NULL ,
	@iModuleObjectID INT = NULL ,
	@iModuleObjectMemberID INT = NULL ,
	@iGroupID INT = NULL 
)
AS
BEGIN

                
	SELECT
			pmomg0.pfs_module_object_member_group_id,
			pmomg0.pfs_module_id,
			pmomg0.pfs_module_object_id,
			pmomg0.pfs_module_object_member_id,
			pmomg0.pfs_group_id,
			pm1.module_code,
			pm1.module_name,
			pmo2.object_code,
			pmo2.object_name,
			pmom3.member_code,
			pmom3.member_name,
			pg4.group_name
		FROM
			pfs_module_object_member_group pmomg0 WITH (NOLOCK)
			inner join pfs_module pm1 WITH (NOLOCK) on pmomg0.pfs_module_id = pm1.pfs_module_id
			inner join pfs_module_object pmo2 WITH (NOLOCK) on pmomg0.pfs_module_object_id = pmo2.pfs_module_object_id
			inner join pfs_module_object_member pmom3 WITH (NOLOCK) on pmomg0.pfs_module_object_member_id = pmom3.pfs_module_object_member_id
			inner join pfs_group pg4 WITH (NOLOCK) on pmomg0.pfs_group_id = pg4.pfs_group_id
		WHERE
			(@iModuleID IS NULL OR pmomg0.pfs_module_id = @iModuleID) AND
			(@iModuleObjectID IS NULL OR pmomg0.pfs_module_object_id = @iModuleObjectID) AND
			(@iModuleObjectMemberID IS NULL OR pmomg0.pfs_module_object_member_id = @iModuleObjectMemberID) AND
			(@iGroupID IS NULL OR pmomg0.pfs_group_id = @iGroupID) AND
			(@sKeyWords IS NULL)
	
END
