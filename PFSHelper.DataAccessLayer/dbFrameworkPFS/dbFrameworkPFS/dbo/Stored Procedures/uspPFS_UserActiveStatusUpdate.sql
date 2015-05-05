/*****************************************************************************
  Copyright (c) 2005, PT Profescipta Wahanatehnik. All Rights Reserved.
  This software, all associated documentation, and all copies
  are CONFIDENTIAL INFORMATION of PT Profescipta Wahanatehnik.
  DESCRIPTION
	Name    		:   uspPFS_UserActiveStatusUpdate
	Desc    		:	This procedure is used to update active status user.
	Input   		: 	
    Output  		:	
	Comments		:	
	Status  		: 	
	Sample Data 	:	spCOM_UserActiveStatusUpdate 1, 1
******************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserActiveStatusUpdate]
(
    @iUserId AS INT=1,
	@bIsActive AS BIT
)
AS
BEGIN

	UPDATE 	pfs_user SET   	
		is_active = @bIsActive
	WHERE 	pfs_user_id = @iUserId
	
END
