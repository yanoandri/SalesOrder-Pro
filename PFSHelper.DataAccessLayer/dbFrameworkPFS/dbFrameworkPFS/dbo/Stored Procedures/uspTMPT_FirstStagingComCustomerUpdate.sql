
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingComCustomerUpdate
	Desc    		:	This store procedure is use to update TMPT_FIRST_STAGING_COM_CUSTOMER
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingComCustomerUpdate
(
	@iFirstStagingComCustomerID INT,
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
	UPDATE TMPT_FIRST_STAGING_COM_CUSTOMER SET
		psc_file_import_id = @iFileImportID,
		cif = @sCif,
		customer_dob = @sCustomerDob,
		branch_code = @sBranchCode,
		branch_name = @sBranchName,
		control_center = @sControlCenter,
		education_name = @sEducationName,
		full_name = @sFullName,
		is_valid = @bIsValid,
		remark = @sRemark
	WHERE
      	tmpt_first_staging_com_customer_id = @iFirstStagingComCustomerID

	SELECT @@ERROR
END
