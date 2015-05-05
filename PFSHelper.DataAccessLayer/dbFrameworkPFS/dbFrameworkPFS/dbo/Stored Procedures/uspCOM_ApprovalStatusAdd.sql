/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalStatusAdd
	Desc    		:	This store procedure is use to add COM_APPROVAL_STATUS
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalStatusAdd]
(
	@sApprovalStatusCode VARCHAR(50),
	@sDescription VARCHAR(255)
)
AS
BEGIN

	DECLARE @iApprovalStatusID INT
	INSERT INTO [COM_APPROVAL_STATUS] 
    ( 	
		com_approval_status_code,
		description
	)
	VALUES
	(
		@sApprovalStatusCode,
		@sDescription
	)
	
	SET  @iApprovalStatusID = ISNULL(@@IDENTITY, 0)
	SELECT @iApprovalStatusID
	
END
