/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGroupAdd
	Desc    		:	This store procedure is use to add PFS_USER_GROUP
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserGroupAdd]
(
	@iUserID INT,
	@iGroupID INT
)
AS
BEGIN

	DECLARE @iUserGroupID INT
	INSERT INTO [PFS_USER_GROUP] 
    ( 	
		pfs_user_id,
		pfs_group_id
	)
	VALUES
	(
		@iUserID,
		@iGroupID
	)
	
	SET  @iUserGroupID = ISNULL(@@IDENTITY, 0)
	SELECT @iUserGroupID
	
END
