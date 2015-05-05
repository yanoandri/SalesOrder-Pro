
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_BranchUpdate
	Desc    		:	This store procedure is use to update COM_BRANCH
	Create Date 	:	16 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_BranchUpdate
(
	@iBranchID INT,
	@sBranchCode VARCHAR(20),
	@sBranchName VARCHAR(100),
	@sDescription VARCHAR(255),
	@bIsActive BIT,
	@bIsDeleted BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE COM_BRANCH SET
		branch_code = @sBranchCode,
		branch_name = @sBranchName,
		description = @sDescription,
		is_active = @bIsActive,
		is_deleted = @bIsDeleted,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	com_branch_id = @iBranchID

	SELECT @@ERROR
END
