
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_EducationUpdate
	Desc    		:	This store procedure is use to update COM_EDUCATION
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_EducationUpdate
(
	@iEducationID INT,
	@sEducationName VARCHAR(100),
	@sDescription VARCHAR(255)
)
AS
BEGIN
	UPDATE COM_EDUCATION SET
		education_name = @sEducationName,
		description = @sDescription
	WHERE
      	com_education_id = @iEducationID

	SELECT @@ERROR
END
