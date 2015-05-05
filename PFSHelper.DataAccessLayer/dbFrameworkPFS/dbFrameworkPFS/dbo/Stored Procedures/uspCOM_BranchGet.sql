
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_BranchGet
	Desc    		:	This store procedure is use to get COM_BRANCH by id
	Create Date 	:	16 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_BranchGet
(
	@iBranchID INT
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
		cb0.com_branch_id = @iBranchID
END
