/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SystemLogUpdate
	Desc    		:	This store procedure is use to update PFS_SYSTEM_LOG
	Create Date 	:	31 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	31 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SystemLogUpdate]
(
	@lSystemLogID BIGINT,
	@sReferenceNumber VARCHAR(25),
	@iProcessID INT,
	@dtLogDate DATETIME,
	@iStatus INT,
	@sDescription VARCHAR(1280),
	@xmlDetail XML
)
AS
BEGIN

	UPDATE [PFS_SYSTEM_LOG] SET
		reference_number = @sReferenceNumber,
		com_process_id = @iProcessID,
		log_date = @dtLogDate,
		status = @iStatus,
		description = @sDescription,
		detail = @xmlDetail
	WHERE
      	pfs_system_log_id = @lSystemLogID
			
	SELECT @@ERROR		
END
