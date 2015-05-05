/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogAdd
	Desc    		:	This store procedure is use to add COM_APPROVAL_LOG
	Create Date 	:	07 Nov 2013		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogAdd]
(
	@iRefID INT,
	@iModuleObjectMemberID INT,
	@iApprovalStatusID SMALLINT,
	@dtCreateDate DATETIME,
	@dtUpdateDate DATETIME,
	@iCreateByUserID INT,
	@iUpdateByUserID INT,
	@xmlDetail XML,
	@sRemark VARCHAR(255),
	@xmlPreviousDetail XML
)
AS
BEGIN
	DECLARE @lApprovalLogID INT
    
	INSERT INTO COM_APPROVAL_LOG 
    ( 	
		ref_id,
		pfs_module_object_member_id,
		com_approval_status_id,
		create_date,
		update_date,
		create_by_user_id,
		update_by_user_id,
		detail,
		remark,
		previous_detail
	)
	VALUES
	(
		@iRefID,
		@iModuleObjectMemberID,
		@iApprovalStatusID,
		@dtCreateDate,
		@dtUpdateDate,
		@iCreateByUserID,
		@iUpdateByUserID,
		@xmlDetail,
		@sRemark,
		@xmlPreviousDetail
	)
    
	SET @lApprovalLogID = ISNULL(@@IDENTITY, 0)
	SELECT @lApprovalLogID
END
