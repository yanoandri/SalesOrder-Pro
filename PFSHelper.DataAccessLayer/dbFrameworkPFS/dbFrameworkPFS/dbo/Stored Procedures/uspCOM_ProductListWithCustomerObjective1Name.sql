
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductListWithCustomerObjective1Name
	Desc    		:	This store procedure is use to get list of COM_PRODUCT
	Create Date 	:	20 Jan 2015		- Created By  : mtoha
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ProductListWithCustomerObjective1Name]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iProductRatingID INT = NULL,
	@iPscCustomerObjective1ID INT = NULL,
	@sPscCustomerObjective1Name VARCHAR(1280) = NULL,
	@iPscCustomerObjective2ID INT = NULL,
	@iPscCustomerObjective3ID INT = NULL,
	@iPscCustomerObjective4ID INT = NULL,
	@iPscCustomerObjective5ID INT = NULL,
	@iPscCustomerObjective6ID INT = NULL,
	@iAssetClassID INT = NULL,
	@bIsActive BIT = NULL,
	@bIsDeleted BIT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL
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
		(@iPscCustomerObjective2ID IS NULL OR cp0.psc_customer_objective2_id = @iPscCustomerObjective2ID) AND
		(@iPscCustomerObjective3ID IS NULL OR cp0.psc_customer_objective3_id = @iPscCustomerObjective3ID) AND
		(@iPscCustomerObjective4ID IS NULL OR cp0.psc_customer_objective4_id = @iPscCustomerObjective4ID) AND
		(@iPscCustomerObjective5ID IS NULL OR cp0.psc_customer_objective5_id = @iPscCustomerObjective5ID) AND
		(@iPscCustomerObjective6ID IS NULL OR cp0.psc_customer_objective6_id = @iPscCustomerObjective6ID) AND
		(@iAssetClassID IS NULL OR cp0.com_asset_class_id = @iAssetClassID) AND
		(@bIsActive IS NULL OR cp0.is_active = @bIsActive) AND
		(@bIsDeleted IS NULL OR cp0.is_deleted = @bIsDeleted) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, cp0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, cp0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR cp0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, cp0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, cp0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR cp0.update_by_user_id = @iUpdateByUserID) AND
		(@sPscCustomerObjective1Name IS NULL OR pco.CUSTOMER_OBJECTIVE_NAME = @sPscCustomerObjective1Name) AND
		(@sKeyWords 
IS NULL OR
		cp0.product_name LIKE '%' + @sKeyWords + '%' OR
		cp0.product_code LIKE '%' + @sKeyWords + '%' OR
		cp0.ith_from LIKE '%' + @sKeyWords + '%' OR
		cp0.ith_to LIKE '%' + @sKeyWords + '%' OR
		cp0.fund_house LIKE '%' + @sKeyWords + '%' OR
		cp0.currency_code LIKE '%' + @sKeyWords + '%')
END
