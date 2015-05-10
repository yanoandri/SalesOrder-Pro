﻿/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_GroupGetByGroupName]
	Desc    		:	This store procedure is use to get PFS_GROUP by id
	Create Date 	:	15 Oct 2011		- Created By  : kprasetyo
	Modified Date 	:	15 Oct 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_GroupGetByGroupName]
(
	@sGroupName varchar(1280) = NULL,
	@iGroupID INT = null
)
AS
BEGIN

	SELECT		
			pg0.pfs_group_id,
			pg0.group_name,
			pg0.group_descr,
			pg0.is_need_approval,
			pg0.is_active,
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
			(@sGroupName IS NULL OR pg0.group_name = @sGroupName) AND
			(@iGroupID IS NULL OR pg0.pfs_group_id <> @iGroupID) 
END