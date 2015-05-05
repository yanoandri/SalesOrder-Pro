
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingComCustomerDelete
	Desc    		:	This store procedure is use to delete TMPT_FIRST_STAGING_COM_CUSTOMER
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingComCustomerDelete
(
	@iFirstStagingComCustomerID INT
)
AS
BEGIN
	DELETE TMPT_FIRST_STAGING_COM_CUSTOMER
    WHERE TMPT_FIRST_STAGING_COM_CUSTOMER_ID = @iFirstStagingComCustomerID
END
