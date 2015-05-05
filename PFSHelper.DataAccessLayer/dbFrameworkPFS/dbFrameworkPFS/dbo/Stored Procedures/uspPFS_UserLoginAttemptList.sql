/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLoginAttemptGet
	Desc    		:	This store procedure is use to get list of PFS_USER_LOGIN_ATTEMPT by id
	Create Date 	:	31 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	31 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLoginAttemptList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@dtLastSuccessfullLoginDateFrom DATETIME = NULL,
	@dtLastSuccessfullLoginDateTo DATETIME = NULL,
	@dtLastFailedLoginDateFrom DATETIME = NULL,
	@dtLastFailedLoginDateTo DATETIME = NULL
)
AS
BEGIN

                
	SELECT
			pula0.pfs_user_login_attempt_id,
			pula0.user_name,
			pula0.last_successfull_login_date,
			pula0.last_failed_login_date,
			pula0.total_success,
			pula0.total_failed,
			pula0.last_failed_description
		FROM
			pfs_user_login_attempt pula0 WITH (NOLOCK)
		WHERE
			(
				@dtLastSuccessfullLoginDateFrom IS NULL OR @dtLastSuccessfullLoginDateTo IS NULL OR 
				FLOOR(CAST(pula0.last_successfull_login_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtLastSuccessfullLoginDateFrom AS FLOAT)) AND FLOOR(CAST(@dtLastSuccessfullLoginDateTo AS FLOAT))
			) 	AND			
			(
				@dtLastFailedLoginDateFrom IS NULL OR @dtLastFailedLoginDateTo IS NULL OR 
				FLOOR(CAST(pula0.last_failed_login_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtLastFailedLoginDateFrom AS FLOAT)) AND FLOOR(CAST(@dtLastFailedLoginDateTo AS FLOAT))
			) 	AND
			(@sKeyWords IS NULL OR
			pula0.user_name LIKE '%' + @sKeyWords + '%' OR
			pula0.last_failed_description LIKE '%' + @sKeyWords + '%')
	
END
