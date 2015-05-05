
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_OperatorDelete
	Desc    		:	This store procedure is use to delete COM_OPERATOR
	Create Date 	:	19 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_OperatorDelete
(
	@iOperatorID INT
)
AS
BEGIN
	DELETE COM_OPERATOR
    WHERE COM_OPERATOR_ID = @iOperatorID
END
