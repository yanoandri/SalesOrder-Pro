
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingComCustomerGet
	Desc    		:	This store procedure is use to get TMPT_FIRST_STAGING_COM_CUSTOMER by id
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingComCustomerGet
(
	@iFirstStagingComCustomerID INT
)
AS
BEGIN
	SELECT
		tfscc0.tmpt_first_staging_com_customer_id,
		tfscc0.psc_file_import_id,
		tfscc0.cif,
		tfscc0.customer_dob,
		tfscc0.branch_code,
		tfscc0.branch_name,
		tfscc0.control_center,
		tfscc0.education_name,
		tfscc0.full_name,
		tfscc0.is_valid,
		tfscc0.remark,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name
	FROM
		tmpt_first_staging_com_customer tfscc0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK)
	WHERE
		tfscc0.psc_file_import_id = pfi1.psc_file_import_id AND
		tfscc0.tmpt_first_staging_com_customer_id = @iFirstStagingComCustomerID
END
