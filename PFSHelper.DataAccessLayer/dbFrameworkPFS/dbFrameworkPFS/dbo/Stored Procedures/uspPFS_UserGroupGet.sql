/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGroupGet
	Desc    		:	This store procedure is use to get PFS_USER_GROUP by id
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserGroupGet]
(
	@iUserGroupID INT = NULL
)
AS
BEGIN

	SELECT
			pug0.pfs_user_group_id,
			pug0.pfs_user_id,
			pug0.pfs_group_id,
			pu1.user_name,
			pu1.full_name,
			pg2.group_name
		FROM
			pfs_user_group pug0 WITH (NOLOCK),
			pfs_user pu1 WITH (NOLOCK),
			pfs_group pg2 WITH (NOLOCK)
		WHERE
			pug0.pfs_user_id = pu1.pfs_user_id AND 
			pug0.pfs_group_id = pg2.pfs_group_id AND 
			(@iUserGroupID IS NULL OR pug0.pfs_user_group_id = @iUserGroupID) 
END
