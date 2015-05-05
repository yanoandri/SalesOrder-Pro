
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingPscJatisTransactionGet
	Desc    		:	This store procedure is use to get TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION by id
	Create Date 	:	11 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingPscJatisTransactionGet
(
	@iSecondStagingPscJatisTransactionID INT
)
AS
BEGIN
	SELECT
		tsspjt0.tmpt_second_staging_psc_jatis_transaction_id,
		tsspjt0.psc_file_import_id,
		tsspjt0.date,
		tsspjt0.branch_id,
		tsspjt0.branch_code,
		tsspjt0.branch_name,
		tsspjt0.com_customer_id,
		tsspjt0.cif,
		tsspjt0.customer_name,
		tsspjt0.product_id,
		tsspjt0.product_code,
		tsspjt0.product_name,
		tsspjt0.asset_class_id,
		tsspjt0.com_currency_id,
		tsspjt0.amount,
		tsspjt0.com_rm_id,
		tsspjt0.psc_rmw_cip_id,
		tsspjt0.is_valid,
		tsspjt0.invalid_remark,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name,
		cc2.full_name,
		cc3.currency_code,
		cr4.rm_code,
		cr4.rm_name,
		prc5.education_name
	FROM
		tmpt_second_staging_psc_jatis_transaction tsspjt0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK),
		com_customer cc2 WITH (NOLOCK),
		com_currency cc3 WITH (NOLOCK),
		com_rm cr4 WITH (NOLOCK),
		psc_rmw_cip prc5 WITH (NOLOCK)
	WHERE
		tsspjt0.psc_file_import_id = pfi1.psc_file_import_id AND
		tsspjt0.com_customer_id = cc2.com_customer_id AND
		tsspjt0.com_currency_id = cc3.com_currency_id AND
		tsspjt0.com_rm_id = cr4.com_rm_id AND
		tsspjt0.psc_rmw_cip_id = prc5.psc_rmw_cip_id AND
		tsspjt0.tmpt_second_staging_psc_jatis_transaction_id = @iSecondStagingPscJatisTransactionID
END
