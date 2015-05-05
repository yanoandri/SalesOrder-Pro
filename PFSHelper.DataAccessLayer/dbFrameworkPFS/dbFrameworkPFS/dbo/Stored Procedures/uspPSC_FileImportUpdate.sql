/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_FileImportUpdate
	Desc    		:	This store procedure is use to update PSC_FILE_IMPORT
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_FileImportUpdate]
(
	@iFileImportID INT,
	@iProcessStatusID INT,
	@iFileTypeID INT,
	@sReferenceNumber VARCHAR(25),
	@dtUploadDate DATETIME,
	@iUploadBy INT,
	@sFileName VARCHAR(50),
	@sArchiveFileName VARCHAR(250),
	@sArchiveFilePassword VARCHAR(50),
	@sArchiveInvalidDataFileName VARCHAR(500),
	@sRemark VARCHAR(1000),
	@iTotalInputData INT,
	@iTotalValidData INT,
	@iTotalInvalidData INT,
	@bIsValid BIT
)
AS
BEGIN
	UPDATE PSC_FILE_IMPORT SET
		psc_process_status_id = @iProcessStatusID,
		psc_file_type_id = @iFileTypeID,
		reference_number = @sReferenceNumber,
		upload_date = @dtUploadDate,
		upload_by = @iUploadBy,
		file_name = @sFileName,
		archive_file_name = @sArchiveFileName,
		archive_file_password = @sArchiveFilePassword,
		archive_invalid_data_file_name = @sArchiveInvalidDataFileName,
		remark = @sRemark,
		total_input_data = @iTotalInputData,
		total_valid_data = @iTotalValidData,
		total_invalid_data = @iTotalInvalidData,
		is_valid = @bIsValid
	WHERE
      	psc_file_import_id = @iFileImportID

	SELECT @@ERROR
END

