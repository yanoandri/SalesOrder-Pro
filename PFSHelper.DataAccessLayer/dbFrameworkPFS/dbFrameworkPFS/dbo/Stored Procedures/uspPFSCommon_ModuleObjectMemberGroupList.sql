/*****************************************************************************
  Copyright (c) 2005, PT Profescipta Wahanatehnik. All Rights Reserved.
 
  This software, all associated documentation, and all copies
  are CONFIDENTIAL INFORMATION of PT Profescipta Wahanatehnik.
 
 
  DESCRIPTION
	Name    	:   uspPFSCommon_ModuleObjectMemberGroupList
	Desc    	:	
	Input   	: 	
	Output  	:	
	Comments	:	
	Status  	: 	
	Sample Data : uspPFSCommon_ModuleObjectMemberGroupList 'DOC_SET_DELETE', 10
******************************************************************************/
CREATE PROCEDURE uspPFSCommon_ModuleObjectMemberGroupList
(
	@sMemberCode VARCHAR(100) = NULL,
	@iUserID INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT DISTINCT
		[pmom].[MEMBER_CODE],
		[pug].[PFS_USER_ID]
	FROM
		[dbo].[PFS_MODULE_OBJECT_MEMBER] AS pmom WITH(NOLOCK)
		INNER JOIN [dbo].[PFS_MODULE_OBJECT_MEMBER_GROUP] AS pmomg WITH(NOLOCK) ON [pmom].[PFS_MODULE_OBJECT_MEMBER_ID] = [pmomg].[PFS_MODULE_OBJECT_MEMBER_ID]
		INNER JOIN [dbo].[PFS_USER_GROUP] AS pug WITH(NOLOCK) ON [pmomg].[PFS_GROUP_ID] = [pug].[PFS_GROUP_ID]
		INNER JOIN [dbo].[PFS_GROUP] AS pg WITH(NOLOCK) ON [pug].[PFS_GROUP_ID] = [pg].[PFS_GROUP_ID]
		INNER JOIN [dbo].[PFS_USER] AS pu WITH(NOLOCK) ON [pug].[PFS_USER_ID] = [pu].[PFS_USER_ID]
	WHERE
		[pg].[IS_ACTIVE] = 1
		AND [pu].[IS_ACTIVE] = 1
		AND (@sMemberCode IS NULL OR [pmom].[MEMBER_CODE] = @sMemberCode)
		AND (@iUserID IS NULL OR [pug].[PFS_USER_ID] = @iUserID)			
END
