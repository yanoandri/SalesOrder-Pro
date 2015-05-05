
/***********************************************************************************************************************
   Copyright (c) 2014 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_EmailNotificationDelete
	Desc    		:	This store procedure is use to delete PFS_EMAIL_NOTIFICATION
	Create Date 	:	22 Oct 2014		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_EmailNotificationDelete
(
	@iEmailNotificationID INT
)
AS
BEGIN
	DELETE PFS_EMAIL_NOTIFICATION
    WHERE PFS_EMAIL_NOTIFICATION_ID = @iEmailNotificationID
END
