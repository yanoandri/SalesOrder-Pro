/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ProfileMismatchMatrixListByAssetClassID
	Desc    		:	This store procedure is use to get list of PSC_PROFILE_MISMATCH_MATRIX
	Create Date 	:	27 Jan 2015		- Created By  : mtoha
	Modified Date 	:	            	- Modified By : 
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ProfileMismatchMatrixListByAssetClassID]
(
	@iAssetClassID INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT
		ppmm0.psc_profile_mismatch_matrix_id,
		ppmm0.com_asset_class_id,
		ppmm0.com_product_rating_id,
		cpr2.RATING_SCORE,
		ppmm0.operator_id_yes,
		ppmm0.value_no_percent,
		ppmm0.operator_id_no,
		ppmm0.value_yes_percent,
		ppmm0.is_active,
		ppmm0.create_date,
		ppmm0.create_by_user_id,
		ppmm0.update_date,
		ppmm0.update_by_user_id,
		cac1.asset_class_code,
		cac1.asset_class_name
	FROM
		psc_profile_mismatch_matrix ppmm0 WITH (NOLOCK),
		com_asset_class cac1 WITH (NOLOCK),
		com_product_rating cpr2 WITH (NOLOCK)
	WHERE
		ppmm0.com_asset_class_id = cac1.com_asset_class_id AND
		ppmm0.com_product_rating_id = cpr2.com_product_rating_id AND
		(@iAssetClassID IS NULL OR ppmm0.com_asset_class_id = @iAssetClassID)
END
