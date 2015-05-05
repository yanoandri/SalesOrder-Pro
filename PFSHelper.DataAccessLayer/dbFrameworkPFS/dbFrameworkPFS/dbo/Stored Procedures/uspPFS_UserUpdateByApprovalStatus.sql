/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	spPFS_UserUpdate
	Desc    		:	This store procedure is use to update PFS_USER
	Create Date 	:	13 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	13 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	: 
						uspPFS_UserUpdateForNeedApproval 52,0,'2011-10-29',52
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserUpdateByApprovalStatus]
(
	@iUserID INT,
	@bIsNeedApproval BIT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN

	IF(@bIsNeedApproval=1)
	BEGIN
		UPDATE [PFS_USER] SET
			is_need_approval = @bIsNeedApproval
		WHERE
      		pfs_user_id = @iUserID
	END
	ELSE
	BEGIN
		UPDATE [PFS_USER] SET
			is_need_approval = @bIsNeedApproval,
			update_date = @dtUpdateDate,
			update_by_user_id = @iUpdateByUserID
		WHERE
      		pfs_user_id = @iUserID
	END
	select @@ERROR
			
END
