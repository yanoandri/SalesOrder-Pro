/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionFormAdd
	Desc    		:	This store procedure is use to add PSC_EXCEPTION_FORM
	Create Date 	:	21 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionFormAdd
(
	@iBranchID INT,
	@sBranchName VARCHAR(100),
	@sCif VARCHAR(15),
	@sCustomerFullName VARCHAR(255),
	@iAssetClassID INT,
	@iProductRatingID INT,
	@dtExceptionDate DATETIME,
	@dtApprovedDate DATETIME,
	@dtExpiryDate DATETIME,
	@bIsActive BIT,
	@bIsDeleted BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT,
	@bIsNeedApproval BIT
)
AS
BEGIN
	DECLARE @iExceptionFormID INT
    
	INSERT INTO PSC_EXCEPTION_FORM 
    ( 	
		com_branch_id,
		branch_name,
		cif,
		customer_full_name,
		com_asset_class_id,
		com_product_rating_id,
		exception_date,
		approved_date,
		expiry_date,
		is_active,
		is_deleted,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id,
		is_need_approval
	)
	VALUES
	(
		@iBranchID,
		@sBranchName,
		@sCif,
		@sCustomerFullName,
		@iAssetClassID,
		@iProductRatingID,
		@dtExceptionDate,
		@dtApprovedDate,
		@dtExpiryDate,
		@bIsActive,
		@bIsDeleted,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID,
		@bIsNeedApproval
	)
    
	SET @iExceptionFormID = ISNULL(@@IDENTITY, 0)
	SELECT @iExceptionFormID
END
