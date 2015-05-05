/*****************************************************************************
  Copyright (c) 2006, PT Profescipta Wahanatehnik. All Rights Reserved.
  This software, all associated documentation, and all copies
  are CONFIDENTIAL INFORMATION of PT Profescipta Wahanatehnik.
  DESCRIPTION
	Name    	:   [uspPFS_ModuleObjectMemberGroupDeleteByGroupID]
	Desc    	:	This procedure is used to delete existing group access.
	Input   	: 	@sModuleObjectMemberGroupID, @sGroupID
	Output  	:	
	Comments	:	
	Status  	: 	
	Sample Data :	EXEC sppfs_ModuleObjectMemberGroupDelete '2'
					EXEC sppfs_ModuleObjectMemberGroupDelete '2, 3, 4'
					EXEC sppfs_ModuleObjectMemberGroupDelete NULL, 3
******************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_ModuleObjectMemberGroupDeleteByGroupIDAndMemberGroupID] (
	@sModuleObjectMemberGroupID AS VARCHAR(120), -- assume : batch deletion for each 10 records --
	@iGroupID INT
)
AS

	IF (@sModuleObjectMemberGroupID IS NOT NULL)
		BEGIN
			DECLARE @sSQL NVARCHAR(4000)
			SET @sSQL = 'DELETE FROM pfs_module_object_member_group WHERE pfs_group_id = ' + CAST(@iGroupID AS VARCHAR) + ' AND pfs_module_object_member_id NOT IN (' + @sModuleObjectMemberGroupID + ')'
			EXEC sp_executesql @sSQL
		END
	ELSE
		BEGIN
			DELETE FROM pfs_module_object_member_group
			WHERE pfs_group_id = @iGroupID
		END

	SELECT @@ERROR
