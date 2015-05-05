/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_GroupUpdateByApprovalStatus
	Desc    		:	This store procedure is use to update PFS_GROUP
	Create Date 	:	03 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	03 Nov 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
						uspPFS_GroupUpdateByApprovalStatus
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_GroupUpdateByApprovalStatus]
(
	@iGroupID INT,
	@bIsNeedApproval BIT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN

	IF(@bIsNeedApproval=1)
	BEGIN
	
		UPDATE [PFS_GROUP] SET
			is_need_approval = @bIsNeedApproval
		WHERE
      		pfs_group_id = @iGroupID	
	END
	ELSE	
	BEGIN
	
		UPDATE [PFS_GROUP] SET
			is_need_approval = @bIsNeedApproval,
			update_date = @dtUpdateDate,
			update_by_user_id = @iUpdateByUserID
		WHERE
      		pfs_group_id = @iGroupID
	END
	
	SELECT @@ERROR		
	
END
