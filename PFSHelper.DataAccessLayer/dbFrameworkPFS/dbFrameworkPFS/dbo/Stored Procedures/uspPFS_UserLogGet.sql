/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLogGet
	Desc    		:	This store procedure is use to get PFS_USER_LOG by id
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLogGet]
(
	@lUserLogID BIGINT
)
AS
BEGIN
	SELECT
		pul0.pfs_user_log_id,
		pul0.user_name,
		pul0.reference_number,
		pul0.ip_address,
		pul0.log_date,
		pul0.description,
		pul0.detail,
		pul0.status,
		pul0.pfs_module_object_member_id,
		pul0.is_purge,
		pul0.previous_detail,
		pmom1.member_code,
		pmom1.member_name
	FROM
		pfs_user_log pul0 WITH (NOLOCK),
		pfs_module_object_member pmom1 WITH (NOLOCK)
	WHERE
		pul0.pfs_module_object_member_id = pmom1.pfs_module_object_member_id AND
		pul0.pfs_user_log_id = @lUserLogID
END
