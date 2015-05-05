/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_GroupGet
	Desc    		:	This store procedure is use to get PFS_GROUP by id
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_GroupGet]
(
	@iGroupID INT = NULL
)
AS
BEGIN

	SELECT
			pg0.pfs_group_id,
			pg0.group_name,
			pg0.group_descr,
			pg0.is_active,
			pg0.is_need_approval,
			pg0.create_date,
			pg0.create_by_user_id,
			pg0.update_date,
			pg0.update_by_user_id
		FROM
			pfs_group pg0 WITH (NOLOCK)
		WHERE
			(@iGroupID IS NULL OR pg0.pfs_group_id = @iGroupID) 
END
