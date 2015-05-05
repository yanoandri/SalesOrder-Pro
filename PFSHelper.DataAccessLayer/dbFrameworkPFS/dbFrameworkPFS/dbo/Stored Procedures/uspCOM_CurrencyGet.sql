
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CurrencyGet
	Desc    		:	This store procedure is use to get COM_CURRENCY by id
	Create Date 	:	14 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_CurrencyGet
(
	@lCurrencyID BIGINT
)
AS
BEGIN
	SELECT
		cc0.com_currency_id,
		cc0.currency_code,
		cc0.description,
		cc0.is_active,
		cc0.is_deleted,
		cc0.create_date,
		cc0.create_by_user_id,
		cc0.update_date,
		cc0.update_by_user_id
	FROM
		com_currency cc0 WITH (NOLOCK)
	WHERE
		cc0.com_currency_id = @lCurrencyID
END
