/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogListPendingByUser
	Desc    		:	This store procedure is use to get list of COM_APPROVAL_LOG by id
	Create Date 	:	15 Des 2011		- Created By  : kprasetyo
	Modified Date 	:	15 Des 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
					uspCOM_ApprovalLogListPendingByUser 77
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogListPendingByUser]
(
	@iUserID INT
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
			--cal0.detail,
			cal0.remark,
			pmom1.member_code,
			pmom1.member_name,
			cas2.com_approval_status_code,
			pu3.user_name as create_by_user_name,
			pmo4.pfs_module_object_id,
			pmo4.object_name,
			pm5.pfs_module_id,
			pm5.module_name

		FROM
			com_approval_log cal0 WITH (NOLOCK)
			INNER JOIN PFS_MODULE_OBJECT_MEMBER_GROUP pmomg6 WITH (NOLOCK) ON cal0.pfs_module_object_member_id = pmomg6.pfs_module_object_member_id  
			INNER JOIN pfs_module_object_member pmom1 WITH (NOLOCK) ON pmom1.PFS_MODULE_OBJECT_MEMBER_ID = cal0.PFS_MODULE_OBJECT_MEMBER_ID 
			INNER JOIN pfs_module_object pmo4 with(nolock) ON pmo4.PFS_MODULE_OBJECT_ID = pmom1.PFS_MODULE_OBJECT_ID 
            INNER JOIN pfs_module pm5 with(nolock) ON pm5.PFS_MODULE_ID = pmo4.PFS_MODULE_ID
			INNER JOIN PFS_USER_GROUP pug7 WITH(NOLOCK) ON pug7.PFS_GROUP_ID = pmomg6.PFS_GROUP_ID
			INNER JOIN PFS_USER pu8 WITH(NOLOCK) ON pu8.PFS_USER_ID = pug7.PFS_USER_ID 
			INNER JOIN com_approval_status cas2 WITH (NOLOCK) ON cal0.com_approval_status_id = cas2.com_approval_status_id 
			INNER JOIN pfs_user pu3 with(nolock) ON cal0.create_by_user_id = pu3.pfs_user_id 
			

		WHERE
			cal0.COM_APPROVAL_STATUS_ID = 2 AND
			cal0.CREATE_BY_USER_ID = @iUserID
			
		GROUP BY
			cal0.com_approval_log_id,
			cal0.ref_id,
			cal0.pfs_module_object_member_id,
			cal0.com_approval_status_id,
			cal0.create_date,
			cal0.update_date,
			cal0.create_by_user_id,
			cal0.update_by_user_id,
			--cal0.detail,
			cal0.remark,
			pmom1.member_code,
			pmom1.member_name,
			cas2.com_approval_status_code,
			pu3.user_name ,
			pmo4.pfs_module_object_id,
			pmo4.object_name,
			pm5.pfs_module_id,
			pm5.module_name
		ORDER BY
			cal0.com_approval_log_id DESC
			
	
	
END
