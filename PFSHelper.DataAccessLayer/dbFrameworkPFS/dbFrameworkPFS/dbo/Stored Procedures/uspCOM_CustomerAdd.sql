/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CustomerAdd
	Desc    		:	This store procedure is use to add COM_CUSTOMER
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_CustomerAdd
(
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
	DECLARE @iCustomerID INT
    
	INSERT INTO COM_CUSTOMER 
    ( 	
		psc_file_import_id,
		cif,
		customer_dob,
		control_center,
		com_education_id,
		full_name,
		com_branch_id,
		field_reserve_1,
		field_reserve_2,
		field_reserve_3,
		is_active,
		is_deleted,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@iFileImportID,
		@sCif,
		@dtCustomerDob,
		@sControlCenter,
		@iEducationID,
		@sFullName,
		@iBranchID,
		@sFieldReserve1,
		@sFieldReserve2,
		@sFieldReserve3,
		@bIsActive,
		@bIsDeleted,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iCustomerID = ISNULL(@@IDENTITY, 0)
	SELECT @iCustomerID
END
