/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFSCommon_SysParamList
	Desc    		:	
	Create Date 	:	2012-01-12 - ssaputra
	Modified Date 	:	
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFSCommon_SysParamList]
AS
BEGIN
	SELECT
		[psp].[CODE],	    
	    [psp].[VALUE],
	    [psp].[IS_ENCRYPTED]
	FROM
		[dbo].[PFS_SYS_PARAM] AS psp WITH(READPAST)
END
