-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spx_deleteso
@SOID VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE dbo.SALES_SO_LITEM WHERE SALES_SO_ID = @SOID
	DELETE dbo.SALES_SO WHERE SALES_SO_ID = @SOID
	
END
