-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spx_deleteItem
	@ITEMID AS INT,
	@SOID AS INT
AS
BEGIN
	DELETE dbo.SALES_SO_LITEM
	WHERE SALES_SO_LITEM_ID = @ITEMID AND SALES_SO_ID = @SOID
END