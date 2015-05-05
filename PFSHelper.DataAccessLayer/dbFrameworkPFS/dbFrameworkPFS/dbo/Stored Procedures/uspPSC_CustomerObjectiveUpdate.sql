
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerObjectiveUpdate
	Desc    		:	This store procedure is use to update PSC_CUSTOMER_OBJECTIVE
	Create Date 	:	14 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerObjectiveUpdate
(
	@lCustomerObjectiveID BIGINT,
	@sCustomerObjectiveName VARCHAR(100),
	@sObjectiveCode VARCHAR(3),
	@sDescription VARCHAR(255),
	@bIsActive BIT,
	@bIsDeleted BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_CUSTOMER_OBJECTIVE SET
		customer_objective_name = @sCustomerObjectiveName,
		objective_code = @sObjectiveCode,
		description = @sDescription,
		is_active = @bIsActive,
		is_deleted = @bIsDeleted,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	psc_customer_objective_id = @lCustomerObjectiveID

	SELECT @@ERROR
END
