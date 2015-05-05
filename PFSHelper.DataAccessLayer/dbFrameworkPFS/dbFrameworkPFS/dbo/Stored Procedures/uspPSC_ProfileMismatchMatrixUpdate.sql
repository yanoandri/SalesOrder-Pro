
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ProfileMismatchMatrixUpdate
	Desc    		:	This store procedure is use to update PSC_PROFILE_MISMATCH_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ProfileMismatchMatrixUpdate
(
	@iProfileMismatchMatrixID INT,
	@iAssetClassID INT,
	@lProductRatingID BIGINT,
	@iOperatorIDYes INT,
	@dValueNoPercent FLOAT,
	@iOperatorIDNo INT,
	@dValueYesPercent FLOAT,
	@bIsActive BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_PROFILE_MISMATCH_MATRIX SET
		com_asset_class_id = @iAssetClassID,
		com_product_rating_id = @lProductRatingID,
		operator_id_yes = @iOperatorIDYes,
		value_no_percent = @dValueNoPercent,
		operator_id_no = @iOperatorIDNo,
		value_yes_percent = @dValueYesPercent,
		is_active = @bIsActive,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	psc_profile_mismatch_matrix_id = @iProfileMismatchMatrixID

	SELECT @@ERROR
END
