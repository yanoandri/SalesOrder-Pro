/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionAdd
	Desc    		:	This store procedure is use to add PSC_JATIS_TRANSACTION
	Create Date 	:	11 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_JatisTransactionAdd
(
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
	DECLARE @iJatisTransactionID INT
    
	INSERT INTO PSC_JATIS_TRANSACTION 
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
		is_with_exception,
		com_rm_id,
		psc_rmw_cip_id,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@iFileImportID,
		@dtDate,
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
		@bIsWithException,
		@iRmID,
		@iRmwCipID,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iJatisTransactionID = ISNULL(@@IDENTITY, 0)
	SELECT @iJatisTransactionID
END
