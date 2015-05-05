/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_SystemLogGet
	Desc    		:	This store procedure is use to get list of PFS_SYSTEM_LOG by id
	Create Date 	:	31 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	31 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_SystemLogList]
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iProcessID SMALLINT = NULL ,
	@dtLogDateFrom DATETIME = NULL,
	@dtLogDateTo DATETIME = NULL
)
AS
BEGIN

                
	SELECT
			psl0.pfs_system_log_id,
			psl0.reference_number,
			psl0.com_process_id,
			psl0.log_date,
			psl0.status,
			psl0.description,
			psl0.detail
		FROM
			pfs_system_log psl0 WITH (NOLOCK)
		WHERE
			(@iProcessID IS NULL OR psl0.com_process_id = @iProcessID) AND
			(
				@dtLogDateFrom IS NULL OR @dtLogDateTo IS NULL OR 
				FLOOR(CAST(psl0.log_date AS FLOAT)) BETWEEN FLOOR(CAST(@dtLogDateFrom AS FLOAT)) AND FLOOR(CAST(@dtLogDateTo AS FLOAT))
			) 	AND
			(@sKeyWords IS NULL OR
			psl0.reference_number LIKE '%' + @sKeyWords + '%' OR
			psl0.description LIKE '%' + @sKeyWords + '%')
	
END
