/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserGroupListReadPast
	Desc    		:	This store procedure is use to get list of PFS_USER_GROUP by id
	Create Date 	:	19 Oct 2011		- Created By  : kprasetyo
	Modified Date 	:	19 Oct 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	: uspPFS_UserGroupListReadPast null,27
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserGroupListReadPast]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iUserID INT = NULL ,
	@iGroupID INT = NULL 
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
			pfs_user_group pug0 WITH (readpast),
			pfs_user pu1 WITH (readpast),
			pfs_group pg2 WITH (readpast)
		WHERE
			pug0.pfs_user_id = pu1.pfs_user_id AND 
			pug0.pfs_group_id = pg2.pfs_group_id AND 
			(@iUserID IS NULL OR pug0.pfs_user_id = @iUserID) AND
			(@iGroupID IS NULL OR pug0.pfs_group_id = @iGroupID) AND
			(@sKeyWords IS NULL)
	
END
