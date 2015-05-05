/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserPasswordHistoryList
	Desc    		:	This store procedure is use to get list of PFS_USER_PASSWORD_HISTORY
	Create Date 	:	12 Sep 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserPasswordHistoryList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iUserID INT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL
)
AS
BEGIN
	SELECT
		puph0.pfs_user_password_history_id,
		puph0.pfs_user_id,
		puph0.password,
		puph0.create_date,
		pu1.user_name,
		pu1.full_name
	FROM
		pfs_user_password_history puph0 WITH (NOLOCK),
		pfs_user pu1 WITH (NOLOCK)
	WHERE
		puph0.pfs_user_id = pu1.pfs_user_id AND
		(@iUserID IS NULL OR puph0.pfs_user_id = @iUserID) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, puph0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, puph0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@sKeyWords IS NULL OR
		puph0.password LIKE '%' + @sKeyWords + '%')
END
