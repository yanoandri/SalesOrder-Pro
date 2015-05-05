
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_RmwCipDelete
	Desc    		:	This store procedure is use to delete PSC_RMW_CIP
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_RmwCipDelete
(
	@iRmwCipID INT
)
AS
BEGIN
	DELETE PSC_RMW_CIP
    WHERE PSC_RMW_CIP_ID = @iRmwCipID
END
