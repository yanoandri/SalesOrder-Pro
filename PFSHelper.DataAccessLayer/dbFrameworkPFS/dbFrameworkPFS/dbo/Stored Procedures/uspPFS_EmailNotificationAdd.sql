/***********************************************************************************************************************
   Copyright (c) 2014 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_EmailNotificationAdd
	Desc    		:	This store procedure is use to add PFS_EMAIL_NOTIFICATION
	Create Date 	:	22 Oct 2014		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_EmailNotificationAdd
(
	@sType VARCHAR(50),
	@sKeyword VARCHAR(255),
	@iPriority INT
)
AS
BEGIN
	DECLARE @iEmailNotificationID INT
    
	INSERT INTO PFS_EMAIL_NOTIFICATION 
    ( 	
		type,
		keyword,
		priority
	)
	VALUES
	(
		@sType,
		@sKeyword,
		@iPriority
	)
    
	SET @iEmailNotificationID = ISNULL(@@IDENTITY, 0)
	SELECT @iEmailNotificationID
END
