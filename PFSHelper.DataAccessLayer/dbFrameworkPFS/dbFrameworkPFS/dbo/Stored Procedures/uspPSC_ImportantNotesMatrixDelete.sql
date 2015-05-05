
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ImportantNotesMatrixDelete
	Desc    		:	This store procedure is use to delete PSC_IMPORTANT_NOTES_MATRIX
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ImportantNotesMatrixDelete
(
	@iImportantNotesMatrixID INT
)
AS
BEGIN
	DELETE PSC_IMPORTANT_NOTES_MATRIX
    WHERE PSC_IMPORTANT_NOTES_MATRIX_ID = @iImportantNotesMatrixID
END
