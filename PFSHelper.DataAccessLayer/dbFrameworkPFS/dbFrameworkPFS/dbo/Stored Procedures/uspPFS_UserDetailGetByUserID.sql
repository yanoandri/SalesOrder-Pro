/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_UserDetailGetByUserID]
	Desc    		:	This store procedure is use to get PFS_USER_DETAIL by id
	Create Date 	:	14 Oct 2011		- Created By  : kprasetyo
	Modified Date 	:	14 Oct 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserDetailGetByUserID]
(
	@iUserID INT = NULL
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
			(@iUserID IS NULL OR pu1.pfs_user_id = @iUserID) 
END
