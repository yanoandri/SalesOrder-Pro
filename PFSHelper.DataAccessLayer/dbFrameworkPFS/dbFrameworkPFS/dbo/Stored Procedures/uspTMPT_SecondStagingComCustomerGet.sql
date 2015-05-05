
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingComCustomerGet
	Desc    		:	This store procedure is use to get TMPT_SECOND_STAGING_COM_CUSTOMER by id
	Create Date 	:	21 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingComCustomerGet
(
	@iSecondStagingComCustomerID INT
)
AS
BEGIN
	SELECT
		tsscc0.tmpt_second_staging_com_customer_id,
		tsscc0.psc_file_import_id,
		tsscc0.cif,
		tsscc0.customer_dob,
		tsscc0.control_center,
		tsscc0.com_education_id,
		tsscc0.full_name,
		tsscc0.com_branch_id,
		tsscc0.is_valid,
		tsscc0.invalid_remark,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name,
		ce2.education_name,
		cb3.branch_code,
		cb3.branch_name
	FROM
		tmpt_second_staging_com_customer tsscc0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK),
		com_education ce2 WITH (NOLOCK),
		com_branch cb3 WITH (NOLOCK)
	WHERE
		tsscc0.psc_file_import_id = pfi1.psc_file_import_id AND
		tsscc0.com_education_id = ce2.com_education_id AND
		tsscc0.com_branch_id = cb3.com_branch_id AND
		tsscc0.tmpt_second_staging_com_customer_id = @iSecondStagingComCustomerID
END
