
/***********************************************************************************************************************
   Copyright (c) 2014 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_EmailNotificationUpdate
	Desc    		:	This store procedure is use to update PFS_EMAIL_NOTIFICATION
	Create Date 	:	22 Oct 2014		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_EmailNotificationUpdate
(
	@iEmailNotificationID INT,
	@sType VARCHAR(50),
	@sKeyword VARCHAR(255),
	@iPriority INT
)
AS
BEGIN
	UPDATE PFS_EMAIL_NOTIFICATION SET
		type = @sType,
		keyword = @sKeyword,
		priority = @iPriority
	WHERE
      	pfs_email_notification_id = @iEmailNotificationID

	SELECT @@ERROR
END
