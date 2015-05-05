/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SysParamGroupAdd
	Desc    		:	This store procedure is use to add PFS_SYS_PARAM_GROUP
	Create Date 	:	29 Dec 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	29 Dec 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamGroupAdd]
(
	@sParamGroupName VARCHAR(100),
	@sGroupDescr VARCHAR(500),
	@iIndexOrder INT,
	@bIsVisible BIT
)
AS
BEGIN

	DECLARE @iSysParamGroupID INT
	INSERT INTO [PFS_SYS_PARAM_GROUP] 
    ( 	
		param_group_name,
		group_descr,
		index_order,
		is_visible
	)
	VALUES
	(
		@sParamGroupName,
		@sGroupDescr,
		@iIndexOrder,
		@bIsVisible
	)
	
	SET  @iSysParamGroupID = ISNULL(@@IDENTITY, 0)
	SELECT @iSysParamGroupID
	
END
