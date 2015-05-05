/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_EducationAdd
	Desc    		:	This store procedure is use to add COM_EDUCATION
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_EducationAdd
(
	@sEducationName VARCHAR(100),
	@sDescription VARCHAR(255)
)
AS
BEGIN
	DECLARE @iEducationID INT
    
	INSERT INTO COM_EDUCATION 
    ( 	
		education_name,
		description
	)
	VALUES
	(
		@sEducationName,
		@sDescription
	)
    
	SET @iEducationID = ISNULL(@@IDENTITY, 0)
	SELECT @iEducationID
END
