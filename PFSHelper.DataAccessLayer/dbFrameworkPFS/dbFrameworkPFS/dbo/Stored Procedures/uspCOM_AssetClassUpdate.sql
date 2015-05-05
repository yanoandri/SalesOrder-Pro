
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_AssetClassUpdate
	Desc    		:	This store procedure is use to update COM_ASSET_CLASS
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_AssetClassUpdate
(
	@iAssetClassID INT,
	@sAssetClassCode VARCHAR(15),
	@sAssetClassName VARCHAR(100),
	@sDescription VARCHAR(255),
	@dConcentrationLimitPercentage FLOAT,
	@bIsActive BIT,
	@bIsDeleted BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE COM_ASSET_CLASS SET
		asset_class_code = @sAssetClassCode,
		asset_class_name = @sAssetClassName,
		description = @sDescription,
		concentration_limit_percentage = @dConcentrationLimitPercentage,
		is_active = @bIsActive,
		is_deleted = @bIsDeleted,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	com_asset_class_id = @iAssetClassID

	SELECT @@ERROR
END
