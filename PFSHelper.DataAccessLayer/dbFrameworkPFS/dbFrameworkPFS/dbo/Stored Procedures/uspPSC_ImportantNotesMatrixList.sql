
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ImportantNotesMatrixList
	Desc    		:	This store procedure is use to get list of PSC_IMPORTANT_NOTES_MATRIX
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ImportantNotesMatrixList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@bIsP1Checked BIT = NULL,
	@bIsP2Checked BIT = NULL,
	@bIsP3Checked BIT = NULL,
	@bIsP4Checked BIT = NULL,
	@bIsP5Checked BIT = NULL,
	@bIsMismatchChecked BIT = NULL,
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
		ROW_NUMBER() OVER (ORDER BY pinm0.psc_important_notes_matrix_id ASC) AS row_number,
			pinm0.psc_important_notes_matrix_id,
		pinm0.ref_code,
		pinm0.ref_object,
		pinm0.is_p1_checked,
		pinm0.is_p2_checked,
		pinm0.is_p3_checked,
		pinm0.is_p4_checked,
		pinm0.is_p5_checked,
		pinm0.is_mismatch_checked,
		pinm0.create_date,
		pinm0.create_by_user_id,
		pinm0.update_date,
		pinm0.update_by_user_id
	FROM
		psc_important_notes_matrix pinm0 WITH (NOLOCK)
	WHERE
		(@bIsP1Checked IS NULL OR pinm0.is_p1_checked = @bIsP1Checked) AND
		(@bIsP2Checked IS NULL OR pinm0.is_p2_checked = @bIsP2Checked) AND
		(@bIsP3Checked IS NULL OR pinm0.is_p3_checked = @bIsP3Checked) AND
		(@bIsP4Checked IS NULL OR pinm0.is_p4_checked = @bIsP4Checked) AND
		(@bIsP5Checked IS NULL OR pinm0.is_p5_checked = @bIsP5Checked) AND
		(@bIsMismatchChecked IS NULL OR pinm0.is_mismatch_checked = @bIsMismatchChecked) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, pinm0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, pinm0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR pinm0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, pinm0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, pinm0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR pinm0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		pinm0.ref_code LIKE '%' + @sKeyWords + '%' OR
		pinm0.ref_object LIKE '%' + @sKeyWords + '%')
		GROUP BY		
		pinm0.psc_important_notes_matrix_id,
		pinm0.ref_code,
		pinm0.ref_object,
		pinm0.is_p1_checked,
		pinm0.is_p2_checked,
		pinm0.is_p3_checked,
		pinm0.is_p4_checked,
		pinm0.is_p5_checked,
		pinm0.is_mismatch_checked,
		pinm0.create_date,
		pinm0.create_by_user_id,
		pinm0.update_date,
		pinm0.update_by_user_id
		)
		SELECT		
		p.psc_important_notes_matrix_id,
		p.ref_code,
		p.ref_object,
		p.is_p1_checked,
		p.is_p2_checked,
		p.is_p3_checked,
		p.is_p4_checked,
		p.is_p5_checked,
		p.is_mismatch_checked,
		p.create_date,
		p.create_by_user_id,
		p.update_date,
		p.update_by_user_id
		FROM Paging p WHERE (@iPageSize IS NULL OR @iFirstRow IS NULL OR @iLastRow IS NULL) OR (p.row_number BETWEEN @iFirstRow AND @iLastRow)
END
