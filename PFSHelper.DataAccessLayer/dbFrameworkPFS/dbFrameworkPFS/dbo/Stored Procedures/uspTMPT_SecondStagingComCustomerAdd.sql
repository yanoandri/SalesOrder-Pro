/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingComCustomerAdd
	Desc    		:	This store procedure is use to add TMPT_SECOND_STAGING_COM_CUSTOMER
	Create Date 	:	21 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingComCustomerAdd
(
	@iFileImportID INT,
	@sCif VARCHAR(15),
	@sCustomerDob VARCHAR(20),
	@sControlCenter VARCHAR(5),
	@iEducationID INT,
	@sFullName VARCHAR(255),
	@iBranchID INT,
	@bIsValid BIT,
	@sInvalidRemark VARCHAR(500)
)
AS
BEGIN
	DECLARE @iSecondStagingComCustomerID INT
    
	INSERT INTO TMPT_SECOND_STAGING_COM_CUSTOMER 
    ( 	
		psc_file_import_id,
		cif,
		customer_dob,
		control_center,
		com_education_id,
		full_name,
		com_branch_id,
		is_valid,
		invalid_remark
	)
	VALUES
	(
		@iFileImportID,
		@sCif,
		@sCustomerDob,
		@sControlCenter,
		@iEducationID,
		@sFullName,
		@iBranchID,
		@bIsValid,
		@sInvalidRemark
	)
    
	SET @iSecondStagingComCustomerID = ISNULL(@@IDENTITY, 0)
	SELECT @iSecondStagingComCustomerID
END
