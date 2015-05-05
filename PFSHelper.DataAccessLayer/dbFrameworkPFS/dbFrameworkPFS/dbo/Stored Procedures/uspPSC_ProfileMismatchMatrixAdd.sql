/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ProfileMismatchMatrixAdd
	Desc    		:	This store procedure is use to add PSC_PROFILE_MISMATCH_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ProfileMismatchMatrixAdd
(
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
	DECLARE @iProfileMismatchMatrixID INT
    
	INSERT INTO PSC_PROFILE_MISMATCH_MATRIX 
    ( 	
		com_asset_class_id,
		com_product_rating_id,
		operator_id_yes,
		value_no_percent,
		operator_id_no,
		value_yes_percent,
		is_active,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@iAssetClassID,
		@lProductRatingID,
		@iOperatorIDYes,
		@dValueNoPercent,
		@iOperatorIDNo,
		@dValueYesPercent,
		@bIsActive,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iProfileMismatchMatrixID = ISNULL(@@IDENTITY, 0)
	SELECT @iProfileMismatchMatrixID
END
