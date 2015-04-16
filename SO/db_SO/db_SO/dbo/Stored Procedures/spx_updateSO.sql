-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spx_updateSO
	@SONO AS VARCHAR(20),
	@Customer AS INT,
	@OrderDate AS DATETIME,
	@Address AS VARCHAR(500),
	@SOID AS int
AS
BEGIN
	UPDATE SALES_SO
	SET	SO_NO = @SONO,
		COM_CUSTOMER_ID = @Customer,
		ORDER_DATE = @OrderDate,
		ADDRESS = @Address
	WHERE SALES_SO_ID = @SOID
END