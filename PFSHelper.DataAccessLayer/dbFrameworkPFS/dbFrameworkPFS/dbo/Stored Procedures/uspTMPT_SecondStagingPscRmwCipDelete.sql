
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingPscRmwCipDelete
	Desc    		:	This store procedure is use to delete TMPT_SECOND_STAGING_PSC_RMW_CIP
	Create Date 	:	23 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingPscRmwCipDelete
(
	@iSecondStagingPscRmwCipID INT
)
AS
BEGIN
	DELETE TMPT_SECOND_STAGING_PSC_RMW_CIP
    WHERE TMPT_SECOND_STAGING_PSC_RMW_CIP_ID = @iSecondStagingPscRmwCipID
END
