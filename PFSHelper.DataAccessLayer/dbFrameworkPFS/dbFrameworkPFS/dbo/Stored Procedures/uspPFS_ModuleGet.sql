/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleGet
	Desc    		:	This store procedure is use to get PFS_MODULE by id
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleGet]
(
	@iModuleID INT = NULL
)
AS
BEGIN

	SELECT
			pm0.pfs_module_id,
			pm0.module_code,
			pm0.module_name,
			pm0.module_descr,
			pm0.INDEX_ORDER
		FROM
			pfs_module pm0 WITH (NOLOCK)
		WHERE
			(@iModuleID IS NULL OR pm0.pfs_module_id = @iModuleID) 
END
