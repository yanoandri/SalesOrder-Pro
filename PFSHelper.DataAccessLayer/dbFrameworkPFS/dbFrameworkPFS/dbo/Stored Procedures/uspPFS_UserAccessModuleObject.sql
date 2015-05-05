/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserAccessModuleObject
	Desc    		:	This store procedure is use to get list of PFS_MODULE_OBJECT_MEMBER by id
	Create Date 	:	24 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	24 Nov 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
					uspPFS_UserAccessModuleObject 52,3004
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserAccessModuleObject] 
(
	@iUserID AS INT = 52,
	@iModuleObject INT = null
)
AS
/**********************************************************************************
	This part get list of user access.
***********************************************************************************/
SELECT DISTINCT 
	pmo4.OBJECT_CODE
FROM 
	PFS_USER pu0
	Inner Join PFS_USER_GROUP pug1 On pug1.PFS_USER_ID = pu0.PFS_USER_ID
	Inner Join PFS_GROUP pg2 On pg2.PFS_GROUP_ID = pug1.PFS_GROUP_ID
	Inner Join PFS_MODULE_OBJECT_MEMBER_GROUP pmomg3 On pmomg3.PFS_GROUP_ID = pg2.PFS_GROUP_ID
	Inner Join dbo.PFS_MODULE_OBJECT pmo4 On pmo4.PFS_MODULE_OBJECT_ID = pmomg3.PFS_MODULE_OBJECT_ID
Where
	pu0.PFS_USER_ID = @iUserID
	and (@iModuleObject is null or pmo4.PFS_MODULE_OBJECT_ID = @iModuleObject)
	AND pg2.IS_ACTIVE = 1
