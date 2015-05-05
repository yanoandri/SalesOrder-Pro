/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleUpdate
	Desc    		:	This store procedure is use to update PFS_MODULE
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleUpdate]
(
	@iModuleID INT,
	@sModuleCode VARCHAR(50),
	@sModuleName VARCHAR(100),
	@sModuleDescr VARCHAR(1280),
	@iIndexOrder INT
)
AS
BEGIN

	UPDATE [PFS_MODULE] SET
		module_code = @sModuleCode,
		module_name = @sModuleName,
		module_descr = @sModuleDescr,
		INDEX_ORDER = @iIndexOrder
	WHERE
      	pfs_module_id = @iModuleID
			
	SELECT @@ERROR		
END
