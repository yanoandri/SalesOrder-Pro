
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerObjectiveDelete
	Desc    		:	This store procedure is use to delete PSC_CUSTOMER_OBJECTIVE
	Create Date 	:	14 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerObjectiveDelete
(
	@lCustomerObjectiveID BIGINT
)
AS
BEGIN
	DELETE PSC_CUSTOMER_OBJECTIVE
    WHERE PSC_CUSTOMER_OBJECTIVE_ID = @lCustomerObjectiveID
END
