/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_SysParamListOrderByIndex]
	Desc    		:	This store procedure is use to get list of PFS_SYS_PARAM by id
	Create Date 	:	02 Mar 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Mar 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamListOrderByIndex]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsVisible BIT = NULL ,
	@iSysParamGroupID INT = NULL ,
	@bIsEncrypted BIT = NULL 
)
AS
BEGIN

                
	SELECT
			psp0.*,
			pspg1.param_group_name
		FROM
			pfs_sys_param psp0 WITH (NOLOCK),
			pfs_sys_param_group pspg1 WITH (NOLOCK)
		WHERE
			psp0.pfs_sys_param_group_id = pspg1.pfs_sys_param_group_id AND 
			(@bIsVisible IS NULL OR psp0.is_visible = @bIsVisible) AND
			(@iSysParamGroupID IS NULL OR psp0.pfs_sys_param_group_id = @iSysParamGroupID) AND
			(@bIsEncrypted IS NULL OR psp0.is_encrypted = @bIsEncrypted) AND
			(@sKeyWords IS NULL OR
			psp0.code LIKE '%' + @sKeyWords + '%' OR
			psp0.description LIKE '%' + @sKeyWords + '%' OR
			psp0.value LIKE '%' + @sKeyWords + '%' OR
			psp0.data_type LIKE '%' + @sKeyWords + '%' OR
			psp0.sys_param_name LIKE '%' + @sKeyWords + '%')
	
		ORDER BY
			psp0.INDEX_ORDER,
			psp0.CODE
	
END
