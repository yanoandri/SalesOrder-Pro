/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscJatisTransactionAdd
	Desc    		:	This store procedure is use to add TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingPscJatisTransactionAdd
(
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
	DECLARE @iFirstStagingPscJatisTransactionID INT
    
	INSERT INTO TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION 
    ( 	
		psc_file_import_id,
		date,
		branch_code,
		branch_name,
		cif,
		customer_name,
		prouct_code,
		product_name,
		asset_class_name,
		currency_code,
		amount,
		rm_name,
		is_valid,
		remark
	)
	VALUES
	(
		@iFileImportID,
		@sDate,
		@sBranchCode,
		@sBranchName,
		@sCif,
		@sCustomerName,
		@sProuctCode,
		@sProductName,
		@sAssetClassName,
		@sCurrencyCode,
		@sAmount,
		@sRmName,
		@bIsValid,
		@sRemark
	)
    
	SET @iFirstStagingPscJatisTransactionID = ISNULL(@@IDENTITY, 0)
	SELECT @iFirstStagingPscJatisTransactionID
END
