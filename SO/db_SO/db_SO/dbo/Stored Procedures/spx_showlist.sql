CREATE PROCEDURE dbo.spx_showlist
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT SALES_SO_ID, a.SO_NO, a.ORDER_DATE, b.CUSTOMER_NAME, a.ADDRESS 
	FROM dbo.SALES_SO a JOIN dbo.COM_CUSTOMER b ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID
	ORDER BY SALES_SO_ID ASC
END
