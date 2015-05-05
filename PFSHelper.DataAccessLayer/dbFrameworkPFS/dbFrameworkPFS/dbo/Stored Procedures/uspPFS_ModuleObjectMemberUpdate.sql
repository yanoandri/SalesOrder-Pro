/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_ModuleObjectMemberUpdate
	Desc    		:	This store procedure is use to update PFS_MODULE_OBJECT_MEMBER
	Create Date 	:	01 Nov 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	01 Nov 2011		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberUpdate]
(
	@iModuleObjectMemberID INT,
	@iModuleObjectID INT,
	@sMemberCode VARCHAR(50),
	@sMemberName VARCHAR(100),
	@sMemberDescr VARCHAR(500),
	@iIndexOrder SMALLINT,
	@bIsWithApprovalProccess BIT
)
AS
BEGIN

	UPDATE [PFS_MODULE_OBJECT_MEMBER] SET
		pfs_module_object_id = @iModuleObjectID,
		member_code = @sMemberCode,
		member_name = @sMemberName,
		member_descr = @sMemberDescr,
		index_order = @iIndexOrder,
		is_with_approval_proccess = @bIsWithApprovalProccess
	WHERE
      	pfs_module_object_member_id = @iModuleObjectMemberID
			
	SELECT @@ERROR		
END
