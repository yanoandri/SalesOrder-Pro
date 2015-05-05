/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogGet
	Desc    		:	This store procedure is use to get COM_APPROVAL_LOG by id
	Create Date 	:	20 Oct 2011		- Created By  : kprasetyo
	Modified Date 	:	20 Oct 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogGetWithModuleObject]
(
	@iApprovalLogID INT = NULL
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
			cas2.com_approval_status_code,
			pu0.user_name as create_by_user_name,
			pmo0.pfs_module_object_id,
			pmo0.object_name,
			pm0.pfs_module_id,
			pm0.module_name,
			pu0.FULL_NAME
		FROM
			com_approval_log cal0 WITH (NOLOCK),
			pfs_module_object_member pmom1 WITH (NOLOCK),
			com_approval_status cas2 WITH (NOLOCK),
			pfs_user pu0 with(nolock),
			pfs_module_object pmo0 with(nolock),
			pfs_module pm0 with(nolock)
		WHERE
			cal0.pfs_module_object_member_id = pmom1.pfs_module_object_member_id AND 
			cal0.com_approval_status_id = cas2.com_approval_status_id AND 
			cal0.create_by_user_id = pu0.pfs_user_id and
			pmom1.pfs_module_object_id = pmo0.pfs_module_object_id and
			pmo0.pfs_module_id = pm0.pfs_module_id and
			(@iApprovalLogID IS NULL OR cal0.com_approval_log_id = @iApprovalLogID) 
END
