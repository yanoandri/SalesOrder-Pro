
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_VulnerableCheckingCriteriaUpdate
	Desc    		:	This store procedure is use to update PSC_VULNERABLE_CHECKING_CRITERIA
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_VulnerableCheckingCriteriaUpdate
(
	@iVulnerableCheckingCriteriaID INT,
	@sVariable VARCHAR(25),
	@iValue INT,
	@iMaxValue INT,
	@bIsActive BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_VULNERABLE_CHECKING_CRITERIA SET
		variable = @sVariable,
		value = @iValue,
		max_value = @iMaxValue,
		is_active = @bIsActive,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	psc_vulnerable_checking_criteria_id = @iVulnerableCheckingCriteriaID

	SELECT @@ERROR
END
