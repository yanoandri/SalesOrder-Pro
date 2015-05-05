/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogUpdate
	Desc    		:	This store procedure is use to update COM_APPROVAL_LOG
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogUpdate]
(
	@lApprovalLogID BIGINT,
	@iRefID INT,
	@iModuleObjectMemberID INT,
	@iApprovalStatusID SMALLINT,
	@dtCreateDate DATETIME,
	@dtUpdateDate DATETIME,
	@iCreateByUserID INT,
	@iUpdateByUserID INT,
	@xmlDetail XML,
	@sRemark VARCHAR(255),
	@xmlPreviousDetail XML
)
AS
BEGIN
	UPDATE COM_APPROVAL_LOG SET
		ref_id = @iRefID,
		pfs_module_object_member_id = @iModuleObjectMemberID,
		com_approval_status_id = @iApprovalStatusID,
		create_date = @dtCreateDate,
		update_date = @dtUpdateDate,
		create_by_user_id = @iCreateByUserID,
		update_by_user_id = @iUpdateByUserID,
		detail = @xmlDetail,
		remark = @sRemark,
		previous_detail = @xmlPreviousDetail
	WHERE
      	com_approval_log_id = @lApprovalLogID

	SELECT @@ERROR
END
