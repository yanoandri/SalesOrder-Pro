/*****************************************************************************
  Copyright (c) 2006, PT Profescipta Wahanatehnik. All Rights Reserved.
 
  This software, all associated documentation, and all copies
  are CONFIDENTIAL INFORMATION of PT Profescipta Wahanatehnik.
 
 
  DESCRIPTION
	Name    	:   [uspPFS_ModuleObjectListByModuleID]
	Desc    	:	This procedure is used to get list of "access" objects.
	Input   	: 	@iModuleID
	Output  	:	
	Comments	:	
	Status  	: 	
	Sample Data :	EXEC [spPFS_ModuleObjectList] 2
	Revision	:	2013-09-17 - ssaputra - Read IsVisible flag

******************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectListByModuleID] 
(
	@iModuleID AS INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT DISTINCT
		[pmo].[PFS_MODULE_OBJECT_ID], 
		[pmo].[PFS_MODULE_ID], 
		[pmo].[OBJECT_CODE], 
		[pmo].[OBJECT_NAME], 
		[pmo].[OBJECT_DESCR],
		[pmo].[INDEX_ORDER],
		[pmo].[IS_VISIBLE]
	FROM 
		[dbo].[PFS_MODULE] AS pm WITH(NOLOCK)
		INNER JOIN [dbo].[PFS_MODULE_OBJECT] AS pmo WITH(NOLOCK) ON [pm].[PFS_MODULE_ID] = [pmo].[PFS_MODULE_ID]
		INNER JOIN [dbo].[PFS_MODULE_OBJECT_MEMBER] AS pmom WITH(NOLOCK) ON [pmo].[PFS_MODULE_OBJECT_ID] = [pmom].[PFS_MODULE_OBJECT_ID]
	WHERE
		[pmo].[IS_VISIBLE] = 1 
		AND (@iModuleID IS NULL OR [pmo].[PFS_MODULE_ID] = @iModuleID)
	ORDER BY 
		[pmo].[INDEX_ORDER]
END
