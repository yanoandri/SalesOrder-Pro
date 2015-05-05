
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_OperatorGet
	Desc    		:	This store procedure is use to get COM_OPERATOR by id
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_OperatorGet
(
	@iOperatorID INT
)
AS
BEGIN
	SELECT
		co0.com_operator_id,
		co0.operator_code,
		co0.operator_name,
		co0.is_active,
		co0.create_date,
		co0.create_by_user_id,
		co0.update_date,
		co0.update_by_user_id
	FROM
		com_operator co0 WITH (NOLOCK)
	WHERE
		co0.com_operator_id = @iOperatorID
END
