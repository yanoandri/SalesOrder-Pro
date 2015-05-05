/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogList
	Desc    		:	This store procedure is use to get list of COM_APPROVAL_LOG
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iRefID INT = NULL,
	@iModuleObjectMemberID INT = NULL,
	@iApprovalStatusID SMALLINT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@iUpdateByUserID INT = NULL
)
AS
BEGIN
	SELECT
		cal0.com_approval_log_id,
		cal0.ref_id,
		cal0.pfs_module_object_member_id,
		cal0.com_approval_status_id,
		cal0.create_date,
		cal0.update_date,
		cal0.create_by_user_id,
		cal0.update_by_user_id,
		cal0.detail,
		cal0.remark,
		cal0.previous_detail,
		pmom1.member_code,
		pmom1.member_name,
		cas2.com_approval_status_code
	FROM
		com_approval_log cal0 WITH (NOLOCK),
		pfs_module_object_member pmom1 WITH (NOLOCK),
		com_approval_status cas2 WITH (NOLOCK)
	WHERE
		cal0.pfs_module_object_member_id = pmom1.pfs_module_object_member_id AND
		cal0.com_approval_status_id = cas2.com_approval_status_id AND
		(@iRefID IS NULL OR cal0.ref_id = @iRefID) AND
		(@iModuleObjectMemberID IS NULL OR cal0.pfs_module_object_member_id = @iModuleObjectMemberID) AND
		(@iApprovalStatusID IS NULL OR cal0.com_approval_status_id = @iApprovalStatusID) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, cal0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, cal0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, cal0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, cal0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR cal0.create_by_user_id = @iCreateByUserID) AND
		(@iUpdateByUserID IS NULL OR cal0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		cal0.remark LIKE '%' + @sKeyWords + '%')
END
