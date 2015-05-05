-- =============================================
-- Author:		kprasetyo
-- Create date: 14 Feb 2012
-- Description:	using to check is the user have relation to other tables
-- Sample:	uspPFS_UserCheckTableRelations 52
-- =============================================
CREATE PROCEDURE [dbo].[uspPFS_UserCheckTableRelations]
(
	@iUserID INT
)
AS
BEGIN
		  SELECT CREATE_BY_USER_ID FROM dbo.COM_APPROVAL_LOG WHERE CREATE_BY_USER_ID = @iUserID
	UNION SELECT UPDATE_BY_USER_ID FROM dbo.COM_APPROVAL_LOG WHERE UPDATE_BY_USER_ID = @iUserID
	
	UNION SELECT CREATE_BY_USER_ID FROM dbo.PFS_HOLIDAY WHERE CREATE_BY_USER_ID = @iUserID
	UNION SELECT UPDATE_BY_USER_ID FROM dbo.PFS_HOLIDAY WHERE UPDATE_BY_USER_ID = @iUserID
END
