
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionRequiredMatrixGet
	Desc    		:	This store procedure is use to get PSC_EXCEPTION_REQUIRED_MATRIX by id
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionRequiredMatrixGet
(
	@iExceptionRequiredMatrixID INT
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
		perm0.psc_exception_required_matrix_id = @iExceptionRequiredMatrixID
END
