/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SysParamGet
	Desc    		:	This store procedure is use to get PFS_SYS_PARAM by id
	Create Date 	:	02 Mar 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Mar 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamGet]
(
	@sCode VARCHAR(100) = NULL
)
AS
BEGIN

	SELECT
			psp0.code,
			psp0.description,
			psp0.value,
			psp0.data_type,
			psp0.is_visible,
			psp0.pfs_sys_param_group_id,
			psp0.sys_param_name,
			psp0.index_order,
			psp0.is_encrypted,
			pspg1.param_group_name
		FROM
			pfs_sys_param psp0 WITH (NOLOCK),
			pfs_sys_param_group pspg1 WITH (NOLOCK)
		WHERE
			psp0.pfs_sys_param_group_id = pspg1.pfs_sys_param_group_id AND 
			(@sCode IS NULL OR psp0.code = @sCode) 
END
