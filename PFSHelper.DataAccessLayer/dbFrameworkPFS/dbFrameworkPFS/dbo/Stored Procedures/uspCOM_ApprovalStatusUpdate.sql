/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalStatusUpdate
	Desc    		:	This store procedure is use to update COM_APPROVAL_STATUS
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalStatusUpdate]
(
	@iApprovalStatusID SMALLINT,
	@sApprovalStatusCode VARCHAR(50),
	@sDescription VARCHAR(255)
)
AS
BEGIN

	UPDATE [COM_APPROVAL_STATUS] SET
		com_approval_status_code = @sApprovalStatusCode,
		description = @sDescription
	WHERE
      	com_approval_status_id = @iApprovalStatusID
			
	SELECT @@ERROR		
END
