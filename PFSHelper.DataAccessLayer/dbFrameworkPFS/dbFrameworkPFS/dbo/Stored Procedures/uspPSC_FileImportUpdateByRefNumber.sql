/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_FileImportUpdate
	Desc    		:	This store procedure is use to update PSC_FILE_IMPORT
	Create Date 	:	27 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_FileImportUpdateByRefNumber
(
	@iProcessStatusID INT,
	@sReferenceNumber VARCHAR(25),
	@sRemark VARCHAR(1000),
	@bIsValid BIT
)
AS
BEGIN
	UPDATE PSC_FILE_IMPORT SET
		psc_process_status_id = @iProcessStatusID,
		remark = @sRemark,
		is_valid = @bIsValid
	WHERE
      	reference_number = @sReferenceNumber

	SELECT @@ERROR
END



