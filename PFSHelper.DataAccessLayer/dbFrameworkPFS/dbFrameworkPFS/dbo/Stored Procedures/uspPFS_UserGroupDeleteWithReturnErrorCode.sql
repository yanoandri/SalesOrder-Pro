/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGroupDeleteWithReturnErrorCode
	Desc    		:	This store procedure is use to delete PFS_USER_GROUP
	Create Date 	:	13 Oct 2011		- Created By  : kprasetyo
	Modified Date 	:	13 Oct 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserGroupDeleteWithReturnErrorCode]
(
	@iUserGroupID INT
)
AS
BEGIN

	DELETE [PFS_USER_GROUP] 
    WHERE
      [PFS_USER_GROUP_ID] = @iUserGroupID	
	
	select @@ERROR
END
