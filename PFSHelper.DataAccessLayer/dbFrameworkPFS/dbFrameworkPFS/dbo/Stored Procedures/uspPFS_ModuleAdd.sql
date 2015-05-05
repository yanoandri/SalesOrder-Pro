/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleAdd
	Desc    		:	This store procedure is use to add PFS_MODULE
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleAdd]
(
	@sModuleCode VARCHAR(50),
	@sModuleName VARCHAR(100),
	@sModuleDescr VARCHAR(1280),
	@iIndexOrder INT
)
AS
BEGIN

	DECLARE @iModuleID INT
	INSERT INTO [PFS_MODULE] 
    ( 	
		module_code,
		module_name,
		module_descr,
		index_order
	)
	VALUES
	(
		@sModuleCode,
		@sModuleName,
		@sModuleDescr,
		@iIndexOrder
	)
	
	SET  @iModuleID = ISNULL(@@IDENTITY, 0)
	SELECT @iModuleID
	
END
