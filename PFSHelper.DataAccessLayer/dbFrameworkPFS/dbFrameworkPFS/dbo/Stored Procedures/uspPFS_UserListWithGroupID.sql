
/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_UserListWithGroupID]
	Desc    		:	This store procedure is use to get list of PFS_USER by id
	Create Date 	:	18 Okt 2011		- Created By  : kprasetyo
	Modified Date 	:	18 Okt 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:	[uspPFS_UserListWithGroupID]
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserListWithGroupID]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@sGroupID VARCHAR(2000) = NULL,
	@bIsActive BIT = NULL,
	@dtLastAccessFrom DATETIME = NULL,
	@dtLastAccessTo DATETIME = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@bIsNoLock BIT = 1
)
AS
BEGIN

	-- Get GroupID Collection
	CREATE TABLE #GroupID(GroupID VARCHAR(5))
	INSERT INTO #GroupID
	SELECT * FROM dbo.fn_split(@sGroupID,',')

	IF @bIsNoLock = 1 
	BEGIN
		
		SELECT	DISTINCT
			cu0.pfs_user_id,
			cu0.user_name, 
			cu0.password, 
			cu0.full_name,
			cu0.title,
			cu0.email,
			cu0.is_active,
			cu0.last_access,
			cu0.create_date,
			cu0.update_date,
			cu0.is_need_approval,
			cu0.is_login,
			cu0.create_by_user_id,
			cu0.update_by_user_id,
			cu0.[IS_BLOCKED],
			(
				SELECT 
					pu.USER_NAME 
				FROM 
					PFS_USER pu WITH(NOLOCK) 
				WHERE
					pu.PFS_USER_ID = cu0.create_by_user_id
			) AS CreatedByName
			
		FROM 
			pfs_user cu0 WITH (NOLOCK)
			LEFT JOIN pfs_user_group psg0 WITH (NOLOCK) ON psg0.pfs_user_id = cu0.pfs_user_id
			LEFT JOIN pfs_group gu0 WITH (NOLOCK) ON gu0.pfs_group_id = psg0.pfs_group_id
		WHERE 
		(@bIsActive IS NULL OR cu0.is_active = @bIsActive) AND
		(
			@dtLastAccessFrom IS NULL OR @dtLastAccessTo IS NULL OR 
			FLOOR(CAST(cu0.last_access AS FLOAT)) BETWEEN FLOOR(CAST(@dtLastAccessFrom AS FLOAT)) AND FLOOR(CAST(@dtLastAccessTo AS FLOAT))
		) AND 			
		(
			@dtCreateDateFrom IS NULL OR @dtCreateDateTo IS NULL OR 
			FLOOR(CAST(cu0.create_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtCreateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtCreateDateTo AS FLOAT))
		) AND 			
		(
			@dtUpdateDateFrom IS NULL OR @dtUpdateDateTo IS NULL OR 
			FLOOR(CAST(cu0.update_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtUpdateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtUpdateDateTo AS FLOAT))
		) AND 			
		(@sGroupID IS NULL OR gu0.pfs_group_id IN (SELECT CAST(GroupID AS INT) FROM #GroupID)) AND
		(@sKeyWords IS NULL OR
		cu0.user_name LIKE '%' + @sKeyWords + '%' OR
		cu0.full_name LIKE '%' + @sKeyWords + '%' OR
		cu0.email LIKE '%' + @sKeyWords + '%')
		ORDER BY cu0.user_name

	END
	ELSE
	BEGIN
		
		SELECT	DISTINCT
			cu0.pfs_user_id,
			cu0.user_name, 
			cu0.password, 
			cu0.full_name,
			cu0.title,
			cu0.email,
			cu0.is_active,
			cu0.last_access,
			cu0.create_date,
			cu0.update_date,
			cu0.is_need_approval,
			cu0.is_login,
			cu0.create_by_user_id,
			cu0.update_by_user_id,
			cu0.[IS_BLOCKED],
			(
				SELECT 
					pu.USER_NAME 
				FROM 
					PFS_USER pu WITH(NOLOCK) 
				WHERE
					pu.PFS_USER_ID = cu0.create_by_user_id
			) AS CreatedByName
		FROM 
			pfs_user cu0 WITH (READPAST)
			LEFT JOIN pfs_user_group psg0 WITH (NOLOCK) ON psg0.pfs_user_id = cu0.pfs_user_id
			LEFT JOIN pfs_group gu0 WITH (NOLOCK) ON gu0.pfs_group_id = psg0.pfs_group_id
		WHERE 
		(@bIsActive IS NULL OR cu0.is_active = @bIsActive) AND
		(
			@dtLastAccessFrom IS NULL OR @dtLastAccessTo IS NULL OR 
			FLOOR(CAST(cu0.last_access AS FLOAT)) BETWEEN FLOOR(CAST(@dtLastAccessFrom AS FLOAT)) AND FLOOR(CAST(@dtLastAccessTo AS FLOAT))
		) AND 			
		(
			@dtCreateDateFrom IS NULL OR @dtCreateDateTo IS NULL OR 
			FLOOR(CAST(cu0.create_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtCreateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtCreateDateTo AS FLOAT))
		) AND 			
		(
			@dtUpdateDateFrom IS NULL OR @dtUpdateDateTo IS NULL OR 
			FLOOR(CAST(cu0.update_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtUpdateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtUpdateDateTo AS FLOAT))
		) AND 			
		(@sGroupID IS NULL OR gu0.pfs_group_id IN (SELECT CAST(GroupID AS INT) FROM #GroupID)) AND
		(@sKeyWords IS NULL OR
		cu0.user_name LIKE '%' + @sKeyWords + '%' OR
		cu0.full_name LIKE '%' + @sKeyWords + '%' OR
		cu0.email LIKE '%' + @sKeyWords + '%')
		ORDER BY cu0.user_name
	END
	
END

