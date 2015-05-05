/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_AssetClassAdd
	Desc    		:	This store procedure is use to add COM_ASSET_CLASS
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_AssetClassAdd
(
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
	DECLARE @iAssetClassID INT
    
	INSERT INTO COM_ASSET_CLASS 
    ( 	
		asset_class_code,
		asset_class_name,
		description,
		concentration_limit_percentage,
		is_active,
		is_deleted,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@sAssetClassCode,
		@sAssetClassName,
		@sDescription,
		@dConcentrationLimitPercentage,
		@bIsActive,
		@bIsDeleted,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iAssetClassID = ISNULL(@@IDENTITY, 0)
	SELECT @iAssetClassID
END
