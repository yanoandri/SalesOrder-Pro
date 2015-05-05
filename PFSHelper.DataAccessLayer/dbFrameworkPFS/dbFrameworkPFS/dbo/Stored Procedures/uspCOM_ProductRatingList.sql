
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductRatingList
	Desc    		:	This store procedure is use to get list of COM_PRODUCT_RATING
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductRatingList
(
	@sKeyWords VARCHAR(1280) = NULL
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
		(@sKeyWords IS NULL OR
		cpr0.rating_score LIKE '%' + @sKeyWords + '%' OR
		cpr0.description LIKE '%' + @sKeyWords + '%')
END
