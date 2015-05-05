
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscJatisTransactionGet
	Desc    		:	This store procedure is use to get TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION by id
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingPscJatisTransactionGet
(
	@iFirstStagingPscJatisTransactionID INT
)
AS
BEGIN
	SELECT
		tfspjt0.tmpt_first_staging_psc_jatis_transaction_id,
		tfspjt0.psc_file_import_id,
		tfspjt0.date,
		tfspjt0.branch_code,
		tfspjt0.branch_name,
		tfspjt0.cif,
		tfspjt0.customer_name,
		tfspjt0.prouct_code,
		tfspjt0.product_name,
		tfspjt0.asset_class_name,
		tfspjt0.currency_code,
		tfspjt0.amount,
		tfspjt0.rm_name,
		tfspjt0.is_valid,
		tfspjt0.remark,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name
	FROM
		tmpt_first_staging_psc_jatis_transaction tfspjt0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK)
	WHERE
		tfspjt0.psc_file_import_id = pfi1.psc_file_import_id AND
		tfspjt0.tmpt_first_staging_psc_jatis_transaction_id = @iFirstStagingPscJatisTransactionID
END
