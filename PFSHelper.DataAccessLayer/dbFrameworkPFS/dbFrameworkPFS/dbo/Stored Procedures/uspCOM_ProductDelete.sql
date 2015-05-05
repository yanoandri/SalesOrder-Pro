
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductDelete
	Desc    		:	This store procedure is use to delete COM_PRODUCT
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_ProductDelete
(
	@iProductID INT
)
AS
BEGIN
	DELETE COM_PRODUCT
    WHERE COM_PRODUCT_ID = @iProductID
END
