/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SysParamDelete
	Desc    		:	This store procedure is use to delete PFS_SYS_PARAM
	Create Date 	:	02 Mar 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Mar 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SysParamDelete]
(
	@sCode VARCHAR(100)
)
AS
BEGIN

	DELETE [PFS_SYS_PARAM] 
    WHERE
      [CODE] = @sCode	
	
END
