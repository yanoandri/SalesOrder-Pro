
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ImportantNotesMatrixGet
	Desc    		:	This store procedure is use to get PSC_IMPORTANT_NOTES_MATRIX by id
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_ImportantNotesMatrixGetByRefCode
(
	@psRefCode varchar(100)
)
AS
BEGIN
	SELECT
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
		pinm0.REF_CODE = @psRefCode
END
