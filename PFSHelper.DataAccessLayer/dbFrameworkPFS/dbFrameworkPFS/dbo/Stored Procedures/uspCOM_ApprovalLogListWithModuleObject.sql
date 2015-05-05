/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogList
	Desc    		:	This store procedure is use to get list of COM_APPROVAL_LOG by id
	Create Date 	:	20 Oct 2011		- Created By  : kprasetyo
	Modified Date 	:	12 Nov 2014		- Modified By : msarlita
	Comments		:
	Sample Data 	:
					uspCOM_ApprovalLogListWithModuleObject null,null,null,null,null,null,null,null,null,null,null, 1
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogListWithModuleObject]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iRefID INT = NULL ,
	@iModuleObjectID INT = NULL ,
	@iModuleObjectMemberID INT = NULL ,
	@iApprovalStatusID SMALLINT = NULL ,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL ,
	@iUpdateByUserID INT = NULL ,
	@iUserID INT--,
	--@sModuleObjectMemberID VARCHAR(128)
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
			CASE cal0.update_by_user_id WHEN 0 THEN
				''
			else
				ISNULL(pu16.USER_NAME,'') 
			END	as update_by_user_name,
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
			INNER JOIN pfs_user pu14 WITH(NOLOCK) ON cal0.CREATE_BY_USER_ID = pu14.PFS_USER_ID
			INNER JOIN pfs_module_object_member pmom15 WITH (NOLOCK) ON cal0.PFS_MODULE_OBJECT_MEMBER_ID = pmom15.PFS_MODULE_OBJECT_MEMBER_ID	
			LEFT JOIN PFS_USER pu16 WITH(NOLOCK) ON pu16.PFS_USER_ID = cal0.UPDATE_BY_USER_ID

		WHERE
			
			(@iRefID IS NULL OR cal0.ref_id = @iRefID) AND
			(@iModuleObjectID IS NULL OR pmo4.PFS_MODULE_OBJECT_ID = @iModuleObjectID) AND
			(@iModuleObjectMemberID IS NULL OR cal0.pfs_module_object_member_id = @iModuleObjectMemberID) AND
			(@iApprovalStatusID IS NULL OR cal0.com_approval_status_id = @iApprovalStatusID) AND
			(
				@dtCreateDateFrom IS NULL OR @dtCreateDateTo IS NULL OR 
				FLOOR(CAST(cal0.create_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtCreateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtCreateDateTo AS FLOAT))
			) AND				
			(
				@dtUpdateDateFrom IS NULL OR @dtUpdateDateTo IS NULL OR 
				FLOOR(CAST(cal0.update_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtUpdateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtUpdateDateTo AS FLOAT))
			) AND				
			
			(@iCreateByUserID IS NULL OR cal0.create_by_user_id = @iCreateByUserID) AND
			(@iUpdateByUserID IS NULL OR cal0.update_by_user_id = @iUpdateByUserID) AND

			(pug7.PFS_GROUP_ID = (SELECT TOP 1 pug9.PFS_GROUP_ID FROM PFS_USER_GROUP pug9 WHERE pug9.PFS_GROUP_ID = pug7.PFS_GROUP_ID)) AND
			
			/** ONLY VIEW LIST IN WHICH NOT CREATE BY USER AND STATUS IS PENDING **/
			((cal0.CREATE_BY_USER_ID <> @iUserID) OR
			((cal0.CREATE_BY_USER_ID = @iUserID) AND cal0.COM_APPROVAL_STATUS_ID <> 2)) AND
			(pug7.PFS_USER_ID = (SELECT TOP 1 pu10.PFS_USER_ID FROM dbo.PFS_USER pu10 WHERE pu10.PFS_USER_ID = pug7.PFS_USER_ID )) --AND
			
			AND
			
			--(pmo4.pfs_module_object_id IN (
			--	SELECT 
			--		pmomg11.pfs_module_object_id 
			--	FROM 
			--		PFS_MODULE_OBJECT_MEMBER_GROUP pmomg11
			--		JOIN PFS_MODULE_OBJECT_MEMBER_USER_ACTION pmomua13 ON pmomg11.PFS_MODULE_OBJECT_MEMBER_ID = pmomua13.PFS_MODULE_OBJECT_MEMBER_ID
			--	WHERE 
			--		pmomua13.USER_ACTION_TYPE = 2 AND
			--		pmomg11.PFS_GROUP_ID IN (
			--			SELECT 
			--				pug12.PFS_GROUP_ID 
			--			FROM 
			--				PFS_USER_GROUP pug12 
			--			WHERE 
			--				pug12.PFS_USER_ID = @iUserID
			--			)
			--	)
			--)
			
			--AND
			
			(@sKeyWords IS NULL OR 
			pu14.USER_NAME LIKE '%'+ @sKeyWords + '%' OR
			pu16.USER_NAME LIKE '%'+ @sKeyWords + '%' OR
			pmom15.MEMBER_NAME LIKE '%'+ @sKeyWords +'%' OR
			cal0.REMARK LIKE '%'+ @sKeyWords +'%' )
			
			
	GROUP BY
			cal0.com_approval_log_id,
			cal0.ref_id,
			cal0.pfs_module_object_member_id,
			cal0.com_approval_status_id,
			cal0.create_date,
			cal0.update_date,
			cal0.create_by_user_id,
			cal0.update_by_user_id,
			pu16.USER_NAME,
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
