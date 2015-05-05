
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_VulnerableCheckingCriteriaGet
	Desc    		:	This store procedure is use to get PSC_VULNERABLE_CHECKING_CRITERIA by id
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_VulnerableCheckingCriteriaGet
(
	@iVulnerableCheckingCriteriaID INT
)
AS
BEGIN
	SELECT
		pvcc0.psc_vulnerable_checking_criteria_id,
		pvcc0.variable,
		pvcc0.value,
		pvcc0.max_value,
		pvcc0.is_active,
		pvcc0.create_date,
		pvcc0.create_by_user_id,
		pvcc0.update_date,
		pvcc0.update_by_user_id
	FROM
		psc_vulnerable_checking_criteria pvcc0 WITH (NOLOCK)
	WHERE
		pvcc0.psc_vulnerable_checking_criteria_id = @iVulnerableCheckingCriteriaID
END
