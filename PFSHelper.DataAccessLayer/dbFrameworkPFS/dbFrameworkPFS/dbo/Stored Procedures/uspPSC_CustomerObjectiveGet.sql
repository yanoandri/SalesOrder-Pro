
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerObjectiveGet
	Desc    		:	This store procedure is use to get PSC_CUSTOMER_OBJECTIVE by id
	Create Date 	:	14 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerObjectiveGet
(
	@lCustomerObjectiveID BIGINT
)
AS
BEGIN
	SELECT
		pco0.psc_customer_objective_id,
		pco0.customer_objective_name,
		pco0.objective_code,
		pco0.description,
		pco0.is_active,
		pco0.is_deleted,
		pco0.create_date,
		pco0.create_by_user_id,
		pco0.update_date,
		pco0.update_by_user_id
	FROM
		psc_customer_objective pco0 WITH (NOLOCK)
	WHERE
		pco0.psc_customer_objective_id = @lCustomerObjectiveID
END
