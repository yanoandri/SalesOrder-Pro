/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectAdd
	Desc    		:	This store procedure is use to add PFS_MODULE_OBJECT
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectAdd]
(
	@iModuleID INT,
	@sObjectCode VARCHAR(50),
	@sObjectName VARCHAR(100),
	@sObjectDescr VARCHAR(500),
	@iIndexOrder SMALLINT
)
AS
BEGIN

	DECLARE @iModuleObjectID INT
	INSERT INTO [PFS_MODULE_OBJECT] 
    ( 	
		pfs_module_id,
		object_code,
		object_name,
		object_descr,
		index_order
	)
	VALUES
	(
		@iModuleID,
		@sObjectCode,
		@sObjectName,
		@sObjectDescr,
		@iIndexOrder
	)
	
	SET  @iModuleObjectID = ISNULL(@@IDENTITY, 0)
	SELECT @iModuleObjectID
	
END
