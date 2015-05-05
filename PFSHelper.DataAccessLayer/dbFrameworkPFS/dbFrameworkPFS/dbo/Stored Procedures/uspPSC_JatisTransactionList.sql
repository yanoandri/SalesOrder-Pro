
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionList
	Desc    		:	This store procedure is use to get list of PSC_JATIS_TRANSACTION
	Create Date 	:	11 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_JatisTransactionList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iFileImportID INT = NULL,
	@dtDateFrom DATETIME = NULL,
	@dtDateTo DATETIME = NULL,
	@iBranchID INT = NULL,
	@iCustomerID INT = NULL,
	@iProductID INT = NULL,
	@iAssetClassID INT = NULL,
	@iCurrencyID INT = NULL,
	@bIsWithException BIT = NULL,
	@iRmID INT = NULL,
	@iRmwCipID INT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL
)
AS
BEGIN
	SELECT
		pjt0.psc_jatis_transaction_id,
		pjt0.psc_file_import_id,
		pjt0.date,
		pjt0.branch_id,
		pjt0.branch_code,
		pjt0.branch_name,
		pjt0.com_customer_id,
		pjt0.cif,
		pjt0.customer_name,
		pjt0.product_id,
		pjt0.product_code,
		pjt0.product_name,
		pjt0.asset_class_id,
		pjt0.com_currency_id,
		pjt0.amount,
		pjt0.is_with_exception,
		pjt0.com_rm_id,
		pjt0.psc_rmw_cip_id,
		pjt0.create_date,
		pjt0.create_by_user_id,
		pjt0.update_date,
		pjt0.update_by_user_id,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name,
		cc2.full_name,
		cc3.currency_code,
		cr4.rm_code,
		cr4.rm_name,
		prc5.education_name
	FROM
		psc_jatis_transaction pjt0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK),
		com_customer cc2 WITH (NOLOCK),
		com_currency cc3 WITH (NOLOCK),
		com_rm cr4 WITH (NOLOCK),
		psc_rmw_cip prc5 WITH (NOLOCK)
	WHERE
		pjt0.psc_file_import_id = pfi1.psc_file_import_id AND
		pjt0.com_customer_id = cc2.com_customer_id AND
		pjt0.com_currency_id = cc3.com_currency_id AND
		pjt0.com_rm_id = cr4.com_rm_id AND
		pjt0.psc_rmw_cip_id = prc5.psc_rmw_cip_id AND
		(@iFileImportID IS NULL OR pjt0.psc_file_import_id = @iFileImportID) AND
		(@dtDateFrom IS NULL OR CONVERT(VARCHAR, pjt0.date, 12) >= CONVERT(VARCHAR, @dtDateFrom, 12)) AND
		(@dtDateTo IS NULL OR CONVERT(VARCHAR, pjt0.date, 12) <= CONVERT(VARCHAR, @dtDateTo, 12)) AND
		(@iBranchID IS NULL OR pjt0.branch_id = @iBranchID) AND
		(@iCustomerID IS NULL OR pjt0.com_customer_id = @iCustomerID) AND
		(@iProductID IS NULL OR pjt0.product_id = @iProductID) AND
		(@iAssetClassID IS NULL OR pjt0.asset_class_id = @iAssetClassID) AND
		(@iCurrencyID IS NULL OR pjt0.com_currency_id = @iCurrencyID) AND
		(@bIsWithException IS NULL OR pjt0.is_with_exception = @bIsWithException) AND
		(@iRmID IS NULL OR pjt0.com_rm_id = @iRmID) AND
		(@iRmwCipID IS NULL OR pjt0.psc_rmw_cip_id = @iRmwCipID) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, pjt0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, pjt0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR pjt0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, pjt0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, pjt0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR pjt0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		pjt0.branch_code LIKE '%' + @sKeyWords + '%' OR
		pjt0.branch_name LIKE '%' + @sKeyWords + '%' OR
		pjt0.cif LIKE '%' + @sKeyWords + '%' OR
		pjt0.customer_name LIKE '%' + @sKeyWords + '%' OR
		pjt0.product_code LIKE '%' + @sKeyWords + '%' OR
		pjt0.product_name LIKE '%' + @sKeyWords + '%')
END
