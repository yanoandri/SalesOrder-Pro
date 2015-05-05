/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_GroupDelete
	Desc    		:	This store procedure is use to delete PFS_GROUP
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_GroupDelete]
(
	@iGroupID INT
)
AS
BEGIN

	DELETE [PFS_GROUP] 
    WHERE
      [PFS_GROUP_ID] = @iGroupID	
	
END
