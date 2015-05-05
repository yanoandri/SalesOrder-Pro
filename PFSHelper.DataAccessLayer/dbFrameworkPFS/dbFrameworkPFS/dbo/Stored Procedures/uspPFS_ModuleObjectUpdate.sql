/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectUpdate
	Desc    		:	This store procedure is use to update PFS_MODULE_OBJECT
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectUpdate]
(
	@iModuleObjectID INT,
	@iModuleID INT,
	@sObjectCode VARCHAR(50),
	@sObjectName VARCHAR(100),
	@sObjectDescr VARCHAR(500),
	@iIndexOrder SMALLINT
)
AS
BEGIN

	UPDATE [PFS_MODULE_OBJECT] SET
		pfs_module_id = @iModuleID,
		object_code = @sObjectCode,
		object_name = @sObjectName,
		object_descr = @sObjectDescr,
		index_order = @iIndexOrder
	WHERE
      	pfs_module_object_id = @iModuleObjectID
			
	SELECT @@ERROR		
END
