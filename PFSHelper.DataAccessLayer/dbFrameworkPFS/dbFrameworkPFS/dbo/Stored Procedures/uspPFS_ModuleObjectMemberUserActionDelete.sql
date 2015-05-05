/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberUserActionDelete
	Desc    		:	This store procedure is use to delete PFS_MODULE_OBJECT_MEMBER_USER_ACTION
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberUserActionDelete]
(
	@iModuleObjectMemberUserActionID INT
)
AS
BEGIN

	DELETE [PFS_MODULE_OBJECT_MEMBER_USER_ACTION] 
    WHERE
      [PFS_MODULE_OBJECT_MEMBER_USER_ACTION_ID] = @iModuleObjectMemberUserActionID	
	
END
