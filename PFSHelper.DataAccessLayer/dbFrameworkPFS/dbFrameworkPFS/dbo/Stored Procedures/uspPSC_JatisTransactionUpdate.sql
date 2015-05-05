
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionUpdate
	Desc    		:	This store procedure is use to update PSC_JATIS_TRANSACTION
	Create Date 	:	11 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_JatisTransactionUpdate
(
	@iJatisTransactionID INT,
	@iFileImportID INT,
	@dtDate DATETIME,
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
	@bIsWithException BIT,
	@iRmID INT,
	@iRmwCipID INT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_JATIS_TRANSACTION SET
		psc_file_import_id = @iFileImportID,
		date = @dtDate,
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
		is_with_exception = @bIsWithException,
		com_rm_id = @iRmID,
		psc_rmw_cip_id = @iRmwCipID,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	psc_jatis_transaction_id = @iJatisTransactionID

	SELECT @@ERROR
END
