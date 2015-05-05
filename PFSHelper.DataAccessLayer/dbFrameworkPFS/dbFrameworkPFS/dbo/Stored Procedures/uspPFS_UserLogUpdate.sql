/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLogUpdate
	Desc    		:	This store procedure is use to update PFS_USER_LOG
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLogUpdate]
(
	@lUserLogID BIGINT,
	@sUserName VARCHAR(50),
	@sReferenceNumber VARCHAR(25),
	@sIpAddress VARCHAR(50),
	@dtLogDate DATETIME,
	@sDescription VARCHAR(1280),
	@xmlDetail XML,
	@iStatus SMALLINT,
	@iModuleObjectMemberID INT,
	@bIsPurge BIT,
	@xmlPreviousDetail XML
)
AS
BEGIN
	UPDATE PFS_USER_LOG SET
		user_name = @sUserName,
		reference_number = @sReferenceNumber,
		ip_address = @sIpAddress,
		log_date = @dtLogDate,
		description = @sDescription,
		detail = @xmlDetail,
		status = @iStatus,
		pfs_module_object_member_id = @iModuleObjectMemberID,
		is_purge = @bIsPurge,
		previous_detail = @xmlPreviousDetail
	WHERE
      	pfs_user_log_id = @lUserLogID

	SELECT @@ERROR
END
