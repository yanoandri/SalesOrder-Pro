
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_AssetClassGet
	Desc    		:	This store procedure is use to get COM_ASSET_CLASS by id
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_AssetClassGet
(
	@iAssetClassID INT
)
AS
BEGIN
	SELECT
		cac0.com_asset_class_id,
		cac0.asset_class_code,
		cac0.asset_class_name,
		cac0.description,
		cac0.concentration_limit_percentage,
		cac0.is_active,
		cac0.is_deleted,
		cac0.create_date,
		cac0.create_by_user_id,
		cac0.update_date,
		cac0.update_by_user_id
	FROM
		com_asset_class cac0 WITH (NOLOCK)
	WHERE
		cac0.com_asset_class_id = @iAssetClassID
END
