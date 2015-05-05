/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SystemLogDelete
	Desc    		:	This store procedure is use to delete PFS_SYSTEM_LOG
	Create Date 	:	31 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	31 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SystemLogDelete]
(
	@lSystemLogID BIGINT
)
AS
BEGIN

	DELETE [PFS_SYSTEM_LOG] 
    WHERE
      [PFS_SYSTEM_LOG_ID] = @lSystemLogID	
	
END
