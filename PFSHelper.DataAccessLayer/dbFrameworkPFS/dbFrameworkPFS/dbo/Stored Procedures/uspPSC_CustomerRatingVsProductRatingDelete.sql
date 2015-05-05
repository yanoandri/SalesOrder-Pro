
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerRatingVsProductRatingDelete
	Desc    		:	This store procedure is use to delete PSC_CUSTOMER_RATING_VS_PRODUCT_RATING
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerRatingVsProductRatingDelete
(
	@iCustomerRatingVsProductRatingID INT
)
AS
BEGIN
	DELETE PSC_CUSTOMER_RATING_VS_PRODUCT_RATING
    WHERE PSC_CUSTOMER_RATING_VS_PRODUCT_RATING_ID = @iCustomerRatingVsProductRatingID
END
