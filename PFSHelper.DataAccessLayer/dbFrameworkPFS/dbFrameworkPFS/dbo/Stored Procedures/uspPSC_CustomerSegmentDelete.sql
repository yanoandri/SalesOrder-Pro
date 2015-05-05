
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerSegmentDelete
	Desc    		:	This store procedure is use to delete COM_CUSTOMER_SEGMENT
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerSegmentDelete
(
	@iCustomerSegmentID INT
)
AS
BEGIN
	DELETE COM_CUSTOMER_SEGMENT
    WHERE COM_CUSTOMER_SEGMENT_ID = @iCustomerSegmentID
END
