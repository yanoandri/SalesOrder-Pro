-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spx_deleteitemid
	-- Add the parameters for the stored procedure here
	@ITEMID AS int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE SALES_SO_LITEM
	WHERE SALES_SO_LITEM_ID = @ITEMID
END