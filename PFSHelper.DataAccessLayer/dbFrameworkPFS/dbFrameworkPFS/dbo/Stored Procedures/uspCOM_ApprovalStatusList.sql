/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalStatusGet
	Desc    		:	This store procedure is use to get list of COM_APPROVAL_STATUS by id
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalStatusList]
(
	@sKeyWords VARCHAR(1280) = NULL
)
AS
BEGIN

                
	SELECT
			cas0.com_approval_status_id,
			cas0.com_approval_status_code,
			cas0.description
		FROM
			com_approval_status cas0 WITH (NOLOCK)
		WHERE
			(@sKeyWords IS NULL OR
			cas0.com_approval_status_code LIKE '%' + @sKeyWords + '%' OR
			cas0.description LIKE '%' + @sKeyWords + '%')
	
END
