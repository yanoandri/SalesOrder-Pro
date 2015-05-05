
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_BranchList
	Desc    		:	This store procedure is use to get list of COM_BRANCH
	Create Date 	:	16 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_BranchList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsActive BIT = NULL,
	@bIsDeleted BIT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL
)
AS
BEGIN
	SELECT
		cb0.com_branch_id,
		cb0.branch_code,
		cb0.branch_name,
		cb0.description,
		cb0.is_active,
		cb0.is_deleted,
		cb0.create_date,
		cb0.create_by_user_id,
		cb0.update_date,
		cb0.update_by_user_id
	FROM
		com_branch cb0 WITH (NOLOCK)
	WHERE
		(@bIsActive IS NULL OR cb0.is_active = @bIsActive) AND
		(@bIsDeleted IS NULL OR cb0.is_deleted = @bIsDeleted) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, cb0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, cb0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR cb0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, cb0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, cb0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR cb0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		cb0.branch_code LIKE '%' + @sKeyWords + '%' OR
		cb0.branch_name LIKE '%' + @sKeyWords + '%' OR
		cb0.description LIKE '%' + @sKeyWords + '%')
END
