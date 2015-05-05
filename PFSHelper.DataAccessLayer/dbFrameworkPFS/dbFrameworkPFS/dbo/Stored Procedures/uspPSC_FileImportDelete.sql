
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_FileImportDelete
	Desc    		:	This store procedure is use to delete PSC_FILE_IMPORT
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_FileImportDelete
(
	@iFileImportID INT
)
AS
BEGIN
	DELETE PSC_FILE_IMPORT
    WHERE PSC_FILE_IMPORT_ID = @iFileImportID
END
