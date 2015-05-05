/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserDelete
	Desc    		:	This store procedure is use to delete PFS_USER
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserDelete]
(
	@iUserID INT
)
AS
BEGIN

	DELETE [PFS_USER] 
    WHERE
      [PFS_USER_ID] = @iUserID	
	
END
