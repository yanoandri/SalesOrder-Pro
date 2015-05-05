/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SysParamGroupUpdate
	Desc    		:	This store procedure is use to update PFS_SYS_PARAM_GROUP
	Create Date 	:	29 Dec 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	29 Dec 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamGroupUpdate]
(
	@iSysParamGroupID INT,
	@sParamGroupName VARCHAR(100),
	@sGroupDescr VARCHAR(500),
	@iIndexOrder INT,
	@bIsVisible BIT
)
AS
BEGIN

	UPDATE [PFS_SYS_PARAM_GROUP] SET
		param_group_name = @sParamGroupName,
		group_descr = @sGroupDescr,
		index_order = @iIndexOrder,
		is_visible = @bIsVisible
	WHERE
      	pfs_sys_param_group_id = @iSysParamGroupID
			
	SELECT @@ERROR		
END
