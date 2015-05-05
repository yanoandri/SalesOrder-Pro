﻿
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_AssetClassDelete
	Desc    		:	This store procedure is use to delete COM_ASSET_CLASS
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_AssetClassDelete
(
	@iAssetClassID INT
)
AS
BEGIN
	DELETE COM_ASSET_CLASS
    WHERE COM_ASSET_CLASS_ID = @iAssetClassID
END
