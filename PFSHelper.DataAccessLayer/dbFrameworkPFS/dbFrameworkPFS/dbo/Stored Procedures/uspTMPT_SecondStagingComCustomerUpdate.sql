
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingComCustomerUpdate
	Desc    		:	This store procedure is use to update TMPT_SECOND_STAGING_COM_CUSTOMER
	Create Date 	:	21 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingComCustomerUpdate
(
	@iSecondStagingComCustomerID INT,
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
	UPDATE TMPT_SECOND_STAGING_COM_CUSTOMER SET
		psc_file_import_id = @iFileImportID,
		cif = @sCif,
		customer_dob = @sCustomerDob,
		control_center = @sControlCenter,
		com_education_id = @iEducationID,
		full_name = @sFullName,
		com_branch_id = @iBranchID,
		is_valid = @bIsValid,
		invalid_remark = @sInvalidRemark
	WHERE
      	tmpt_second_staging_com_customer_id = @iSecondStagingComCustomerID

	SELECT @@ERROR
END
