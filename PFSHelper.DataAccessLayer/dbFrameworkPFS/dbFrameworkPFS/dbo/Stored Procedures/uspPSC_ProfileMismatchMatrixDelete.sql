
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ProfileMismatchMatrixDelete
	Desc    		:	This store procedure is use to delete PSC_PROFILE_MISMATCH_MATRIX
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ProfileMismatchMatrixDelete
(
	@iProfileMismatchMatrixID INT
)
AS
BEGIN
	DELETE PSC_PROFILE_MISMATCH_MATRIX
    WHERE PSC_PROFILE_MISMATCH_MATRIX_ID = @iProfileMismatchMatrixID
END
