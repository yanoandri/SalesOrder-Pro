/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_FileImportAdd
	Desc    		:	This store procedure is use to add PSC_FILE_IMPORT
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_FileImportAdd]
(
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
	DECLARE @iFileImportID INT
    
	INSERT INTO PSC_FILE_IMPORT 
    ( 	
		psc_process_status_id,
		psc_file_type_id,
		reference_number,
		upload_date,
		upload_by,
		file_name,
		archive_file_name,
		archive_file_password,
		archive_invalid_data_file_name,
		remark,
		total_input_data,
		total_valid_data,
		total_invalid_data,
		is_valid
	)
	VALUES
	(
		@iProcessStatusID,
		@iFileTypeID,
		@sReferenceNumber,
		@dtUploadDate,
		@iUploadBy,
		@sFileName,
		@sArchiveFileName,
		@sArchiveFilePassword,
		@sArchiveInvalidDataFileName,
		@sRemark,
		@iTotalInputData,
		@iTotalValidData,
		@iTotalInvalidData,
		@bIsValid
	)
    
	SET @iFileImportID = ISNULL(@@IDENTITY, 0)
	SELECT @iFileImportID
END
