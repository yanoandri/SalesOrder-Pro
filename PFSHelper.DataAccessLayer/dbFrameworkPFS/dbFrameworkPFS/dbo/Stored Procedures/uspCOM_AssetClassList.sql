
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_AssetClassList
	Desc    		:	This store procedure is use to get list of COM_ASSET_CLASS
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_AssetClassList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsActive BIT = NULL,
	@bIsDeleted BIT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL
	,@iPageSize INT = 10
    ,@iPageNumber INT = 1 
)
AS
BEGIN
	DECLARE @iFirstRow INT, @iLastRow INT
    SET @iFirstRow = NULL
    SET @iLastRow= NULL
	
	SELECT
		@iFirstRow = ( @iPageNumber - 1) * @iPageSize + 1,
        @iLastRow = (@iPageNumber - 1) * @iPageSize + @iPageSize;
    
	WITH Paging AS (
		SELECT
		ROW_NUMBER() OVER (ORDER BY cac0.com_asset_class_id ASC) AS row_number,
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
		(@bIsActive IS NULL OR cac0.is_active = @bIsActive) AND
		(@bIsDeleted IS NULL OR cac0.is_deleted = @bIsDeleted) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, cac0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, cac0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR cac0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, cac0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, cac0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR cac0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		cac0.asset_class_code LIKE '%' + @sKeyWords + '%' OR
		cac0.asset_class_name LIKE '%' + @sKeyWords + '%' OR
		cac0.description LIKE '%' + @sKeyWords + '%')
		GROUP BY		
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
		)
		SELECT		
		p.com_asset_class_id,
		p.asset_class_code,
		p.asset_class_name,
		p.description,
		p.concentration_limit_percentage,
		p.is_active,
		p.is_deleted,
		p.create_date,
		p.create_by_user_id,
		p.update_date,
		p.update_by_user_id
		FROM Paging p WHERE (@iPageSize IS NULL OR @iFirstRow IS NULL OR @iLastRow IS NULL) OR (p.row_number BETWEEN @iFirstRow AND @iLastRow)
END
