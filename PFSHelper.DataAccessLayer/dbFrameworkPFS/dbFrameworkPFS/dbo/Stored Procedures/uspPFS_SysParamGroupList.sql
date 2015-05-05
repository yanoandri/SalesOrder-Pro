/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SysParamGroupGet
	Desc    		:	This store procedure is use to get list of PFS_SYS_PARAM_GROUP by id
	Create Date 	:	29 Dec 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	29 Dec 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamGroupList]
(
	@sKeyWords VARCHAR(1280) = NULL
)
AS
BEGIN

                
	SELECT
			pspg0.pfs_sys_param_group_id,
			pspg0.param_group_name,
			pspg0.group_descr,
			pspg0.index_order,
			pspg0.is_visible
		FROM
			pfs_sys_param_group pspg0 WITH (NOLOCK)
		WHERE
			(@sKeyWords IS NULL OR
			pspg0.param_group_name LIKE '%' + @sKeyWords + '%' OR
			pspg0.group_descr LIKE '%' + @sKeyWords + '%') AND
			pspg0.is_visible = 1
		ORDER BY
			pspg0.INDEX_ORDER ASC
END
