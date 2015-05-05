
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionFormDelete
	Desc    		:	This store procedure is use to delete PSC_EXCEPTION_FORM
	Create Date 	:	21 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ExceptionFormDelete
(
	@iExceptionFormID INT
)
AS
BEGIN
	DELETE PSC_EXCEPTION_FORM
    WHERE PSC_EXCEPTION_FORM_ID = @iExceptionFormID
END
