
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_BranchDelete
	Desc    		:	This store procedure is use to delete COM_BRANCH
	Create Date 	:	16 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_BranchDelete
(
	@iBranchID INT
)
AS
BEGIN
	DELETE COM_BRANCH
    WHERE COM_BRANCH_ID = @iBranchID
END
