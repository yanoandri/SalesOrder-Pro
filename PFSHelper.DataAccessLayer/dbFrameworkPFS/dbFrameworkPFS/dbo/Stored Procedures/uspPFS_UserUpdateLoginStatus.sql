/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_UserUpdateLoginStatus]
	Desc    		:	This store procedure is use to update PFS_USER
	Create Date 	:	31 Jan 2012		- kprasetyo
	Modified Date 	:	31 Jan 2012		- kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserUpdateLoginStatus]
(
	@iUserID INT,
	@bIsLogin BIT
)
AS
BEGIN

	UPDATE [PFS_USER] SET
		is_login = @bIsLogin
	WHERE
      	pfs_user_id = @iUserID
			
	SELECT @@ERROR
	
END
