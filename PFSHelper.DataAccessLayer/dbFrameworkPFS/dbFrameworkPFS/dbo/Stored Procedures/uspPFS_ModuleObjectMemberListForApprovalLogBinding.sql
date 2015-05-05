/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberListForApprovalLogBinding
	Desc    		:	This store procedure is use to get list of PFS_MODULE_OBJECT_MEMBER by id
	Create Date 	:	19 Feb 2011		- Created By  : kprasetyo
	Modified Date 	:	19 Feb 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:	uspPFS_ModuleObjectMemberListForApprovalLogBinding 3005
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberListForApprovalLogBinding]
(
	@iModuleObjectID INT = NULL
)
AS
BEGIN           
	SELECT
		cal0.PFS_MODULE_OBJECT_MEMBER_ID,
		pmom1.MEMBER_CODE,
		pmom1.MEMBER_NAME,
		pmom1.MEMBER_DESCR
	FROM
		dbo.COM_APPROVAL_LOG cal0
		INNER JOIN dbo.PFS_MODULE_OBJECT_MEMBER pmom1 ON cal0.PFS_MODULE_OBJECT_MEMBER_ID = pmom1.PFS_MODULE_OBJECT_MEMBER_ID
		INNER JOIN dbo.PFS_MODULE_OBJECT pmo2 ON pmom1.PFS_MODULE_OBJECT_ID = pmo2.PFS_MODULE_OBJECT_ID
	WHERE
		(@iModuleObjectID IS NULL OR pmom1.PFS_MODULE_OBJECT_ID = @iModuleObjectID)
	GROUP BY
		cal0.PFS_MODULE_OBJECT_MEMBER_ID,
		pmom1.MEMBER_CODE,
		pmom1.MEMBER_NAME,
		pmom1.MEMBER_DESCR
END
