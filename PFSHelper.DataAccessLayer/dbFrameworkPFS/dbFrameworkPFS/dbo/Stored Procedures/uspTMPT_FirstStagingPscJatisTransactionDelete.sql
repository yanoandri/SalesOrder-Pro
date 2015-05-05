
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscJatisTransactionDelete
	Desc    		:	This store procedure is use to delete TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingPscJatisTransactionDelete
(
	@iFirstStagingPscJatisTransactionID INT
)
AS
BEGIN
	DELETE TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION
    WHERE TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_ID = @iFirstStagingPscJatisTransactionID
END
