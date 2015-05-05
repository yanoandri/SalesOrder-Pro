/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_VulnerableCheckingCriteriaAdd
	Desc    		:	This store procedure is use to add PSC_VULNERABLE_CHECKING_CRITERIA
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_VulnerableCheckingCriteriaAdd
(
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
	DECLARE @iVulnerableCheckingCriteriaID INT
    
	INSERT INTO PSC_VULNERABLE_CHECKING_CRITERIA 
    ( 	
		variable,
		value,
		max_value,
		is_active,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@sVariable,
		@iValue,
		@iMaxValue,
		@bIsActive,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iVulnerableCheckingCriteriaID = ISNULL(@@IDENTITY, 0)
	SELECT @iVulnerableCheckingCriteriaID
END
