/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SystemLogAdd
	Desc    		:	This store procedure is use to add PFS_SYSTEM_LOG
	Create Date 	:	31 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	31 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SystemLogAdd]
(
	@sReferenceNumber VARCHAR(25),
	@iProcessID INT,
	@dtLogDate DATETIME,
	@iStatus INT,
	@sDescription VARCHAR(1280),
	@xmlDetail XML
)
AS
BEGIN

	DECLARE @lSystemLogID INT
	INSERT INTO [PFS_SYSTEM_LOG] 
    ( 	
		reference_number,
		com_process_id,
		log_date,
		status,
		description,
		detail
	)
	VALUES
	(
		@sReferenceNumber,
		@iProcessID,
		@dtLogDate,
		@iStatus,
		@sDescription,
		@xmlDetail
	)
	
	SET  @lSystemLogID = ISNULL(@@IDENTITY, 0)
	SELECT @lSystemLogID
	
END
