
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionRequiredMatrixList
	Desc    		:	This store procedure is use to get list of PSC_EXCEPTION_REQUIRED_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionRequiredMatrixList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsVc BIT = NULL,
	@bIsRiskMismatch BIT = NULL,
	@bExceptionRequireStatus BIT = NULL,
	@bIsActive BIT = NULL,
	@bIsDeleted BIT = NULL,
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
		perm0.psc_exception_required_matrix_id,
		perm0.is_vc,
		perm0.is_risk_mismatch,
		perm0.exception_require_status,
		perm0.is_active,
		perm0.is_deleted,
		perm0.create_date,
		perm0.create_by_user_id,
		perm0.update_date,
		perm0.update_by_user_id
	FROM
		psc_exception_required_matrix perm0 WITH (NOLOCK)
	WHERE
		(@bIsVc IS NULL OR perm0.is_vc = @bIsVc) AND
		(@bIsRiskMismatch IS NULL OR perm0.is_risk_mismatch = @bIsRiskMismatch) AND
		(@bExceptionRequireStatus IS NULL OR perm0.exception_require_status = @bExceptionRequireStatus) AND
		(@bIsActive IS NULL OR perm0.is_active = @bIsActive) AND
		(@bIsDeleted IS NULL OR perm0.is_deleted = @bIsDeleted) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, perm0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, perm0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR perm0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, perm0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, perm0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR perm0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL)
END
