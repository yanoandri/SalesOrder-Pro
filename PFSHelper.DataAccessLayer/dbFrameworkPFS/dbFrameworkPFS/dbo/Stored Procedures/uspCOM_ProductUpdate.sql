
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductUpdate
	Desc    		:	This store procedure is use to update COM_PRODUCT
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductUpdate
(
	@iProductID INT,
	@sProductName VARCHAR(500),
	@sProductCode VARCHAR(15),
	@iProductRatingID INT,
	@iPscCustomerObjective1ID INT,
	@iPscCustomerObjective2ID INT,
	@iPscCustomerObjective3ID INT,
	@iPscCustomerObjective4ID INT,
	@iPscCustomerObjective5ID INT,
	@iPscCustomerObjective6ID INT,
	@iAssetClassID INT,
	@sIthFrom VARCHAR(3),
	@sIthTo VARCHAR(3),
	@bIsActive BIT,
	@bIsDeleted BIT,
	@bIsNeedApproval BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT,
	@sFundHouse VARCHAR(100),
	@sCurrencyCode VARCHAR(3)
)
AS
BEGIN
	UPDATE COM_PRODUCT SET
		product_name = @sProductName,
		product_code = @sProductCode,
		com_product_rating_id = @iProductRatingID,
		psc_customer_objective1_id = @iPscCustomerObjective1ID,
		psc_customer_objective2_id = @iPscCustomerObjective2ID,
		psc_customer_objective3_id = @iPscCustomerObjective3ID,
		psc_customer_objective4_id = @iPscCustomerObjective4ID,
		psc_customer_objective5_id = @iPscCustomerObjective5ID,
		psc_customer_objective6_id = @iPscCustomerObjective6ID,
		com_asset_class_id = @iAssetClassID,
		ith_from = @sIthFrom,
		ith_to = @sIthTo,
		is_active = @bIsActive,
		is_deleted = @bIsDeleted,
		is_need_approval = @bIsNeedApproval,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID,
		fund_house = @sFundHouse,
		currency_code = @sCurrencyCode
	WHERE
      	com_product_id = @iProductID

	SELECT @@ERROR
END
