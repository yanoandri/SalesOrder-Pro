
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserDetailGet
	Desc    		:	This store procedure is use to get PFS_USER_DETAIL by id
	Create Date 	:	10 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_UserDetailGet
(
	@iUserDetailID INT
)
AS
BEGIN
	SELECT
		pud0.pfs_user_detail_id,
		pud0.pfs_user_id,
		pud0.user_code,
		pud0.branch_code,
		pud0.department_name,
		pud0.position,
		pud0.dob,
		pud0.home_number,
		pud0.work_number,
		pud0.mobile_number,
		pud0.picture,
		pu1.user_name,
		pu1.full_name
	FROM
		pfs_user_detail pud0 WITH (NOLOCK),
		pfs_user pu1 WITH (NOLOCK)
	WHERE
		pud0.pfs_user_id = pu1.pfs_user_id AND
		pud0.pfs_user_detail_id = @iUserDetailID
END
