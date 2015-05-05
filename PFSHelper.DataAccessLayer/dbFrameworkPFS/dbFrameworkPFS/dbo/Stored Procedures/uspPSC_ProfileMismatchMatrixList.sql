
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ProfileMismatchMatrixList
	Desc    		:	This store procedure is use to get list of PSC_PROFILE_MISMATCH_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ProfileMismatchMatrixList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iAssetClassID INT = NULL,
	@lProductRatingID BIGINT = NULL,
	@bIsActive BIT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL
)
AS
BEGIN
	SELECT
		ppmm0.psc_profile_mismatch_matrix_id,
		ppmm0.com_asset_class_id,
		ppmm0.com_product_rating_id,
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
		(@iAssetClassID IS NULL OR ppmm0.com_asset_class_id = @iAssetClassID) AND
		(@lProductRatingID IS NULL OR ppmm0.com_product_rating_id = @lProductRatingID) AND
		(@bIsActive IS NULL OR ppmm0.is_active = @bIsActive) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, ppmm0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, ppmm0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR ppmm0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, ppmm0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, ppmm0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR ppmm0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL)
END
