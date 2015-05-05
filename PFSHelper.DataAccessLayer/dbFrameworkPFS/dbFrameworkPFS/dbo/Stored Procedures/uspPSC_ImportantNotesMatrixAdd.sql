/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ImportantNotesMatrixAdd
	Desc    		:	This store procedure is use to add PSC_IMPORTANT_NOTES_MATRIX
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ImportantNotesMatrixAdd]
(
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
	DECLARE @iImportantNotesMatrixID INT
    
	INSERT INTO PSC_IMPORTANT_NOTES_MATRIX 
    ( 	
		ref_code,
		ref_object,
		is_p1_checked,
		is_p2_checked,
		is_p3_checked,
		is_p4_checked,
		is_p5_checked,
		is_mismatch_checked,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@sRefCode,
		@sRefObject,
		@bIsP1Checked,
		@bIsP2Checked,
		@bIsP3Checked,
		@bIsP4Checked,
		@bIsP5Checked,
		@bIsMismatchChecked,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @iImportantNotesMatrixID = ISNULL(@@IDENTITY, 0)
	SELECT @iImportantNotesMatrixID
END
