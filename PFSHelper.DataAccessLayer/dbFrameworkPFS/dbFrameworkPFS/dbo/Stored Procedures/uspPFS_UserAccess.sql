---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




/*****************************************************************************
  Copyright (c) 2005, PT Profescipta Wahanatehnik. All Rights Reserved.
 
  This software, all associated documentation, and all copies
  are CONFIDENTIAL INFORMATION of PT Profescipta Wahanatehnik.
 
 
  DESCRIPTION
	Name    	:   uspPFS_UserAccess
	Desc    	:	This procedure is used to validate user access.
	Input   	: 	@iUserID, @sMemberCode
	Output  	:	
	Comments	:	
	Status  	: 	
	Sample Data :	spPFS_UserAccess 3
******************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserAccess] 
(
	@iUserID AS INT = 25,
	@sMemberCode VARCHAR(50) = null
)
AS
/**********************************************************************************
	This part get list of user access.
***********************************************************************************/
SELECT DISTINCT 
	PFS_MODULE_OBJECT_MEMBER.MEMBER_CODE
FROM 
	PFS_USER WITH(nolock)
	Inner Join PFS_USER_GROUP WITH(nolock) On PFS_USER_GROUP.PFS_USER_ID = PFS_USER.PFS_USER_ID
	Inner Join PFS_GROUP WITH(nolock) On PFS_GROUP.PFS_GROUP_ID = PFS_USER_GROUP.PFS_GROUP_ID
	Inner Join PFS_MODULE_OBJECT_MEMBER_GROUP WITH(nolock) On PFS_MODULE_OBJECT_MEMBER_GROUP.PFS_GROUP_ID = PFS_GROUP.PFS_GROUP_ID
	Inner Join PFS_MODULE_OBJECT_MEMBER WITH(nolock) On PFS_MODULE_OBJECT_MEMBER.PFS_MODULE_OBJECT_MEMBER_ID = PFS_MODULE_OBJECT_MEMBER_GROUP.PFS_MODULE_OBJECT_MEMBER_ID
Where
	PFS_USER.PFS_USER_ID = @iUserID
	and (@sMemberCode is null or PFS_MODULE_OBJECT_MEMBER.MEMBER_CODE = @sMemberCode)
	AND PFS_GROUP.IS_ACTIVE = 1
	AND PFS_GROUP.IS_ACTIVE = 1
