/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ExceptionLogAdd
	Desc    		:	This store procedure is use to add PFS_EXCEPTION_LOG
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ExceptionLogAdd]
(
	@sReferenceNumber VARCHAR(25),
	@dtLogDate DATETIME,
	@sSource VARCHAR(255),
	@sDescription VARCHAR(4000)
)
AS
BEGIN

	DECLARE @lExceptionLogID INT
	INSERT INTO [PFS_EXCEPTION_LOG] 
    ( 	
		reference_number,
		log_date,
		source,
		description
	)
	VALUES
	(
		@sReferenceNumber,
		@dtLogDate,
		@sSource,
		@sDescription
	)
	
	SET  @lExceptionLogID = ISNULL(@@IDENTITY, 0)
	SELECT @lExceptionLogID
	
END
