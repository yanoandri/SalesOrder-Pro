-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spx_insertSO]
	-- Add the parameters for the stored procedure here
	
	@SONO AS VARCHAR(20),
	@OrderDate AS DATETIME,
	@CUSTOMER AS INT,
	@ADDRESS AS VARCHAR(500)
AS
BEGIN
	INSERT INTO [dbo].[SALES_SO]
           ([SO_NO]
           ,[ORDER_DATE]
           ,[COM_CUSTOMER_ID]
           ,[ADDRESS])
     VALUES
           (@SONO
           ,@OrderDate
           ,@CUSTOMER
           ,@ADDRESS)

	SELECT @@IDENTITY AS lastId
END