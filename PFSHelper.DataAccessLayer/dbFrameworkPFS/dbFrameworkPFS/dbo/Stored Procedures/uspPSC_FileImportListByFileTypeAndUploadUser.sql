/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_FileImportList
	Desc    		:	This store procedure is use to get list of PSC_FILE_IMPORT
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:	uspPSC_FileImportListByFileTypeAndUploadUser null, null, null
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_FileImportListByFileTypeAndUploadUser]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iFileTypeID INT = NULL,
	@iUploadByUserID INT = NULL
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
		isnull(pu0.user_name,'System') as user_name,
		pfi0.file_name,
		pfi0.archive_file_name,
		pfi0.archive_file_password,
		pfi0.archive_invalid_data_file_name,
		pfi0.remark,
		pfi0.total_input_data,
		pfi0.total_valid_data,
		pfi0.total_invalid_data,
		pfi0.is_valid,
		pft2.type_name
	FROM
		psc_file_import pfi0 WITH (NOLOCK)
	INNER JOIN
		psc_file_type pft2 WITH (NOLOCK)
	ON
		pfi0.PSC_FILE_TYPE_ID = pft2.PSC_FILE_TYPE_ID
	left join
		pfs_user pu0 WITH(NOLOCK)
	on
		pfi0.UPLOAD_BY = pu0.PFS_USER_ID
	WHERE	
		(@iFileTypeID IS NULL OR (@iFileTypeID = 3 AND pfi0.PSC_FILE_TYPE_ID IN (3)) OR (@iFileTypeID != 3 AND pfi0.PSC_FILE_TYPE_ID IN (1,2))) AND
		(@iUploadByUserID IS NULL OR pfi0.upload_by = @iUploadByUserID) AND		
		(@sKeyWords IS NULL OR
		pfi0.reference_number LIKE '%' + @sKeyWords + '%' OR
		pfi0.file_name LIKE '%' + @sKeyWords + '%' OR
		pfi0.remark LIKE '%' + @sKeyWords + '%')
END

