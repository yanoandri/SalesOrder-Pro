
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_VulnerableCheckingCriteriaDelete
	Desc    		:	This store procedure is use to delete PSC_VULNERABLE_CHECKING_CRITERIA
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_VulnerableCheckingCriteriaDelete
(
	@iVulnerableCheckingCriteriaID INT
)
AS
BEGIN
	DELETE PSC_VULNERABLE_CHECKING_CRITERIA
    WHERE PSC_VULNERABLE_CHECKING_CRITERIA_ID = @iVulnerableCheckingCriteriaID
END
