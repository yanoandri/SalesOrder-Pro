
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductGetWithCustomer
	Desc    		:	This store procedure is use to get COM_PRODUCT by id
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductGetWithCustomer
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
		pco1.CUSTOMER_OBJECTIVE_NAME,
		cp0.psc_customer_objective2_id,
		ISNULL(pco2.CUSTOMER_OBJECTIVE_NAME ,'') as CUSTOMER_OBJECTIVE_NAME2,
		cp0.psc_customer_objective3_id,
		ISNULL(pco3.CUSTOMER_OBJECTIVE_NAME ,'') as CUSTOMER_OBJECTIVE_NAME3,
		cp0.psc_customer_objective4_id,
		ISNULL(pco4.CUSTOMER_OBJECTIVE_NAME ,'') as CUSTOMER_OBJECTIVE_NAME4,
		cp0.psc_customer_objective5_id,
		ISNULL(pco5.CUSTOMER_OBJECTIVE_NAME ,'') as CUSTOMER_OBJECTIVE_NAME5,
		cp0.psc_customer_objective6_id,
		ISNULL(pco6.CUSTOMER_OBJECTIVE_NAME ,'') as CUSTOMER_OBJECTIVE_NAME6,
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
		cac2.asset_class_name,
		cpr1.RATING_SCORE
	FROM
		com_product cp0 
		INNER JOIN com_product_rating cpr1 ON cp0.COM_PRODUCT_RATING_ID = cpr1.COM_PRODUCT_RATING_ID 
		INNER JOIN com_asset_class cac2 ON cp0.COM_ASSET_CLASS_ID = cac2.COM_ASSET_CLASS_ID
		INNER JOIN PSC_CUSTOMER_OBJECTIVE pco1 ON cp0.PSC_CUSTOMER_OBJECTIVE1_ID = pco1.PSC_CUSTOMER_OBJECTIVE_ID
		LEFT JOIN PSC_CUSTOMER_OBJECTIVE pco2 ON cp0.PSC_CUSTOMER_OBJECTIVE2_ID = pco2.PSC_CUSTOMER_OBJECTIVE_ID
		LEFT JOIN PSC_CUSTOMER_OBJECTIVE pco3 ON cp0.PSC_CUSTOMER_OBJECTIVE3_ID  = pco3.PSC_CUSTOMER_OBJECTIVE_ID
		LEFT JOIN PSC_CUSTOMER_OBJECTIVE pco4 ON cp0.PSC_CUSTOMER_OBJECTIVE4_ID  = pco4.PSC_CUSTOMER_OBJECTIVE_ID
		LEFT JOIN PSC_CUSTOMER_OBJECTIVE pco5 ON cp0.PSC_CUSTOMER_OBJECTIVE5_ID  = pco5.PSC_CUSTOMER_OBJECTIVE_ID
		LEFT JOIN PSC_CUSTOMER_OBJECTIVE pco6 ON cp0.PSC_CUSTOMER_OBJECTIVE6_ID  = pco6.PSC_CUSTOMER_OBJECTIVE_ID
	WHERE
		cp0.com_product_id = @iProductID
END
