/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFSHelper_UserLogLoadByUserID
	Desc    		:	
	Create Date 	:	ssaputra - 2013-09-11	
	Modified Date 	:	            	
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFSHelper_UserLogLoadByUserID]
(
	@p_iUserID INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		[pul].[PFS_USER_LOG_ID],
	    [pul].[USER_NAME],
	    [pul].[REFERENCE_NUMBER],
	    [pul].[IP_ADDRESS],
	    [pul].[LOG_DATE],
	    [pul].[DESCRIPTION],
	    [pul].[DETAIL],
	    [pul].[STATUS],
	    [pul].[PFS_MODULE_OBJECT_MEMBER_ID],
	    [pmom].[MEMBER_CODE],
	    [pmom].[MEMBER_NAME]
	FROM
		[dbo].[PFS_USER_LOG] AS pul WITH(NOLOCK)
		INNER JOIN [dbo].[PFS_MODULE_OBJECT_MEMBER] AS pmom WITH(NOLOCK) ON [pul].[PFS_MODULE_OBJECT_MEMBER_ID] = [pmom].[PFS_MODULE_OBJECT_MEMBER_ID]
		INNER JOIN [dbo].[PFS_USER] AS pu WITH(NOLOCK) ON [pul].[USER_NAME] = [pu].[USER_NAME]
	WHERE
		(@p_iUserID IS NULL OR [pu].[PFS_USER_ID] = @p_iUserID)
END
