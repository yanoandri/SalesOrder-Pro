-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spx_detailItem]
	-- Add the parameters for the stored procedure here
	@SOID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  SALES_SO_LITEM_ID ,
	        SALES_SO_ID ,
	        ITEM_NAME ,
	        QUANTITY ,
	        PRICE
	FROM SALES_SO_LITEM 
	WHERE SALES_SO_ID = @SOID
END