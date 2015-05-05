
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CustomerUpdate
	Desc    		:	This store procedure is use to update COM_CUSTOMER
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_CustomerUpdate
(
	@iCustomerID INT,
	@iFileImportID INT,
	@sCif VARCHAR(15),
	@dtCustomerDob DATETIME,
	@sControlCenter VARCHAR(5),
	@iEducationID INT,
	@sFullName VARCHAR(255),
	@iBranchID INT,
	@sFieldReserve1 VARCHAR(100),
	@sFieldReserve2 VARCHAR(100),
	@sFieldReserve3 VARCHAR(100),
	@bIsActive BIT,
	@bIsDeleted BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE COM_CUSTOMER SET
		psc_file_import_id = @iFileImportID,
		cif = @sCif,
		customer_dob = @dtCustomerDob,
		control_center = @sControlCenter,
		com_education_id = @iEducationID,
		full_name = @sFullName,
		com_branch_id = @iBranchID,
		field_reserve_1 = @sFieldReserve1,
		field_reserve_2 = @sFieldReserve2,
		field_reserve_3 = @sFieldReserve3,
		is_active = @bIsActive,
		is_deleted = @bIsDeleted,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	com_customer_id = @iCustomerID

	SELECT @@ERROR
END
