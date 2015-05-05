
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionFormList
	Desc    		:	This store procedure is use to get list of PSC_EXCEPTION_FORM
	Create Date 	:	21 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionFormList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iBranchID INT = NULL,
	@iAssetClassID INT = NULL,
	@iProductRatingID INT = NULL,
	@dtExceptionDateFrom DATETIME = NULL,
	@dtExceptionDateTo DATETIME = NULL,
	@dtApprovedDateFrom DATETIME = NULL,
	@dtApprovedDateTo DATETIME = NULL,
	@dtExpiryDateFrom DATETIME = NULL,
	@dtExpiryDateTo DATETIME = NULL,
	@bIsActive BIT = NULL,
	@bIsDeleted BIT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL,
	@bIsNeedApproval BIT = NULL
)
AS
BEGIN
	SELECT
		pef0.psc_exception_form_id,
		pef0.com_branch_id,
		pef0.branch_name,
		pef0.cif,
		pef0.customer_full_name,
		pef0.com_asset_class_id,
		pef0.com_product_rating_id,
		pef0.exception_date,
		pef0.approved_date,
		pef0.expiry_date,
		pef0.is_active,
		pef0.is_deleted,
		pef0.create_date,
		pef0.create_by_user_id,
		pef0.update_date,
		pef0.update_by_user_id,
		pef0.is_need_approval,
		cb1.branch_code,
		cb1.branch_name,
		cac2.asset_class_code,
		cac2.asset_class_name
	FROM
		psc_exception_form pef0 WITH (NOLOCK),
		com_branch cb1 WITH (NOLOCK),
		com_asset_class cac2 WITH (NOLOCK),
		com_product_rating cpr3 WITH (NOLOCK)
	WHERE
		pef0.com_branch_id = cb1.com_branch_id AND
		pef0.com_asset_class_id = cac2.com_asset_class_id AND
		pef0.com_product_rating_id = cpr3.com_product_rating_id AND
		(@iBranchID IS NULL OR pef0.com_branch_id = @iBranchID) AND
		(@iAssetClassID IS NULL OR pef0.com_asset_class_id = @iAssetClassID) AND
		(@iProductRatingID IS NULL OR pef0.com_product_rating_id = @iProductRatingID) AND
		(@dtExceptionDateFrom IS NULL OR CONVERT(VARCHAR, pef0.exception_date, 12) >= CONVERT(VARCHAR, @dtExceptionDateFrom, 12)) AND
		(@dtExceptionDateTo IS NULL OR CONVERT(VARCHAR, pef0.exception_date, 12) <= CONVERT(VARCHAR, @dtExceptionDateTo, 12)) AND
		(@dtApprovedDateFrom IS NULL OR CONVERT(VARCHAR, pef0.approved_date, 12) >= CONVERT(VARCHAR, @dtApprovedDateFrom, 12)) AND
		(@dtApprovedDateTo IS NULL OR CONVERT(VARCHAR, pef0.approved_date, 12) <= CONVERT(VARCHAR, @dtApprovedDateTo, 12)) AND
		(@dtExpiryDateFrom IS NULL OR CONVERT(VARCHAR, pef0.expiry_date, 12) >= CONVERT(VARCHAR, @dtExpiryDateFrom, 12)) AND
		(@dtExpiryDateTo IS NULL OR CONVERT(VARCHAR, pef0.expiry_date, 12) <= CONVERT(VARCHAR, @dtExpiryDateTo, 12)) AND
		(@bIsActive IS NULL OR pef0.is_active = @bIsActive) AND
		(@bIsDeleted IS NULL OR pef0.is_deleted = @bIsDeleted) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, pef0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, pef0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR pef0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, pef0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, pef0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR pef0.update_by_user_id = @iUpdateByUserID) AND
		(@bIsNeedApproval IS NULL OR pef0.is_need_approval = @bIsNeedApproval) AND
		(@sKeyWords IS NULL OR
		pef0.branch_name LIKE '%' + @sKeyWords + '%' OR
		pef0.cif LIKE '%' + @sKeyWords + '%' OR
		pef0.customer_full_name LIKE '%' + @sKeyWords + '%')
END
