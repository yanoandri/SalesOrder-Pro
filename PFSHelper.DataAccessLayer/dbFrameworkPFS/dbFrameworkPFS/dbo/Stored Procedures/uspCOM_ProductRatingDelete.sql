
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductRatingDelete
	Desc    		:	This store procedure is use to delete COM_PRODUCT_RATING
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductRatingDelete
(
	@iProductRatingID INT
)
AS
BEGIN
	DELETE COM_PRODUCT_RATING
    WHERE COM_PRODUCT_RATING_ID = @iProductRatingID
END
