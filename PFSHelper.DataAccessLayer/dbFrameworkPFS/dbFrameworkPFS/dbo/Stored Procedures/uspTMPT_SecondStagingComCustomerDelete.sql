
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingComCustomerDelete
	Desc    		:	This store procedure is use to delete TMPT_SECOND_STAGING_COM_CUSTOMER
	Create Date 	:	21 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingComCustomerDelete
(
	@iSecondStagingComCustomerID INT
)
AS
BEGIN
	DELETE TMPT_SECOND_STAGING_COM_CUSTOMER
    WHERE TMPT_SECOND_STAGING_COM_CUSTOMER_ID = @iSecondStagingComCustomerID
END
