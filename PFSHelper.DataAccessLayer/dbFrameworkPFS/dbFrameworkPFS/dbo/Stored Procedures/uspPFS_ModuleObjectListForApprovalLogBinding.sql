/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_ModuleObjectListForApprovalLogBinding]
	Desc    		:	This store procedure is use to get list of PFS_MODULE_OBJECT by id
	Create Date 	:	09 Feb 2011		- Created By  : kprasetyo
	Modified Date 	:	09 Feb 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectListForApprovalLogBinding]
AS
BEGIN
           
	SELECT 
		pmo2.PFS_MODULE_OBJECT_ID,
		pmo2.OBJECT_CODE,
		pmo2.OBJECT_NAME,
		pmo2.OBJECT_DESCR,
		pmo2.PFS_MODULE_ID,
		pmo2.INDEX_ORDER 
	FROM 
		COM_APPROVAL_LOG cal0 WITH(NOLOCK)
		INNER JOIN pfs_module_object_member pmom1 WITH(NOLOCK) ON cal0.PFS_MODULE_OBJECT_MEMBER_ID = pmom1.PFS_MODULE_OBJECT_MEMBER_ID
		INNER JOIN dbo.PFS_MODULE_OBJECT pmo2 WITH(NOLOCK) ON pmom1.PFS_MODULE_OBJECT_ID = pmo2.PFS_MODULE_OBJECT_ID
	GROUP BY 
		pmo2.PFS_MODULE_OBJECT_ID,
		pmo2.OBJECT_CODE,
		pmo2.OBJECT_NAME,
		pmo2.OBJECT_DESCR,
		pmo2.PFS_MODULE_ID,
		pmo2.INDEX_ORDER 
	
END
