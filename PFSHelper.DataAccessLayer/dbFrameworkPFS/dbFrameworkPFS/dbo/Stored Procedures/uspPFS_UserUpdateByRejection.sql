/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserUpdateForRejection
	Desc    		:	This store procedure is use to update PFS_USER
	Create Date 	:	02 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	02 Nov 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	: 
						uspPFS_UserUpdateForNeedApproval 52,0,'2011-10-29',52
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserUpdateByRejection]
(
	@iUserID INT
)
AS
BEGIN

	UPDATE [PFS_USER] SET
		is_need_approval = 0
	WHERE
  		pfs_user_id = @iUserID
	
	select @@ERROR
			
END
