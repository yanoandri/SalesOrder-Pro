/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserPasswordHistoryAdd
	Desc    		:	This store procedure is use to add PFS_USER_PASSWORD_HISTORY
	Create Date 	:	12 Sep 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserPasswordHistoryAdd]
(
	@iUserID INT,
	@sPassword VARCHAR(255),
	@dtCreateDate DATETIME
)
AS
BEGIN
	DECLARE @lUserPasswordHistoryID INT
    
	INSERT INTO PFS_USER_PASSWORD_HISTORY 
    ( 	
		pfs_user_id,
		password,
		create_date
	)
	VALUES
	(
		@iUserID,
		@sPassword,
		@dtCreateDate
	)
    
	SET @lUserPasswordHistoryID = ISNULL(@@IDENTITY, 0)
	SELECT @lUserPasswordHistoryID
END
