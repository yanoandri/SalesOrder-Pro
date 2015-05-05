/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_UserLogSetPurgeStatus
	Desc    		:	
	Create Date 	:	ssaputra - 2013-09-12	
	Modified Date 	:	            	
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_UserLogSetPurgeStatus]
(
	@p_iUserLogID BIGINT,
	@p_bIsPurge BIT
)
AS
BEGIN
	UPDATE
		[dbo].[PFS_USER_LOG] WITH(ROWLOCK)
	SET
		[IS_PURGE] = @p_bIsPurge
	WHERE
		[PFS_USER_LOG_ID] = @p_iUserLogID	
END
