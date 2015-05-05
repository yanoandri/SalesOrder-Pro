/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SysParamAdd
	Desc    		:	This store procedure is use to add PFS_SYS_PARAM
	Create Date 	:	02 Mar 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Mar 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamAdd]
(
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

	DECLARE @sCode INT
	INSERT INTO [PFS_SYS_PARAM] 
    ( 	
		description,
		value,
		data_type,
		is_visible,
		pfs_sys_param_group_id,
		sys_param_name,
		index_order,
		is_encrypted
	)
	VALUES
	(
		@sDescription,
		@sValue,
		@sDataType,
		@bIsVisible,
		@iSysParamGroupID,
		@sSysParamName,
		@iIndexOrder,
		@bIsEncrypted
	)
	
	SET  @sCode = ISNULL(@@IDENTITY, 0)
	SELECT @sCode
	
END
