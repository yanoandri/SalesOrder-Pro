/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLogGetLastLogByUserID
	Desc    		:	This store procedure is use to get PFS_USER_LOG by id
	Create Date 	:	22 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	22 Nov 2011		- Modified By : kprasetyo
						2013-09-11 - ssaputra - Change UserID become UserName
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLogGetLastLogByUserID]
(
	@iUserID INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		TOP(1)
		pul.pfs_user_log_id,
		pul.[USER_NAME],
		pul.reference_number,
		pul.ip_address,
		pul.log_date,
		pul.description,
		pul.detail,
		pul.status,
		pul.pfs_module_object_member_id,
		pu.user_name,
		pu.full_name,
		pmom.member_code,
		pmom.member_name
	FROM
		pfs_user_log pul WITH (NOLOCK),
		pfs_user pu WITH (NOLOCK),
		pfs_module_object_member pmom WITH (NOLOCK)
	WHERE
		pul.[USER_NAME] = pu.[USER_NAME] AND 
		pul.pfs_module_object_member_id = pmom.pfs_module_object_member_id AND 
		(@iUserID IS NULL OR [pu].[PFS_USER_ID] = @iUserID) 
		AND STATUS=1
	ORDER BY 
		LOG_DATE DESC			
END
