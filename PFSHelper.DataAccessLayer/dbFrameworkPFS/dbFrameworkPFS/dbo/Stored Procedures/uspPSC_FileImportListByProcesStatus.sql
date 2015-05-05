/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_FileImportListByProcesStatus
	Desc    		:	This store procedure is use to get list of PSC_FILE_IMPORT
	Create Date 	:	15 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By : sbakhri
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_FileImportListByProcesStatus
(
	@iProcessStatusID INT = NULL
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
		pfi0.is_valid
	FROM
		psc_file_import pfi0 WITH (NOLOCK)
	WHERE
		pfi0.psc_process_status_id = @iProcessStatusID 
	ORDER BY
	 pfi0.reference_number
END



