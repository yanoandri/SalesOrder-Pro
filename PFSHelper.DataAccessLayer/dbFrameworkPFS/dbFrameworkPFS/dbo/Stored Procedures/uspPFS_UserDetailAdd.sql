/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserDetailAdd
	Desc    		:	This store procedure is use to add PFS_USER_DETAIL
	Create Date 	:	10 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_UserDetailAdd
(
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
	DECLARE @iUserDetailID INT
    
	INSERT INTO PFS_USER_DETAIL 
    ( 	
		pfs_user_id,
		user_code,
		branch_code,
		department_name,
		position,
		dob,
		home_number,
		work_number,
		mobile_number,
		picture
	)
	VALUES
	(
		@iUserID,
		@sUserCode,
		@sBranchCode,
		@sDepartmentName,
		@sPosition,
		@dtDob,
		@sHomeNumber,
		@sWorkNumber,
		@sMobileNumber,
		@byPicture
	)
    
	SET @iUserDetailID = ISNULL(@@IDENTITY, 0)
	SELECT @iUserDetailID
END
