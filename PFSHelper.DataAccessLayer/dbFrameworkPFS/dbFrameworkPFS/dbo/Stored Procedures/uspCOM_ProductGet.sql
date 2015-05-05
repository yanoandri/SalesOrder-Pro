
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductGet
	Desc    		:	This store procedure is use to get COM_PRODUCT by id
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductGet
(
	@iProductID INT
)
AS
BEGIN
	SELECT
		cp0.com_product_id,
		cp0.product_name,
		cp0.product_code,
		cp0.com_product_rating_id,
		cp0.psc_customer_objective1_id,
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
		cp0.is_need_approval,
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
		com_asset_class cac2 WITH (NOLOCK)
	WHERE
		cp0.com_product_rating_id = cpr1.com_product_rating_id AND
		cp0.com_asset_class_id = cac2.com_asset_class_id AND
		cp0.com_product_id = @iProductID
END
