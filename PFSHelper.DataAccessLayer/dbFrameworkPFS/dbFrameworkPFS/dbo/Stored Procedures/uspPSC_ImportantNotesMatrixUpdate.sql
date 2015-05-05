
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ImportantNotesMatrixUpdate
	Desc    		:	This store procedure is use to update PSC_IMPORTANT_NOTES_MATRIX
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ImportantNotesMatrixUpdate]
(
	@iImportantNotesMatrixID INT,
	@sRefCode VARCHAR(50),
	@sRefObject VARCHAR(50),
	@bIsP1Checked BIT,
	@bIsP2Checked BIT,
	@bIsP3Checked BIT,
	@bIsP4Checked BIT,
	@bIsP5Checked BIT,
	@bIsMismatchChecked BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_IMPORTANT_NOTES_MATRIX SET
		ref_code = @sRefCode,
		ref_object = @sRefObject,
		is_p1_checked = @bIsP1Checked,
		is_p2_checked = @bIsP2Checked,
		is_p3_checked = @bIsP3Checked,
		is_p4_checked = @bIsP4Checked,
		is_p5_checked = @bIsP5Checked,
		is_mismatch_checked = @bIsMismatchChecked,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	psc_important_notes_matrix_id = @iImportantNotesMatrixID

	SELECT @@ERROR
END
