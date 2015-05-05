
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerRatingVsProductRatingUpdate
	Desc    		:	This store procedure is use to update PSC_CUSTOMER_RATING_VS_PRODUCT_RATING
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerRatingVsProductRatingUpdate
(
	@iCustomerRatingVsProductRatingID INT,
	@iCustomerRiskRatingID INT,
	@sProductRatingToWithException VARCHAR(25),
	@sProductRatingToWithNoException VARCHAR(25),
	@bIsActive BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_CUSTOMER_RATING_VS_PRODUCT_RATING SET
		com_customer_risk_rating_id = @iCustomerRiskRatingID,
		product_rating_to_with_exception = @sProductRatingToWithException,
		product_rating_to_with_no_exception = @sProductRatingToWithNoException,
		is_active = @bIsActive,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	psc_customer_rating_vs_product_rating_id = @iCustomerRatingVsProductRatingID

	SELECT @@ERROR
END
