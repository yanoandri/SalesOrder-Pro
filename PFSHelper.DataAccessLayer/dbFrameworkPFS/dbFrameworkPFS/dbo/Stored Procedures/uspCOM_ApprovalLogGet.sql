/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogGet
	Desc    		:	This store procedure is use to get COM_APPROVAL_LOG by id
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogGet]
(
	@lApprovalLogID BIGINT
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
		cal0.com_approval_log_id = @lApprovalLogID
END
