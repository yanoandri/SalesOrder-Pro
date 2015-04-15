-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spx_insertSOItem
	-- Add the parameters for the stored procedure here
	@SOID AS INT,
	@ItemName AS VARCHAR,
	@Quantity AS INT,
	@Price AS FLOAT
AS
BEGIN
	
	INSERT INTO [dbo].[SALES_SO_LITEM]
           ([SALES_SO_ID]
           ,[ITEM_NAME]
           ,[QUANTITY]
           ,[PRICE])
     VALUES
           (@SOID
           ,@ItemName
           ,@Quantity
           ,@Price)
END