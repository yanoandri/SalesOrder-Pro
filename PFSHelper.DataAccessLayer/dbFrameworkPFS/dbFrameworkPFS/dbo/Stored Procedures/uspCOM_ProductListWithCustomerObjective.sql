
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductListWithCustomerObjective
	Desc    		:	This store procedure is use to get list of COM_PRODUCT
	Create Date 	:	20 Jan 2015		- Created By  : mtoha
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ProductListWithCustomerObjective]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iProductRatingID INT = NULL,
	@iPscCustomerObjective1ID INT = NULL,
	@sPscCustomerObjective1Name VARCHAR(1280) = NULL,
	@iAssetClassID INT = NULL,
	@bIsActive BIT = NULL,
	@bIsDeleted BIT = NULL,
	@bIsNeedApproval BIT = NULL 
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT
		cp0.com_product_id,
		cp0.product_name,
		cp0.product_code,
		cp0.com_product_rating_id,
		cpr1.RATING_SCORE,
		cp0.psc_customer_objective1_id,
		pco.CUSTOMER_OBJECTIVE_NAME,
		cp0.psc_customer_objective2_id,
		cp0.psc_customer_objective3_id,
		cp0.psc_customer_objective4_id,
		cp0.psc_customer_objective5_id,
		cp0.psc_customer_objective6_id,
		cp0.com_asset_class_id,
		cp0.ith_from,
		cp0.ith_to,
		cp0.is_active,
		cp0.is_deleted,
		cp0.create_date,
		cp0.create_by_user_id,
		cp0.update_date,
		cp0.update_by_user_id,
		cp0.fund_house,
		cp0.currency_code,
		cac2.asset_class_code,
		cac2.asset_class_name
	FROM
		com_product cp0 WITH (NOLOCK),
		com_product_rating cpr1 WITH (NOLOCK),
		com_asset_class cac2 WITH (NOLOCK),
		PSC_CUSTOMER_OBJECTIVE pco WITH (NOLOCK)
	WHERE
		cp0.com_product_rating_id = cpr1.com_product_rating_id AND
		cp0.com_asset_class_id = cac2.com_asset_class_id AND
		pco.PSC_CUSTOMER_OBJECTIVE_ID = cp0.PSC_CUSTOMER_OBJECTIVE1_ID AND
		(@iProductRatingID IS NULL OR cp0.com_product_rating_id = @iProductRatingID) AND
		(@iPscCustomerObjective1ID IS NULL OR cp0.psc_customer_objective1_id = @iPscCustomerObjective1ID) AND
		(@iAssetClassID IS NULL OR cp0.com_asset_class_id = @iAssetClassID) AND
		(@bIsActive IS NULL OR cp0.is_active = @bIsActive) AND
		(@bIsDeleted IS NULL OR cp0.is_deleted = @bIsDeleted) AND
		(@bIsNeedApproval IS NULL OR cp0.IS_NEED_APPROVAL = @bIsNeedApproval) AND
		(@sPscCustomerObjective1Name IS NULL OR pco.CUSTOMER_OBJECTIVE_NAME = @sPscCustomerObjective1Name) AND
		(@sKeyWords IS NULL OR
		cp0.product_name LIKE '%' + @sKeyWords + '%' OR
		cp0.product_code LIKE '%' + @sKeyWords + '%' OR
		cp0.ith_from LIKE '%' + @sKeyWords + '%' OR
		cp0.ith_to LIKE '%' + @sKeyWords + '%' OR
		cp0.fund_house LIKE '%' + @sKeyWords + '%' OR
		cp0.currency_code LIKE '%' + @sKeyWords + '%')
END
