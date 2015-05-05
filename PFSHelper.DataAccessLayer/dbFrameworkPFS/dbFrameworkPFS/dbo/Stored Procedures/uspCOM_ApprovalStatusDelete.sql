/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalStatusDelete
	Desc    		:	This store procedure is use to delete COM_APPROVAL_STATUS
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalStatusDelete]
(
	@iApprovalStatusID SMALLINT
)
AS
BEGIN

	DELETE [COM_APPROVAL_STATUS] 
    WHERE
      [COM_APPROVAL_STATUS_ID] = @iApprovalStatusID	
	
END
