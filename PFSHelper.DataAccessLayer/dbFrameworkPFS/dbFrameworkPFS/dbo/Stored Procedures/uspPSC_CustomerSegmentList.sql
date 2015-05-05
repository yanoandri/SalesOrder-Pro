
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerSegmentList
	Desc    		:	This store procedure is use to get list of COM_CUSTOMER_SEGMENT
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerSegmentList
(
	@sKeyWords VARCHAR(1280) = NULL
)
AS
BEGIN
	SELECT
		ccs0.com_customer_segment_id,
		ccs0.customer_segment_name,
		ccs0.segment_code
	FROM
		com_customer_segment ccs0 WITH (NOLOCK)
	WHERE
		(@sKeyWords IS NULL OR
		ccs0.customer_segment_name LIKE '%' + @sKeyWords + '%' OR
		ccs0.segment_code LIKE '%' + @sKeyWords + '%')
END
