/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberAdd
	Desc    		:	This store procedure is use to add PFS_MODULE_OBJECT_MEMBER
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberAdd]
(
	@iModuleObjectID INT,
	@sMemberCode VARCHAR(50),
	@sMemberName VARCHAR(100),
	@sMemberDescr VARCHAR(500),
	@iIndexOrder SMALLINT,
	@bIsWithApprovalProccess BIT
)
AS
BEGIN

	DECLARE @iModuleObjectMemberID INT
	INSERT INTO [PFS_MODULE_OBJECT_MEMBER] 
    ( 	
		pfs_module_object_id,
		member_code,
		member_name,
		member_descr,
		index_order,
		is_with_approval_proccess
	)
	VALUES
	(
		@iModuleObjectID,
		@sMemberCode,
		@sMemberName,
		@sMemberDescr,
		@iIndexOrder,
		@bIsWithApprovalProccess
	)
	
	SET  @iModuleObjectMemberID = ISNULL(@@IDENTITY, 0)
	SELECT @iModuleObjectMemberID
	
END
