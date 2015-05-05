
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerRatingVsProductRatingGet
	Desc    		:	This store procedure is use to get PSC_CUSTOMER_RATING_VS_PRODUCT_RATING by id
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerRatingVsProductRatingGet
(
	@iCustomerRatingVsProductRatingID INT
)
AS
BEGIN
	SELECT
		pcrvpr0.psc_customer_rating_vs_product_rating_id,
		pcrvpr0.com_customer_risk_rating_id,
		pcrvpr0.product_rating_to_with_exception,
		pcrvpr0.product_rating_to_with_no_exception,
		pcrvpr0.is_active,
		pcrvpr0.create_date,
		pcrvpr0.create_by_user_id,
		pcrvpr0.update_date,
		pcrvpr0.update_by_user_id
	FROM
		psc_customer_rating_vs_product_rating pcrvpr0 WITH (NOLOCK),
		com_customer_risk_rating ccrr1 WITH (NOLOCK)
	WHERE
		pcrvpr0.com_customer_risk_rating_id = ccrr1.com_customer_risk_rating_id AND
		pcrvpr0.psc_customer_rating_vs_product_rating_id = @iCustomerRatingVsProductRatingID
END
