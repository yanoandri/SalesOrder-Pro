
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerSegmentUpdate
	Desc    		:	This store procedure is use to update COM_CUSTOMER_SEGMENT
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerSegmentUpdate
(
	@iCustomerSegmentID INT,
	@sCustomerSegmentName VARCHAR(10),
	@sSegmentCode VARCHAR(10)
)
AS
BEGIN
	UPDATE COM_CUSTOMER_SEGMENT SET
		customer_segment_name = @sCustomerSegmentName,
		segment_code = @sSegmentCode
	WHERE
      	com_customer_segment_id = @iCustomerSegmentID

	SELECT @@ERROR
END
