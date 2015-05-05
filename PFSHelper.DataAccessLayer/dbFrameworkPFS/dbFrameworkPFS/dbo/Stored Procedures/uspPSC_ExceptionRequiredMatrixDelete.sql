
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionRequiredMatrixDelete
	Desc    		:	This store procedure is use to delete PSC_EXCEPTION_REQUIRED_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionRequiredMatrixDelete
(
	@iExceptionRequiredMatrixID INT
)
AS
BEGIN
	DELETE PSC_EXCEPTION_REQUIRED_MATRIX
    WHERE PSC_EXCEPTION_REQUIRED_MATRIX_ID = @iExceptionRequiredMatrixID
END
