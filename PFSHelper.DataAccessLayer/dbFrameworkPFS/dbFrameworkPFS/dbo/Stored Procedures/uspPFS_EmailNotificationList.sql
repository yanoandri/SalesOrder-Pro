
/***********************************************************************************************************************
   Copyright (c) 2014 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_EmailNotificationList
	Desc    		:	This store procedure is use to get list of PFS_EMAIL_NOTIFICATION
	Create Date 	:	22 Oct 2014		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_EmailNotificationList
(
	@sKeyWords VARCHAR(1280) = NULL
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
		(@sKeyWords IS NULL OR
		pen0.type LIKE '%' + @sKeyWords + '%' OR
		pen0.keyword LIKE '%' + @sKeyWords + '%')
END
