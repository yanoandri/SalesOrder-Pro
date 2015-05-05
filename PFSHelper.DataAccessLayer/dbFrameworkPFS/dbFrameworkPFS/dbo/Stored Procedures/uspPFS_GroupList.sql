/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_GroupGet
	Desc    		:	This store procedure is use to get list of PFS_GROUP by id
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_GroupList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsActive BIT = NULL ,
	@bIsNeedApproval BIT = NULL ,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL ,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL 
)
AS
BEGIN

                
	SELECT
			pg0.pfs_group_id,
			pg0.group_name,
			pg0.group_descr,
			pg0.is_active,
			pg0.is_need_approval,
			pg0.create_date,
			pg0.create_by_user_id,
			pg0.update_date,
			pg0.update_by_user_id
		FROM
			pfs_group pg0 WITH (NOLOCK)
		WHERE
			(@bIsActive IS NULL OR pg0.is_active = @bIsActive) AND
			(@bIsNeedApproval IS NULL OR pg0.is_need_approval = @bIsNeedApproval) AND
			(
				@dtCreateDateFrom IS NULL OR @dtCreateDateTo IS NULL OR 
				FLOOR(CAST(pg0.create_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtCreateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtCreateDateTo AS FLOAT))
			) AND				
			(@iCreateByUserID IS NULL OR pg0.create_by_user_id = @iCreateByUserID) AND
			(
				@dtUpdateDateFrom IS NULL OR @dtUpdateDateTo IS NULL OR 
				FLOOR(CAST(pg0.update_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtUpdateDateFrom AS FLOAT)) AND FLOOR(CAST(@dtUpdateDateTo AS FLOAT))
			) AND				
			(@iUpdateByUserID IS NULL OR pg0.update_by_user_id = @iUpdateByUserID) AND
			(@sKeyWords IS NULL OR
			pg0.group_name LIKE '%' + @sKeyWords + '%' OR
			pg0.group_descr LIKE '%' + @sKeyWords + '%')
	
END
