
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserDetailDelete
	Desc    		:	This store procedure is use to delete PFS_USER_DETAIL
	Create Date 	:	10 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_UserDetailDelete
(
	@iUserDetailID INT
)
AS
BEGIN
	DELETE PFS_USER_DETAIL
    WHERE PFS_USER_DETAIL_ID = @iUserDetailID
END
