/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_OperatorAdd
	Desc    		:	This store procedure is use to add COM_OPERATOR
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_OperatorAdd
(
	@sOperatorCode VARCHAR(3),
	@sOperatorName VARCHAR(10),
	@bIsActive BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	DECLARE @iOperatorID INT
    
	INSERT INTO COM_OPERATOR 
    ( 	
		operator_code,
		operator_name,
		is_active,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@sOperatorCode,
		@sOperatorName,
		@bIsActive,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iOperatorID = ISNULL(@@IDENTITY, 0)
	SELECT @iOperatorID
END
