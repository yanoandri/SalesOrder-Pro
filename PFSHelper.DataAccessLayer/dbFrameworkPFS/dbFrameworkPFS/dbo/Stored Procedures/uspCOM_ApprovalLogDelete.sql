/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogDelete
	Desc    		:	This store procedure is use to delete COM_APPROVAL_LOG
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogDelete]
(
	@lApprovalLogID BIGINT
)
AS
BEGIN
	DELETE COM_APPROVAL_LOG
    WHERE COM_APPROVAL_LOG_ID = @lApprovalLogID
END
