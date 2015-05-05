/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectGet
	Desc    		:	This store procedure is use to get list of PFS_MODULE_OBJECT by id
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iModuleID INT = NULL 
)
AS
BEGIN

                
	SELECT
			pmo0.pfs_module_object_id,
			pmo0.pfs_module_id,
			pmo0.object_code,
			pmo0.object_name,
			pmo0.object_descr,
			pmo0.index_order,
			pm1.module_code,
			pm1.module_name
		FROM
			pfs_module_object pmo0 WITH (NOLOCK),
			pfs_module pm1 WITH (NOLOCK)
		WHERE
			pmo0.pfs_module_id = pm1.pfs_module_id AND 
			(@iModuleID IS NULL OR pmo0.pfs_module_id = @iModuleID) AND
			(@sKeyWords IS NULL OR
			pmo0.object_code LIKE '%' + @sKeyWords + '%' OR
			pmo0.object_name LIKE '%' + @sKeyWords + '%' OR
			pmo0.object_descr LIKE '%' + @sKeyWords + '%')
	
END
