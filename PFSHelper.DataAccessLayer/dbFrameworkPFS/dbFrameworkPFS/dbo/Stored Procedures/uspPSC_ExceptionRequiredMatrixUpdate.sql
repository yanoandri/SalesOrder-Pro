
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionRequiredMatrixUpdate
	Desc    		:	This store procedure is use to update PSC_EXCEPTION_REQUIRED_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionRequiredMatrixUpdate
(
	@iExceptionRequiredMatrixID INT,
	@bIsVc BIT,
	@bIsRiskMismatch BIT,
	@bExceptionRequireStatus BIT,
	@bIsActive BIT,
	@bIsDeleted BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_EXCEPTION_REQUIRED_MATRIX SET
		is_vc = @bIsVc,
		is_risk_mismatch = @bIsRiskMismatch,
		exception_require_status = @bExceptionRequireStatus,
		is_active = @bIsActive,
		is_deleted = @bIsDeleted,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	psc_exception_required_matrix_id = @iExceptionRequiredMatrixID

	SELECT @@ERROR
END
