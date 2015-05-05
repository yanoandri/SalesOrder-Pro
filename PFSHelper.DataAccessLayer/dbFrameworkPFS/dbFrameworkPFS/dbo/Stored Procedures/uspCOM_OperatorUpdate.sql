
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_OperatorUpdate
	Desc    		:	This store procedure is use to update COM_OPERATOR
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_OperatorUpdate
(
	@iOperatorID INT,
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
	UPDATE COM_OPERATOR SET
		operator_code = @sOperatorCode,
		operator_name = @sOperatorName,
		is_active = @bIsActive,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	com_operator_id = @iOperatorID

	SELECT @@ERROR
END
