/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLogAdd
	Desc    		:	This store procedure is use to add PFS_USER_LOG
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLogAddByUserName]
(
	@sUsername VARCHAR(100),
	@sReferenceNumber VARCHAR(25),
	@sIpAddress VARCHAR(50),
	@dtLogDate DATETIME,
	@sDescription VARCHAR(1280),
	@xmlDetail XML,
	@iStatus SMALLINT,
	@iModuleObjectMemberID INT
)
AS
BEGIN

	DECLARE @lUserLogID INT
	INSERT INTO [PFS_USER_LOG]
    ( 	
		reference_number,
		ip_address,
		log_date,
		description,
		detail,
		status,
		pfs_module_object_member_id
	)
	VALUES
	(
		@sReferenceNumber,
		@sIpAddress,
		@dtLogDate,
		@sDescription,
		@xmlDetail,
		@iStatus,
		@iModuleObjectMemberID
	)
	
	SET  @lUserLogID = ISNULL(@@IDENTITY, 0)
	SELECT @lUserLogID
	
END
