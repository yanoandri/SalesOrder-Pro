/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductRatingAdd
	Desc    		:	This store procedure is use to add COM_PRODUCT_RATING
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductRatingAdd
(
	@sRatingScore VARCHAR(5),
	@sDescription VARCHAR(255)
)
AS
BEGIN
	DECLARE @iProductRatingID INT
    
	INSERT INTO COM_PRODUCT_RATING 
    ( 	
		rating_score,
		description
	)
	VALUES
	(
		@sRatingScore,
		@sDescription
	)
    
	SET @iProductRatingID = ISNULL(@@IDENTITY, 0)
	SELECT @iProductRatingID
END
