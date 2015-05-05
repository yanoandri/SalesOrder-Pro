/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_BranchAdd
	Desc    		:	This store procedure is use to add COM_BRANCH
	Create Date 	:	16 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_BranchAdd
(
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
	DECLARE @iBranchID INT
    
	INSERT INTO COM_BRANCH 
    ( 	
		branch_code,
		branch_name,
		description,
		is_active,
		is_deleted,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@sBranchCode,
		@sBranchName,
		@sDescription,
		@bIsActive,
		@bIsDeleted,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iBranchID = ISNULL(@@IDENTITY, 0)
	SELECT @iBranchID
END
