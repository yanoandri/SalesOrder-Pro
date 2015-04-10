-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spx_geteditsalesitem 
	-- Add the parameters for the stored procedure here
	
	@SOID as varchar(MAX) 
AS	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.SALES_SO_ID, b.ORDER_DATE, c.CUSTOMER_NAME, b.ADDRESS, a.ITEM_NAME, a.QUANTITY, a.PRICE, (a.QUANTITY * a.PRICE) AS TOTAL   
	FROM dbo.SALES_SO_LITEM a JOIN SALES_SO b 
	ON a.SALES_SO_ID = b.SALES_SO_ID JOIN dbo.COM_CUSTOMER c 
	ON b.COM_CUSTOMER_ID = c.COM_CUSTOMER_ID 
	WHERE b.SALES_SO_ID = @SOID
END
