
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionDelete
	Desc    		:	This store procedure is use to delete PSC_JATIS_TRANSACTION
	Create Date 	:	11 Feb 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_JatisTransactionDelete
(
	@iJatisTransactionID INT
)
AS
BEGIN
	DELETE PSC_JATIS_TRANSACTION
    WHERE PSC_JATIS_TRANSACTION_ID = @iJatisTransactionID
END
