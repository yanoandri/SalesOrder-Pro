
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_EducationDelete
	Desc    		:	This store procedure is use to delete COM_EDUCATION
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_EducationDelete
(
	@iEducationID INT
)
AS
BEGIN
	DELETE COM_EDUCATION
    WHERE COM_EDUCATION_ID = @iEducationID
END
