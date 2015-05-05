/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ExceptionLogGet
	Desc    		:	This store procedure is use to get PFS_EXCEPTION_LOG by id
	Create Date 	:	28 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	28 Oct 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ExceptionLogGet]
(
	@lExceptionLogID BIGINT = NULL
)
AS
BEGIN

	SELECT
			pel0.pfs_exception_log_id,
			pel0.reference_number,
			pel0.log_date,
			pel0.source,
			pel0.description
		FROM
			pfs_exception_log pel0 WITH (NOLOCK)
		WHERE
			(@lExceptionLogID IS NULL OR pel0.pfs_exception_log_id = @lExceptionLogID) 
END
