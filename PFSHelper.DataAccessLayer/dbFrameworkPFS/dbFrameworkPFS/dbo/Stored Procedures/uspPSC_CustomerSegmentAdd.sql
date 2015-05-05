/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerSegmentAdd
	Desc    		:	This store procedure is use to add COM_CUSTOMER_SEGMENT
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerSegmentAdd
(
	@sCustomerSegmentName VARCHAR(10),
	@sSegmentCode VARCHAR(10)
)
AS
BEGIN
	DECLARE @iCustomerSegmentID INT
    
	INSERT INTO COM_CUSTOMER_SEGMENT 
    ( 	
		customer_segment_name,
		segment_code
	)
	VALUES
	(
		@sCustomerSegmentName,
		@sSegmentCode
	)
    
	SET @iCustomerSegmentID = ISNULL(@@IDENTITY, 0)
	SELECT @iCustomerSegmentID
END
