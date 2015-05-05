/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerRatingVsProductRatingAdd
	Desc    		:	This store procedure is use to add PSC_CUSTOMER_RATING_VS_PRODUCT_RATING
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerRatingVsProductRatingAdd
(
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
	DECLARE @iCustomerRatingVsProductRatingID INT
    
	INSERT INTO PSC_CUSTOMER_RATING_VS_PRODUCT_RATING 
    ( 	
		com_customer_risk_rating_id,
		product_rating_to_with_exception,
		product_rating_to_with_no_exception,
		is_active,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@iCustomerRiskRatingID,
		@sProductRatingToWithException,
		@sProductRatingToWithNoException,
		@bIsActive,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iCustomerRatingVsProductRatingID = ISNULL(@@IDENTITY, 0)
	SELECT @iCustomerRatingVsProductRatingID
END
