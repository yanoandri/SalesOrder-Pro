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
CREATE PROCEDURE [dbo].[uspPFS_GroupUpdateByRejection]
(
	@iGroupID INT
)
AS
BEGIN
	
		UPDATE [PFS_GROUP] SET
			is_need_approval = 0
		WHERE
      		pfs_group_id = @iGroupID	
	
	SELECT @@ERROR		
	
END
