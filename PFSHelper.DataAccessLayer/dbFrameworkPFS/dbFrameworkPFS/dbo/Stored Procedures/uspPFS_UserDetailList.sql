
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserDetailList
	Desc    		:	This store procedure is use to get list of PFS_USER_DETAIL
	Create Date 	:	10 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPFS_UserDetailList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iUserID INT = NULL,
	@dtDobFrom DATETIME = NULL,
	@dtDobTo DATETIME = NULL
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
		(@iUserID IS NULL OR pud0.pfs_user_id = @iUserID) AND
		(@dtDobFrom IS NULL OR CONVERT(VARCHAR, pud0.dob, 12) >= CONVERT(VARCHAR, @dtDobFrom, 12)) AND
		(@dtDobTo IS NULL OR CONVERT(VARCHAR, pud0.dob, 12) <= CONVERT(VARCHAR, @dtDobTo, 12)) AND
		(@sKeyWords IS NULL OR
		pud0.user_code LIKE '%' + @sKeyWords + '%' OR
		pud0.branch_code LIKE '%' + @sKeyWords + '%' OR
		pud0.department_name LIKE '%' + @sKeyWords + '%' OR
		pud0.position LIKE '%' + @sKeyWords + '%' OR
		pud0.home_number LIKE '%' + @sKeyWords + '%' OR
		pud0.work_number LIKE '%' + @sKeyWords + '%' OR
		pud0.mobile_number LIKE '%' + @sKeyWords + '%')
END
