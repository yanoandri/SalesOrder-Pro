/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectDelete
	Desc    		:	This store procedure is use to delete PFS_MODULE_OBJECT
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectDelete]
(
	@iModuleObjectID INT
)
AS
BEGIN

	DELETE [PFS_MODULE_OBJECT] 
    WHERE
      [PFS_MODULE_OBJECT_ID] = @iModuleObjectID	
	
END
