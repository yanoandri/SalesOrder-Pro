/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLogDelete
	Desc    		:	This store procedure is use to delete PFS_USER_LOG
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLogDelete]
(
	@lUserLogID BIGINT
)
AS
BEGIN
	DELETE PFS_USER_LOG
    WHERE PFS_USER_LOG_ID = @lUserLogID
END
