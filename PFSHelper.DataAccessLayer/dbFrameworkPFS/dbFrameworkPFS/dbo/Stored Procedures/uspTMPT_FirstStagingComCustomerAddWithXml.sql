/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscRmwCipAdd
	Desc    		:	This store procedure is use to add TMPT_FIRST_STAGING_PSC_RMW_CIP
	Create Date 	:	19 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspTMPT_FirstStagingComCustomerAddWithXml]
(
	@iFileImportID INT,
	@sXml XML
)
AS
BEGIN
    
	INSERT INTO TMPT_FIRST_STAGING_COM_CUSTOMER WITH(ROWLOCK)
    ( 	
		psc_file_import_id,
		cif,
		customer_dob,
		branch_code,
		branch_name,
		control_center,
		education_name,
		full_name
	)
	SELECT
		  @iFileImportID,
	      TXM.M.value('@CIF', 'varchar(100)'),
		  TXM.M.value('@CUSTOMER_DOB', 'varchar(100)'),
	      TXM.M.value('@BRANCH_CODE', 'varchar(100)'),
		  TXM.M.value('@BRANCH_NAME', 'varchar(100)'),
	      TXM.M.value('@CONTROL_CENTER', 'varchar(100)'),
		  TXM.M.value('@EDUCATION_NAME', 'varchar(100)'),
		  TXM.M.value('@FULL_NAME', 'varchar(100)')
	FROM        
		@sXml.nodes('/FIRST_STAGING_CIF_MASTER/MEMBER') AS TXM(M)
    
END


