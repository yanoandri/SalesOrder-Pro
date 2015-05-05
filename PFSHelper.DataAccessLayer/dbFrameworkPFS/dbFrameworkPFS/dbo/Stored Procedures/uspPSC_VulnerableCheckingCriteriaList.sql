
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_VulnerableCheckingCriteriaList
	Desc    		:	This store procedure is use to get list of PSC_VULNERABLE_CHECKING_CRITERIA
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_VulnerableCheckingCriteriaList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsActive BIT = NULL,
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
		(@bIsActive IS NULL OR pvcc0.is_active = @bIsActive) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, pvcc0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, pvcc0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR pvcc0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, pvcc0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, pvcc0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR pvcc0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		pvcc0.variable LIKE '%' + @sKeyWords + '%')
		
END
