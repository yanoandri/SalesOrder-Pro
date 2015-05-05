/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleDelete
	Desc    		:	This store procedure is use to delete PFS_MODULE
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleDelete]
(
	@iModuleID INT
)
AS
BEGIN

	DELETE [PFS_MODULE] 
    WHERE
      [PFS_MODULE_ID] = @iModuleID	
	
END
