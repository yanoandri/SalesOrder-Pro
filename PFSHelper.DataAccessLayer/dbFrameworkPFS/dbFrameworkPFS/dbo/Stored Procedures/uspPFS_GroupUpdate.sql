/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_GroupUpdate
	Desc    		:	This store procedure is use to update PFS_GROUP
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_GroupUpdate]
(
	@iGroupID INT,
	@sGroupName VARCHAR(30),
	@sGroupDescr VARCHAR(1280),
	@bIsActive BIT,
	@bIsNeedApproval BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN

	UPDATE [PFS_GROUP] SET
		group_name = @sGroupName,
		group_descr = @sGroupDescr,
		is_active = @bIsActive,
		is_need_approval = @bIsNeedApproval,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	pfs_group_id = @iGroupID
			
	SELECT @@ERROR		
END
