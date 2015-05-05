
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_EducationGet
	Desc    		:	This store procedure is use to get COM_EDUCATION by id
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_EducationGet
(
	@iEducationID INT
)
AS
BEGIN
	SELECT
		ce0.com_education_id,
		ce0.education_name,
		ce0.description
	FROM
		com_education ce0 WITH (NOLOCK)
	WHERE
		ce0.com_education_id = @iEducationID
END
