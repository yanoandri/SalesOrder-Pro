

/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ProfileMismatchMatrixUpdateByAssetClass
	Desc    		:	This store procedure is use to update PSC_PROFILE_MISMATCH_MATRIX
	Create Date 	:	27 Jan 2015		- Created By  : mtoha
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ProfileMismatchMatrixUpdateByAssetClass]
(
	@iAssetClassID INT,
	@iOperatorIDYes INT,
	@dValueNoPercent FLOAT,
	@iOperatorIDNo INT,
	@dValueYesPercent FLOAT,
	@bIsActive BIT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_PROFILE_MISMATCH_MATRIX SET
		operator_id_yes = @iOperatorIDYes,
		value_no_percent = @dValueNoPercent,
		operator_id_no = @iOperatorIDNo,
		value_yes_percent = @dValueYesPercent,
		is_active = @bIsActive,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	com_asset_class_id = @iAssetClassID

	SELECT @@ERROR
END
