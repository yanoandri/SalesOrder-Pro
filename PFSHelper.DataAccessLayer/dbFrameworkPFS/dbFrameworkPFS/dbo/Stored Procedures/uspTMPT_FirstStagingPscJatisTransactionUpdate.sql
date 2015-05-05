
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscJatisTransactionUpdate
	Desc    		:	This store procedure is use to update TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingPscJatisTransactionUpdate
(
	@iFirstStagingPscJatisTransactionID INT,
	@iFileImportID INT,
	@sDate VARCHAR(25),
	@sBranchCode VARCHAR(10),
	@sBranchName VARCHAR(100),
	@sCif VARCHAR(15),
	@sCustomerName VARCHAR(255),
	@sProuctCode VARCHAR(15),
	@sProductName VARCHAR(500),
	@sAssetClassName VARCHAR(100),
	@sCurrencyCode VARCHAR(3),
	@sAmount VARCHAR(100),
	@sRmName VARCHAR(255),
	@bIsValid BIT,
	@sRemark VARCHAR(250)
)
AS
BEGIN
	UPDATE TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION SET
		psc_file_import_id = @iFileImportID,
		date = @sDate,
		branch_code = @sBranchCode,
		branch_name = @sBranchName,
		cif = @sCif,
		customer_name = @sCustomerName,
		prouct_code = @sProuctCode,
		product_name = @sProductName,
		asset_class_name = @sAssetClassName,
		currency_code = @sCurrencyCode,
		amount = @sAmount,
		rm_name = @sRmName,
		is_valid = @bIsValid,
		remark = @sRemark
	WHERE
      	tmpt_first_staging_psc_jatis_transaction_id = @iFirstStagingPscJatisTransactionID

	SELECT @@ERROR
END
