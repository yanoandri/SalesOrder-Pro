
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingPscJatisTransactionUpdate
	Desc    		:	This store procedure is use to update TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION
	Create Date 	:	11 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingPscJatisTransactionUpdate
(
	@iSecondStagingPscJatisTransactionID INT,
	@iFileImportID INT,
	@sDate VARCHAR(50),
	@iBranchID INT,
	@sBranchCode VARCHAR(20),
	@sBranchName VARCHAR(250),
	@iCustomerID INT,
	@sCif VARCHAR(15),
	@sCustomerName VARCHAR(255),
	@iProductID INT,
	@sProductCode VARCHAR(20),
	@sProductName VARCHAR(250),
	@iAssetClassID INT,
	@iCurrencyID INT,
	@dAmount FLOAT,
	@iRmID INT,
	@iRmwCipID INT,
	@bIsValid BIT,
	@sInvalidRemark VARCHAR(500)
)
AS
BEGIN
	UPDATE TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION SET
		psc_file_import_id = @iFileImportID,
		date = @sDate,
		branch_id = @iBranchID,
		branch_code = @sBranchCode,
		branch_name = @sBranchName,
		com_customer_id = @iCustomerID,
		cif = @sCif,
		customer_name = @sCustomerName,
		product_id = @iProductID,
		product_code = @sProductCode,
		product_name = @sProductName,
		asset_class_id = @iAssetClassID,
		com_currency_id = @iCurrencyID,
		amount = @dAmount,
		com_rm_id = @iRmID,
		psc_rmw_cip_id = @iRmwCipID,
		is_valid = @bIsValid,
		invalid_remark = @sInvalidRemark
	WHERE
      	tmpt_second_staging_psc_jatis_transaction_id = @iSecondStagingPscJatisTransactionID

	SELECT @@ERROR
END
