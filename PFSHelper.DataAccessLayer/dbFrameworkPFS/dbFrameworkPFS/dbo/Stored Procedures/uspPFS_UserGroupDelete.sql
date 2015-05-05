/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGroupDelete
	Desc    		:	This store procedure is use to delete PFS_USER_GROUP
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserGroupDelete]
(
	@iUserGroupID INT
)
AS
BEGIN

	DELETE [PFS_USER_GROUP] 
    WHERE
      [PFS_USER_GROUP_ID] = @iUserGroupID	
	
END
