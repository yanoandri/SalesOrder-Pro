﻿CREATE PROCEDURE [dbo].[uspPFS_UserLoginAttemptGetByUsername]
(
	@sUsername VARCHAR(50) 
)
AS
BEGIN
	SELECT 
		pula0.PFS_USER_LOGIN_ATTEMPT_ID,
		ISNULL(pu0.PFS_USER_ID,0) AS pfs_user_id,
		pula0.USER_NAME,
		ISNULL(pu0.FULL_NAME,'') AS full_name,
		ISNULL(pu0.TITLE,'') AS title,
		pula0.LAST_SUCCESSFULL_LOGIN_DATE,
		pula0.TOTAL_SUCCESS,
		pula0.LAST_FAILED_LOGIN_DATE,
		pula0.TOTAL_FAILED,
		pula0.LAST_FAILED_DESCRIPTION
	FROM
		PFS_USER_LOGIN_ATTEMPT 	pula0 WITH (NOLOCK)
		LEFT JOIN PFS_USER pu0 WITH(NOLOCK) ON pu0.USER_NAME = pula0.USER_NAME
	WHERE
		pula0.USER_NAME = @sUsername
END