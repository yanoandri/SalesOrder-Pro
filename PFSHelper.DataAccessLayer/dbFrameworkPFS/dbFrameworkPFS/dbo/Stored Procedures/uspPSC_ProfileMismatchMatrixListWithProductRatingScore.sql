
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPSC_ProfileMismatchMatrixListWithProductRatingScore]
	Desc    		:	This store procedure is use to get list of PSC_PROFILE_MISMATCH_MATRIX
	Create Date 	:	mtoha - 2015-Jan-19
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ProfileMismatchMatrixListWithProductRatingScore]
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		ppmm.psc_profile_mismatch_matrix_id,
		ppmm.com_asset_class_id,
		ppmm.com_product_rating_id,
		ppmm.operator_id_yes,
		ppmm.value_no_percent,
		ppmm.operator_id_no,
		ppmm.value_yes_percent,
		ppmm.is_active,
		ppmm.create_date,
		ppmm.create_by_user_id,
		ppmm.update_date,
		ppmm.update_by_user_id,
		cac.asset_class_code,
		cac.asset_class_name,
		cpr.RATING_SCORE
	FROM
		psc_profile_mismatch_matrix ppmm WITH (NOLOCK),
		com_asset_class cac WITH (NOLOCK),
		com_product_rating cpr WITH (NOLOCK)
	WHERE
		ppmm.com_asset_class_id = cac.com_asset_class_id 
		AND	ppmm.com_product_rating_id = cpr.com_product_rating_id 
	ORDER BY 
		ppmm.com_asset_class_id,
		ppmm.com_product_rating_id
END
