/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogGetForLandingPage
	Desc    		:	This store procedure is use to get COM_APPROVAL_LOG by id
	Create Date 	:	13 Dec 2011		- Created By  : kprasetyo
	Modified Date 	:	13 Dec 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
					uspCOM_ApprovalLogGetForLandingPage 52
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogGetForLandingPage]
(
	@iUserID INT
)
AS
BEGIN

	SELECT
		/** PENDING NUMBER **/
		(SELECT
			ISNULL(COUNT(1),0)
		FROM
			com_approval_log cal0 WITH (NOLOCK),
			pfs_module_object_member pmom1 WITH (NOLOCK),
			com_approval_status cas2 WITH (NOLOCK)
		WHERE
			cal0.pfs_module_object_member_id = pmom1.pfs_module_object_member_id AND 
			cal0.com_approval_status_id = cas2.com_approval_status_id AND
			cal0.COM_APPROVAL_STATUS_ID = 2 AND
			cal0.CREATE_BY_USER_ID = @iUserID
			) PENDING_NUMBER ,

		/** APPROVED NUMBER **/
		(SELECT
			ISNULL(COUNT(1) ,0)
		FROM
			com_approval_log cal0 WITH (NOLOCK),
			pfs_module_object_member pmom1 WITH (NOLOCK),
			com_approval_status cas2 WITH (NOLOCK)
		WHERE
			cal0.pfs_module_object_member_id = pmom1.pfs_module_object_member_id AND 
			cal0.com_approval_status_id = cas2.com_approval_status_id AND
			cal0.COM_APPROVAL_STATUS_ID = 1 AND
			cal0.CREATE_BY_USER_ID = @iUserID
			) APPROVED_NUMBER, 

		/** REJECTED NUMBER **/
		(SELECT
			ISNULL(COUNT(1) ,0)
		FROM
			com_approval_log cal0 WITH (NOLOCK),
			pfs_module_object_member pmom1 WITH (NOLOCK),
			com_approval_status cas2 WITH (NOLOCK)
		WHERE
			cal0.pfs_module_object_member_id = pmom1.pfs_module_object_member_id AND 
			cal0.com_approval_status_id = cas2.com_approval_status_id AND
			cal0.COM_APPROVAL_STATUS_ID=3 AND
			cal0.CREATE_BY_USER_ID = @iUserID 
			) REJECTED_NUMBER,

		/** NEED APPROVAL NUMBER **/
		(SELECT COUNT(1) NEED_APPROVAL_NUMBER FROM 
			
				(SELECT 
					ISNULL(COUNT(1) ,0) TMP_NEED_APPROVAL_NUMBER
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
					(pug7.PFS_GROUP_ID = (SELECT TOP 1 pug9.PFS_GROUP_ID FROM PFS_USER_GROUP pug9 WHERE pug9.PFS_GROUP_ID = pug7.PFS_GROUP_ID)) AND
					(cal0.CREATE_BY_USER_ID <> @iUserID) AND
					(pug7.PFS_USER_ID = (SELECT TOP 1 pu10.PFS_USER_ID FROM dbo.PFS_USER pu10 WHERE pu10.PFS_USER_ID = pug7.PFS_USER_ID )) AND
					cal0.COM_APPROVAL_STATUS_ID = 2 
					
					AND
					
					(pmo4.pfs_module_object_id IN (
						SELECT 
							pmomg11.pfs_module_object_id 
						FROM 
							PFS_MODULE_OBJECT_MEMBER_GROUP pmomg11
							JOIN PFS_MODULE_OBJECT_MEMBER_USER_ACTION pmomua13 ON pmomg11.PFS_MODULE_OBJECT_MEMBER_ID = pmomua13.PFS_MODULE_OBJECT_MEMBER_ID
						WHERE 
							pmomua13.USER_ACTION_TYPE = 2 AND
							pmomg11.PFS_GROUP_ID IN (
								SELECT 
									pug12.PFS_GROUP_ID 
								FROM 
									PFS_USER_GROUP pug12 
								WHERE 
									pug12.PFS_USER_ID = @iUserID
								)
						)
					)
					
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
					pm5.module_name) TMP
		) NEED_APPROVAL_NUMBER,

		/** APPROVED BY USER NUMBER **/
		(SELECT COUNT(1) APPROVED_BY_USER_NUMBER FROM 
			
				(SELECT 
					ISNULL(COUNT(1) ,0) TMP_APPROVED_BY_USER_NUMBER
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
					(pug7.PFS_GROUP_ID = (SELECT TOP 1 pug9.PFS_GROUP_ID FROM PFS_USER_GROUP pug9 WHERE pug9.PFS_GROUP_ID = pug7.PFS_GROUP_ID)) AND
					(cal0.CREATE_BY_USER_ID <> 52) AND
					(pug7.PFS_USER_ID = (SELECT TOP 1 pu10.PFS_USER_ID FROM dbo.PFS_USER pu10 WHERE pu10.PFS_USER_ID = pug7.PFS_USER_ID )) AND
					cal0.COM_APPROVAL_STATUS_ID = 1 AND
					cal0.UPDATE_BY_USER_ID = @iUserID
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
					pm5.module_name) TMP
		) APPROVED_BY_USER_NUMBER ,

		/** REJECTED BY USER NUMBER **/
		(SELECT COUNT(1) REJECTED_BY_USER_NUMBER FROM 
			
				(SELECT 
					ISNULL(COUNT(1) ,0) TMP_REJECTED_BY_USER_NUMBER
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
					(pug7.PFS_GROUP_ID = (SELECT TOP 1 pug9.PFS_GROUP_ID FROM PFS_USER_GROUP pug9 WHERE pug9.PFS_GROUP_ID = pug7.PFS_GROUP_ID)) AND
					(cal0.CREATE_BY_USER_ID <> 52) AND
					(pug7.PFS_USER_ID = (SELECT TOP 1 pu10.PFS_USER_ID FROM dbo.PFS_USER pu10 WHERE pu10.PFS_USER_ID = pug7.PFS_USER_ID )) AND
					cal0.COM_APPROVAL_STATUS_ID = 3 AND
					cal0.UPDATE_BY_USER_ID = @iUserID
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
					pm5.module_name) TMP
		) REJECTED_BY_USER_NUMBER 
			--(@lApprovalLogID IS NULL OR cal0.com_approval_log_id = @lApprovalLogID) 
END
