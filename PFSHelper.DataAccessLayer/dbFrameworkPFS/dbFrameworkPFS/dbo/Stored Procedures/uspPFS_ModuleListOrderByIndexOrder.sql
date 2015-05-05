/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleListOrderByIndexOder
	Desc    		:	This store procedure is use to get list of PFS_MODULE by id
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
						2013-09-17 - ssaputra - Read IsVisible flag
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleListOrderByIndexOrder]
(
	@sKeyWords VARCHAR(1280) = NULL
)
AS
BEGIN
	SET NOCOUNT ON
                
	SELECT
		[PFS_MODULE_ID],
		[MODULE_CODE],
		[MODULE_NAME],
		[MODULE_DESCR],
		[INDEX_ORDER],
		[IS_VISIBLE]
	FROM
		pfs_module WITH (NOLOCK)
	WHERE
		[IS_VISIBLE] = 1
		AND (@sKeyWords IS NULL 
				OR [MODULE_CODE] LIKE '%' + @sKeyWords + '%' 
				OR [MODULE_NAME] LIKE '%' + @sKeyWords + '%' 
				OR [MODULE_DESCR] LIKE '%' + @sKeyWords + '%')
	ORDER BY 
		INDEX_ORDER
END
