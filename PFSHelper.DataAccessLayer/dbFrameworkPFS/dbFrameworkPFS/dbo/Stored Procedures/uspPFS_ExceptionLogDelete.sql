/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ExceptionLogDelete
	Desc    		:	This store procedure is use to delete PFS_EXCEPTION_LOG
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ExceptionLogDelete]
(
	@lExceptionLogID BIGINT
)
AS
BEGIN

	DELETE [PFS_EXCEPTION_LOG] 
    WHERE
      [PFS_EXCEPTION_LOG_ID] = @lExceptionLogID	
	
END
