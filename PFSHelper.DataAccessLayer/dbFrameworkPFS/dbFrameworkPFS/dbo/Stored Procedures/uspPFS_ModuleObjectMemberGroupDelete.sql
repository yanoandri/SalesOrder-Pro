/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberGroupDelete
	Desc    		:	This store procedure is use to delete PFS_MODULE_OBJECT_MEMBER_GROUP
	Create Date 	:	08 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	08 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberGroupDelete]
(
	@iModuleObjectMemberGroupID INT
)
AS
BEGIN

	DELETE [PFS_MODULE_OBJECT_MEMBER_GROUP] 
    WHERE
      [PFS_MODULE_OBJECT_MEMBER_GROUP_ID] = @iModuleObjectMemberGroupID	
	
END
