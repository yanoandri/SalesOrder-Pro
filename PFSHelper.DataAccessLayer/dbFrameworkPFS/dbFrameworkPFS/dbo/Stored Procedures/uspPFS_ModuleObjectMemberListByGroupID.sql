/*****************************************************************************
  Copyright (c) 2006, PT Profescipta Wahanatehnik. All Rights Reserved.
 
  This software, all associated documentation, and all copies
  are CONFIDENTIAL INFORMATION of PT Profescipta Wahanatehnik.
 
 
  DESCRIPTION
	Name    	:   [uspPFS_ModuleObjectMemberListByGroupID]
	Desc    	:	This procedure is used to get list of "access" members.
	Input   	: 	@iGroupID, @iModuleObjectID
	Output  	:	
	Comments	:	
	Status  	: 	
	Sample Data :	EXEC [uspPFS_ModuleObjectMemberListByGroupID] 12
******************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberListByGroupID] (
	@iGroupID AS INT = NULL,
	@iModuleObjectID AS INT = NULL
)
AS
/**********************************************************************************
	This part get list of module object members.
***********************************************************************************/
SELECT DISTINCT 
	mom.pfs_module_object_member_id, 
	mom.pfs_module_object_id, 
	mom.member_code, 
	mom.member_name, 
	mom.member_descr,
	access = (CASE WHEN momg.pfs_module_object_member_group_id IS NULL THEN 0 ELSE 1 END) ,
	mom.INDEX_ORDER
FROM 
	pfs_module_object_member mom LEFT JOIN 
	   (SELECT pfs_module_object_member_group_id, pfs_module_object_member_id 
		FROM pfs_module_object_member_group 
		WHERE @iGroupID IS NULL OR pfs_group_id = @iGroupID) momg 
	ON momg.pfs_module_object_member_id = mom.pfs_module_object_member_id
WHERE 
	mom.pfs_module_object_id NOT IN 
		(SELECT pfs_module_object_id FROM pfs_module_object WHERE object_code = 'AUT')
	AND (@iModuleObjectID IS NULL OR mom.pfs_module_object_id = @iModuleObjectID)
ORDER BY 
	mom.pfs_module_object_id ASC, 
	mom.INDEX_ORDER ASC
