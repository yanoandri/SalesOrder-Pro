/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_GroupListWithTotalUser
	Desc    		:	This store procedure is use to get list of PFS_GROUP by id
	Create Date 	:	08 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	08 Nov 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_GroupListWithTotalUser]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsActive BIT = NULL ,
	@bIsNeedApproval BIT = NULL ,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL ,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL 
)
AS
BEGIN
                
	SELECT		
			pg0.pfs_group_id,
			pg0.group_name,
			pg0.group_descr,
			pg0.is_active,
			pg0.IS_NEED_APPROVAL,
			pg0.create_date,
			pg0.create_by_user_id,
			pu0.user_name AS create_by_username,
			pg0.update_date,
			pg0.update_by_user_id,
			pu1.user_name AS update_by_username,
			(SELECT COUNT(pfs_group_id) FROM pfs_user_group WHERE pfs_group_id = pg0.PFS_GROUP_ID)AS total_user 
		FROM
			pfs_group pg0 WITH(NOLOCK)
			INNER JOIN pfs_user pu0 WITH(NOLOCK) ON pg0.create_by_user_id = pu0.pfs_user_id
			INNER JOIN pfs_user pu1 WITH(NOLOCK) ON pg0.update_by_user_id = pu1.pfs_user_id
		WHERE		
			(@bIsActive IS NULL OR pg0.is_active = @bIsActive) AND
			(@bIsNeedApproval IS NULL OR pg0.is_need_approval = @bIsNeedApproval) AND
			(
				@dtCreateDateFrom IS NULL OR @dtCreateDateTo IS NULL OR 
				FLOOR(CAST(pg0.create_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtCreateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtCreateDateTo AS FLOAT))
			) AND				
			(@iCreateByUserID IS NULL OR pg0.create_by_user_id = @iCreateByUserID) AND
			(
				@dtUpdateDateFrom IS NULL OR @dtUpdateDateTo IS NULL OR 
				FLOOR(CAST(pg0.update_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtUpdateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtUpdateDateTo AS FLOAT))
			) AND				
			(@iUpdateByUserID IS NULL OR pg0.update_by_user_id = @iUpdateByUserID) AND
			(@sKeyWords IS NULL OR
			pg0.group_name LIKE '%' + @sKeyWords + '%' OR
			pg0.group_descr LIKE '%' + @sKeyWords + '%')
		ORDER BY
			pg0.GROUP_NAME ASC
	
END
