
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_OperatorList
	Desc    		:	This store procedure is use to get list of COM_OPERATOR
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_OperatorList
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
		(@bIsActive IS NULL OR co0.is_active = @bIsActive) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, co0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, co0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR co0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, co0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, co0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR co0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		co0.operator_code LIKE '%' + @sKeyWords + '%' OR
		co0.operator_name LIKE '%' + @sKeyWords + '%')
END
