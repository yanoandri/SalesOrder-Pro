
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingPscJatisTransactionDelete
	Desc    		:	This store procedure is use to delete TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION
	Create Date 	:	11 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingPscJatisTransactionDelete
(
	@iSecondStagingPscJatisTransactionID INT
)
AS
BEGIN
	DELETE TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION
    WHERE TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION_ID = @iSecondStagingPscJatisTransactionID
END
