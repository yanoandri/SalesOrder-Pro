/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerObjectiveAdd
	Desc    		:	This store procedure is use to add PSC_CUSTOMER_OBJECTIVE
	Create Date 	:	14 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerObjectiveAdd
(
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
	DECLARE @lCustomerObjectiveID INT
    
	INSERT INTO PSC_CUSTOMER_OBJECTIVE 
    ( 	
		customer_objective_name,
		objective_code,
		description,
		is_active,
		is_deleted,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@sCustomerObjectiveName,
		@sObjectiveCode,
		@sDescription,
		@bIsActive,
		@bIsDeleted,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @lCustomerObjectiveID = ISNULL(@@IDENTITY, 0)
	SELECT @lCustomerObjectiveID
END
