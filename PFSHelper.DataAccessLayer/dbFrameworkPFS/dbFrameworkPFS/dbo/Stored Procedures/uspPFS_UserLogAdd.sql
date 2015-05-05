/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLogAdd
	Desc    		:	This store procedure is use to add PFS_USER_LOG
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLogAdd]
(
	@sUserName VARCHAR(50),
	@sReferenceNumber VARCHAR(25),
	@sIpAddress VARCHAR(50),
	@dtLogDate DATETIME,
	@sDescription VARCHAR(1280),
	@xmlDetail XML,
	@iStatus SMALLINT,
	@iModuleObjectMemberID INT,
	@bIsPurge BIT,
	@xmlPreviousDetail XML
)
AS
BEGIN
	DECLARE @lUserLogID INT
    
	INSERT INTO PFS_USER_LOG 
    ( 	
		user_name,
		reference_number,
		ip_address,
		log_date,
		description,
		detail,
		status,
		pfs_module_object_member_id,
		is_purge,
		previous_detail
	)
	VALUES
	(
		@sUserName,
		@sReferenceNumber,
		@sIpAddress,
		@dtLogDate,
		@sDescription,
		@xmlDetail,
		@iStatus,
		@iModuleObjectMemberID,
		@bIsPurge,
		@xmlPreviousDetail
	)
    
	SET @lUserLogID = ISNULL(@@IDENTITY, 0)
	SELECT @lUserLogID
END
