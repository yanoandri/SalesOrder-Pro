/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingComCustomerAdd
	Desc    		:	This store procedure is use to add TMPT_FIRST_STAGING_COM_CUSTOMER
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingComCustomerAdd
(
	@iFileImportID INT,
	@sCif VARCHAR(15),
	@sCustomerDob VARCHAR(20),
	@sBranchCode VARCHAR(20),
	@sBranchName VARCHAR(100),
	@sControlCenter VARCHAR(5),
	@sEducationName VARCHAR(50),
	@sFullName VARCHAR(255),
	@bIsValid BIT,
	@sRemark VARCHAR(250)
)
AS
BEGIN
	DECLARE @iFirstStagingComCustomerID INT
    
	INSERT INTO TMPT_FIRST_STAGING_COM_CUSTOMER 
    ( 	
		psc_file_import_id,
		cif,
		customer_dob,
		branch_code,
		branch_name,
		control_center,
		education_name,
		full_name,
		is_valid,
		remark
	)
	VALUES
	(
		@iFileImportID,
		@sCif,
		@sCustomerDob,
		@sBranchCode,
		@sBranchName,
		@sControlCenter,
		@sEducationName,
		@sFullName,
		@bIsValid,
		@sRemark
	)
    
	SET @iFirstStagingComCustomerID = ISNULL(@@IDENTITY, 0)
	SELECT @iFirstStagingComCustomerID
END
