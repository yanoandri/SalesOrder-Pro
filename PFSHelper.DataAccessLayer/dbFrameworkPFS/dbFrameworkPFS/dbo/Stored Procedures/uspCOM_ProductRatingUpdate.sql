
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductRatingUpdate
	Desc    		:	This store procedure is use to update COM_PRODUCT_RATING
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductRatingUpdate
(
	@iProductRatingID INT,
	@sRatingScore VARCHAR(5),
	@sDescription VARCHAR(255)
)
AS
BEGIN
	UPDATE COM_PRODUCT_RATING SET
		rating_score = @sRatingScore,
		description = @sDescription
	WHERE
      	com_product_rating_id = @iProductRatingID

	SELECT @@ERROR
END
