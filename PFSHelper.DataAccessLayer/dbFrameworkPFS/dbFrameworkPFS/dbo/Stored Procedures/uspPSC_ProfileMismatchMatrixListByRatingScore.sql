
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ProfileMismatchMatrixList
	Desc    		:	This store procedure is use to get list of PSC_PROFILE_MISMATCH_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	: EXEC uspPSC_ProfileMismatchMatrixListByRatingScore 'P1'
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ProfileMismatchMatrixListByRatingScore]
(
	@sRatingScore varchar(5)
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT
		ppmm0.operator_id_yes,
		ppmm0.value_no_percent,
		ppmm0.operator_id_no,
		ppmm0.value_yes_percent,
		ppmm0.is_active,
		cp.PRODUCT_NAME,
		cac1.ASSET_CLASS_NAME,
		cac1.COM_ASSET_CLASS_ID
	FROM
		psc_profile_mismatch_matrix ppmm0 WITH (NOLOCK),
		com_asset_class cac1 WITH (NOLOCK),
		com_product_rating cpr2 WITH (NOLOCK),
		COM_PRODUCT cp with(nolock)
	WHERE
		ppmm0.com_asset_class_id = cac1.com_asset_class_id AND
		ppmm0.com_product_rating_id = cpr2.com_product_rating_id AND
		cp.COM_PRODUCT_RATING_ID = cpr2.COM_PRODUCT_RATING_ID AND
		cac1.COM_ASSET_CLASS_ID = cp.COM_ASSET_CLASS_ID AND
		cpr2.RATING_SCORE = @sRatingScore AND
		ppmm0.IS_ACTIVE = 1 AND
		cp.IS_ACTIVE = 1 AND
		cp.IS_DELETED = 0 AND
		cp.IS_NEED_APPROVAL = 0
	ORDER by cac1.COM_ASSET_CLASS_ID asc
END
