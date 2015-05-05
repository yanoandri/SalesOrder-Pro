/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionRequiredMatrixAdd
	Desc    		:	This store procedure is use to add PSC_EXCEPTION_REQUIRED_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionRequiredMatrixAdd
(
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
	DECLARE @iExceptionRequiredMatrixID INT
    
	INSERT INTO PSC_EXCEPTION_REQUIRED_MATRIX 
    ( 	
		is_vc,
		is_risk_mismatch,
		exception_require_status,
		is_active,
		is_deleted,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@bIsVc,
		@bIsRiskMismatch,
		@bExceptionRequireStatus,
		@bIsActive,
		@bIsDeleted,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iExceptionRequiredMatrixID = ISNULL(@@IDENTITY, 0)
	SELECT @iExceptionRequiredMatrixID
END
