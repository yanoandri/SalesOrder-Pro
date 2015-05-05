/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SysParamGroupDelete
	Desc    		:	This store procedure is use to delete PFS_SYS_PARAM_GROUP
	Create Date 	:	29 Dec 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	29 Dec 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamGroupDelete]
(
	@iSysParamGroupID INT
)
AS
BEGIN

	DELETE [PFS_SYS_PARAM_GROUP] 
    WHERE
      [PFS_SYS_PARAM_GROUP_ID] = @iSysParamGroupID	
	
END
