
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerObjectiveList
	Desc    		:	This store procedure is use to get list of PSC_CUSTOMER_OBJECTIVE
	Create Date 	:	14 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerObjectiveList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsActive BIT = NULL,
	@bIsDeleted BIT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL
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
		(@bIsActive IS NULL OR pco0.is_active = @bIsActive) AND
		(@bIsDeleted IS NULL OR pco0.is_deleted = @bIsDeleted) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, pco0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, pco0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR pco0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, pco0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, pco0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR pco0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		pco0.customer_objective_name LIKE '%' + @sKeyWords + '%' OR
		pco0.objective_code LIKE '%' + @sKeyWords + '%' OR
		pco0.description LIKE '%' + @sKeyWords + '%')
END
