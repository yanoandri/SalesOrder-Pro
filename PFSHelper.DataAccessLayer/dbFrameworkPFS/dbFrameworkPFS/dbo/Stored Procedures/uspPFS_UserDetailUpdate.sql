
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserDetailUpdate
	Desc    		:	This store procedure is use to update PFS_USER_DETAIL
	Create Date 	:	10 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_UserDetailUpdate
(
	@iUserDetailID INT,
	@iUserID INT,
	@sUserCode VARCHAR(20),
	@sBranchCode VARCHAR(100),
	@sDepartmentName VARCHAR(100),
	@sPosition VARCHAR(100),
	@dtDob DATETIME,
	@sHomeNumber VARCHAR(50),
	@sWorkNumber VARCHAR(50),
	@sMobileNumber VARCHAR(30),
	@byPicture IMAGE
)
AS
BEGIN
	UPDATE PFS_USER_DETAIL SET
		pfs_user_id = @iUserID,
		user_code = @sUserCode,
		branch_code = @sBranchCode,
		department_name = @sDepartmentName,
		position = @sPosition,
		dob = @dtDob,
		home_number = @sHomeNumber,
		work_number = @sWorkNumber,
		mobile_number = @sMobileNumber,
		picture = @byPicture
	WHERE
      	pfs_user_detail_id = @iUserDetailID

	SELECT @@ERROR
END
