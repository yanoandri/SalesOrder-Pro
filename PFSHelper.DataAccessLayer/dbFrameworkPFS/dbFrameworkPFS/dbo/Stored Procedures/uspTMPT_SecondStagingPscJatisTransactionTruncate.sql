﻿
/***********************************************************************************************************************
   Copyright (c) 2014 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingJatisTransactionTruncate
	Desc    		:	This store procedure is use to truncate TMP_FIRST_STAGING_IST
	Create Date 	:	19 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspTMPT_SecondStagingPscJatisTransactionTruncate]
AS
BEGIN
	TRUNCATE TABLE TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION
END





