
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CustomerDelete
	Desc    		:	This store procedure is use to delete COM_CUSTOMER
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_CustomerDelete
(
	@iCustomerID INT
)
AS
BEGIN
	DELETE COM_CUSTOMER
    WHERE COM_CUSTOMER_ID = @iCustomerID
END
