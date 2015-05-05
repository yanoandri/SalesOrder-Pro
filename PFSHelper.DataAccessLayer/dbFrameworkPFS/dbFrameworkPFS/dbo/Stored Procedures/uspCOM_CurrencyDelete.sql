
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CurrencyDelete
	Desc    		:	This store procedure is use to delete COM_CURRENCY
	Create Date 	:	14 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_CurrencyDelete
(
	@lCurrencyID BIGINT
)
AS
BEGIN
	DELETE COM_CURRENCY
    WHERE COM_CURRENCY_ID = @lCurrencyID
END
