/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingPscJatisTransactionAdd
	Desc    		:	This store procedure is use to add TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION
	Create Date 	:	11 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingPscJatisTransactionAdd
(
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
	DECLARE @iSecondStagingPscJatisTransactionID INT
    
	INSERT INTO TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION 
    ( 	
		psc_file_import_id,
		date,
		branch_id,
		branch_code,
		branch_name,
		com_customer_id,
		cif,
		customer_name,
		product_id,
		product_code,
		product_name,
		asset_class_id,
		com_currency_id,
		amount,
		com_rm_id,
		psc_rmw_cip_id,
		is_valid,
		invalid_remark
	)
	VALUES
	(
		@iFileImportID,
		@sDate,
		@iBranchID,
		@sBranchCode,
		@sBranchName,
		@iCustomerID,
		@sCif,
		@sCustomerName,
		@iProductID,
		@sProductCode,
		@sProductName,
		@iAssetClassID,
		@iCurrencyID,
		@dAmount,
		@iRmID,
		@iRmwCipID,
		@bIsValid,
		@sInvalidRemark
	)
    
	SET @iSecondStagingPscJatisTransactionID = ISNULL(@@IDENTITY, 0)
	SELECT @iSecondStagingPscJatisTransactionID
END
