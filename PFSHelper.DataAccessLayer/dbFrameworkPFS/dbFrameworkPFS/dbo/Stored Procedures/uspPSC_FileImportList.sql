
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_FileImportList
	Desc    		:	This store procedure is use to get list of PSC_FILE_IMPORT
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_FileImportList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iProcessStatusID INT = NULL,
	@iFileTypeID INT = NULL,
	@dtUploadDateFrom DATETIME = NULL,
	@dtUploadDateTo DATETIME = NULL,
	@bIsValid BIT = NULL
)
AS
BEGIN
	SELECT
		pfi0.psc_file_import_id,
		pfi0.psc_process_status_id,
		pfi0.psc_file_type_id,
		pfi0.reference_number,
		pfi0.upload_date,
		pfi0.upload_by,
		pfi0.file_name,
		pfi0.archive_file_name,
		pfi0.archive_file_password,
		pfi0.archive_invalid_data_file_name,
		pfi0.remark,
		pfi0.total_input_data,
		pfi0.total_valid_data,
		pfi0.total_invalid_data,
		pfi0.is_valid,
		pps1.process_name,
		pft2.type_name
	FROM
		psc_file_import pfi0 WITH (NOLOCK),
		psc_process_status pps1 WITH (NOLOCK),
		psc_file_type pft2 WITH (NOLOCK)
	WHERE
		pfi0.psc_process_status_id = pps1.psc_process_status_id AND
		pfi0.psc_file_type_id = pft2.psc_file_type_id AND
		(@iProcessStatusID IS NULL OR pfi0.psc_process_status_id = @iProcessStatusID) AND
		(@iFileTypeID IS NULL OR pfi0.psc_file_type_id = @iFileTypeID) AND
		(@dtUploadDateFrom IS NULL OR CONVERT(VARCHAR, pfi0.upload_date, 12) >= CONVERT(VARCHAR, @dtUploadDateFrom, 12)) AND
		(@dtUploadDateTo IS NULL OR CONVERT(VARCHAR, pfi0.upload_date, 12) <= CONVERT(VARCHAR, @dtUploadDateTo, 12)) AND
		(@bIsValid IS NULL OR pfi0.is_valid = @bIsValid) AND
		(@sKeyWords IS NULL OR
		pfi0.reference_number LIKE '%' + @sKeyWords + '%' OR
		pfi0.file_name LIKE '%' + @sKeyWords + '%' OR
		pfi0.archive_file_name LIKE '%' + @sKeyWords + '%' OR
		pfi0.archive_file_password LIKE '%' + @sKeyWords + '%' OR
		pfi0.archive_invalid_data_file_name LIKE '%' + @sKeyWords + '%' OR
		pfi0.remark LIKE '%' + @sKeyWords + '%')
END
