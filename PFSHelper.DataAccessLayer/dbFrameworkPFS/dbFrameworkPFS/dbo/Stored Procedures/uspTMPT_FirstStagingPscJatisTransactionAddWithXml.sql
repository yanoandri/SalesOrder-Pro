
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingJatisTransactionAddWithXml
	Desc    		:	This store procedure is use to add TMPT_FIRST_STAGING_PSC_RMW_CIP
	Create Date 	:	19 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspTMPT_FirstStagingPscJatisTransactionAddWithXml]
(
	@iFileImportID INT,
	@sXml XML
)
AS
BEGIN
    
	INSERT INTO TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION WITH(ROWLOCK)
    ( 	
		psc_file_import_id,
		date,
		branch_code,
		branch_name,
		cif,
		customer_name,
		prouct_code,
		product_name,
		currency_code,
		amount,
		rm_name
	)
	SELECT
		  @iFileImportID,
	      TXM.M.value('@DATE', 'varchar(100)'),
		  TXM.M.value('@BRANCH_CODE', 'varchar(100)'),
	      TXM.M.value('@BRANCH_NAME', 'varchar(100)'),
		  TXM.M.value('@CIF', 'varchar(100)'),
	      TXM.M.value('@CUSTOMER_NAME', 'varchar(100)'),
		  TXM.M.value('@PRODUCT_CODE', 'varchar(100)'),
	      TXM.M.value('@PRODUCT_NAME', 'varchar(100)'),
		  TXM.M.value('@CURRENCY_CODE', 'varchar(100)'),
		  TXM.M.value('@AMOUNT', 'varchar(100)'),
		  TXM.M.value('@RM_NAME', 'varchar(100)')
	FROM        
		@sXml.nodes('/FIRST_STAGING_JATIS_TRANSACTION/MEMBER') AS TXM(M)
    
END


