/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ExceptionLogUpdate
	Desc    		:	This store procedure is use to update PFS_EXCEPTION_LOG
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ExceptionLogUpdate]
(
	@lExceptionLogID BIGINT,
	@sReferenceNumber VARCHAR(25),
	@dtLogDate DATETIME,
	@sSource VARCHAR(255),
	@sDescription VARCHAR(4000)
)
AS
BEGIN

	UPDATE [PFS_EXCEPTION_LOG] SET
		reference_number = @sReferenceNumber,
		log_date = @dtLogDate,
		source = @sSource,
		description = @sDescription
	WHERE
      	pfs_exception_log_id = @lExceptionLogID
			
	SELECT @@ERROR		
END
