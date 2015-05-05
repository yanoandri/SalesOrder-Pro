/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLogGet
	Desc    		:	This store procedure is use to get list of PFS_USER_LOG by id
	Create Date 	:	30 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	30 Nov 2011		- Modified By : kprasetyo
						2013-09-12 - ssaputra Change UserID become UserName and add IsPurge
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLogListWithModuleName]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@p_sUserName VARCHAR(50) = NULL ,
	@dtLogDateFrom DATETIME = NULL,
	@dtLogDateTo DATETIME = NULL,
	@iModuleObjectMemberID INT = NULL 
)
AS
BEGIN
	SET NOCOUNT ON
                
	SELECT
		pul.[PFS_USER_LOG_ID],
		pul.[USER_NAME],
		pul.[REFERENCE_NUMBER],
		pul.[IP_ADDRESS],
		pul.[LOG_DATE],
		pul.[DESCRIPTION],
		pul.[DETAIL],
		pul.[STATUS],
		pul.[PFS_MODULE_OBJECT_MEMBER_ID],
		ISNULL([pu].[PFS_USER_ID], 0) [PFS_USER_ID],
		ISNULL(pu.[USER_NAME], 'NONE') [USER_NAME],
		ISNULL(pu.[FULL_NAME], 'NONE') [FULL_NAME],
		pmom.[MEMBER_CODE],
		pmom.[MEMBER_NAME],
		pmo.[PFS_MODULE_OBJECT_ID],
		pmo.[OBJECT_NAME],
		pm.[PFS_MODULE_ID],
		pm.[MODULE_NAME]
	FROM
		[dbo].[PFS_USER_LOG] AS pul WITH (NOLOCK)
		LEFT JOIN [dbo].[PFS_USER] AS pu WITH (NOLOCK) ON [pul].[USER_NAME] = [pu].[USER_NAME]
		INNER JOIN [dbo].[PFS_MODULE_OBJECT_MEMBER] AS pmom WITH (NOLOCK) ON [pul].[PFS_MODULE_OBJECT_MEMBER_ID] = [pmom].[PFS_MODULE_OBJECT_MEMBER_ID]
		INNER JOIN [dbo].[PFS_MODULE_OBJECT] AS pmo WITH(NOLOCK) ON [pmom].[PFS_MODULE_OBJECT_ID] = [pmo].[PFS_MODULE_OBJECT_ID]
		INNER JOIN [dbo].[PFS_MODULE] AS pm WITH(NOLOCK) ON [pmo].[PFS_MODULE_ID] = [pm].[PFS_MODULE_ID]
	WHERE
		[pul].[IS_PURGE] = 0
		AND (@p_sUserName IS NULL OR pul.[USER_NAME] = @p_sUserName)
		AND (@dtLogDateFrom IS NULL OR [pul].[LOG_DATE] >= @dtLogDateFrom)
		AND (@dtLogDateTo IS NULL OR [pul].[LOG_DATE] < DATEADD(DAY, 1, @dtLogDateTo)) 
		AND (@iModuleObjectMemberID IS NULL OR pul.[PFS_MODULE_OBJECT_MEMBER_ID] = @iModuleObjectMemberID) 
		AND (@sKeyWords IS NULL 
			OR pul.[REFERENCE_NUMBER] LIKE '%' + @sKeyWords + '%' 
			OR pu.[FULL_NAME] LIKE '%' + @sKeyWords + '%' 
			OR pmom.[MEMBER_NAME] LIKE '%' + @sKeyWords + '%' 
			OR pul.[IP_ADDRESS] LIKE '%' + @sKeyWords + '%' 
			OR pul.[DESCRIPTION] LIKE '%' + @sKeyWords + '%')		
	ORDER BY
		pul.[PFS_USER_LOG_ID] DESC
	
END
