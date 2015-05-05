
/***********************************************************************************************************************
   Copyright (c) 2014 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_EmailNotificationGet
	Desc    		:	This store procedure is use to get PFS_EMAIL_NOTIFICATION by id
	Create Date 	:	22 Oct 2014		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_EmailNotificationGet
(
	@iEmailNotificationID INT
)
AS
BEGIN
	SELECT
		pen0.pfs_email_notification_id,
		pen0.type,
		pen0.keyword,
		pen0.priority
	FROM
		pfs_email_notification pen0 WITH (NOLOCK)
	WHERE
		pen0.pfs_email_notification_id = @iEmailNotificationID
END
