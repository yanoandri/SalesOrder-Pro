
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductRatingGet
	Desc    		:	This store procedure is use to get COM_PRODUCT_RATING by id
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductRatingGet
(
	@iProductRatingID INT
)
AS
BEGIN
	SELECT
		cpr0.com_product_rating_id,
		cpr0.rating_score,
		cpr0.description
	FROM
		com_product_rating cpr0 WITH (NOLOCK)
	WHERE
		cpr0.com_product_rating_id = @iProductRatingID
END
