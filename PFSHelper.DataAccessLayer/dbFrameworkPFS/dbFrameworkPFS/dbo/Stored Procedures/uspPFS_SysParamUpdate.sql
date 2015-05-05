/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SysParamUpdate
	Desc    		:	This store procedure is use to update PFS_SYS_PARAM
	Create Date 	:	02 Mar 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Mar 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamUpdate]
(
	@sCode VARCHAR(100),
	@sDescription VARCHAR(255),
	@sValue VARCHAR(1280),
	@sDataType VARCHAR(20),
	@bIsVisible BIT,
	@iSysParamGroupID INT,
	@sSysParamName VARCHAR(100),
	@iIndexOrder INT,
	@bIsEncrypted BIT
)
AS
BEGIN

	UPDATE [PFS_SYS_PARAM] SET
		description = @sDescription,
		value = @sValue,
		data_type = @sDataType,
		is_visible = @bIsVisible,
		pfs_sys_param_group_id = @iSysParamGroupID,
		sys_param_name = @sSysParamName,
		index_order = @iIndexOrder,
		is_encrypted = @bIsEncrypted
	WHERE
      	code = @sCode
			
	SELECT @@ERROR		
END
