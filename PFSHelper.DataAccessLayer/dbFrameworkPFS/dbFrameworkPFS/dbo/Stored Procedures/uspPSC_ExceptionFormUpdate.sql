
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionFormUpdate
	Desc    		:	This store procedure is use to update PSC_EXCEPTION_FORM
	Create Date 	:	21 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionFormUpdate
(
	@iExceptionFormID INT,
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
	UPDATE PSC_EXCEPTION_FORM SET
		com_branch_id = @iBranchID,
		branch_name = @sBranchName,
		cif = @sCif,
		customer_full_name = @sCustomerFullName,
		com_asset_class_id = @iAssetClassID,
		com_product_rating_id = @iProductRatingID,
		exception_date = @dtExceptionDate,
		approved_date = @dtApprovedDate,
		expiry_date = @dtExpiryDate,
		is_active = @bIsActive,
		is_deleted = @bIsDeleted,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID,
		is_need_approval = @bIsNeedApproval
	WHERE
      	psc_exception_form_id = @iExceptionFormID

	SELECT @@ERROR
END
