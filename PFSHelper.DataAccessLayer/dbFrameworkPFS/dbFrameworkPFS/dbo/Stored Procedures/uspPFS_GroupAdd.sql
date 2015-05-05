/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_GroupAdd
	Desc    		:	This store procedure is use to add PFS_GROUP
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_GroupAdd]
(
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

	DECLARE @iGroupID INT
	INSERT INTO [PFS_GROUP] 
    ( 	
		group_name,
		group_descr,
		is_active,
		is_need_approval,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@sGroupName,
		@sGroupDescr,
		@bIsActive,
		@bIsNeedApproval,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
	
	SET  @iGroupID = ISNULL(@@IDENTITY, 0)
	SELECT @iGroupID
	
END
