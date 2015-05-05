/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductAdd
	Desc    		:	This store procedure is use to add COM_PRODUCT
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductAdd
(
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
	DECLARE @iProductID INT
    
	INSERT INTO COM_PRODUCT 
    ( 	
		product_name,
		product_code,
		com_product_rating_id,
		psc_customer_objective1_id,
		psc_customer_objective2_id,
		psc_customer_objective3_id,
		psc_customer_objective4_id,
		psc_customer_objective5_id,
		psc_customer_objective6_id,
		com_asset_class_id,
		ith_from,
		ith_to,
		is_active,
		is_deleted,
		is_need_approval,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id,
		fund_house,
		currency_code
	)
	VALUES
	(
		@sProductName,
		@sProductCode,
		@iProductRatingID,
		@iPscCustomerObjective1ID,
		@iPscCustomerObjective2ID,
		@iPscCustomerObjective3ID,
		@iPscCustomerObjective4ID,
		@iPscCustomerObjective5ID,
		@iPscCustomerObjective6ID,
		@iAssetClassID,
		@sIthFrom,
		@sIthTo,
		@bIsActive,
		@bIsDeleted,
		@bIsNeedApproval,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID,
		@sFundHouse,
		@sCurrencyCode
	)
    
	SET @iProductID = ISNULL(@@IDENTITY, 0)
	SELECT @iProductID
END
