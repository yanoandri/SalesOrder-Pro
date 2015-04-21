-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_deleteitemid
-- Create date: yandriyanto 21-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE [dbo].[uspSO_deleteitemid]
	-- Add the parameters for the stored procedure here
	@ITEMID AS int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE SALES_SO_LITEM WITH(ROWLOCK)
	WHERE SALES_SO_LITEM_ID = @ITEMID
END