-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spx_checkItem] 
	-- Add the parameters for the stored procedure here
	@SOID AS INT,
	@ITEMID AS INT,
	@ItemName AS VARCHAR(MAX),
	@Quantity AS int,
	@Price AS FLOAT
AS
BEGIN
	IF EXISTS(SELECT * FROM dbo.SALES_SO_LITEM WHERE SALES_SO_LITEM_ID = @ITEMID AND SALES_SO_ID = @SOID)
BEGIN
	UPDATE	dbo.SALES_SO_LITEM
	SET	ITEM_NAME = @ItemName,
		QUANTITY = @Quantity,
		PRICE = @Price
	WHERE SALES_SO_LITEM_ID = @ITEMID AND SALES_SO_ID = @SOID
END
ELSE	
BEGIN
INSERT INTO dbo.SALES_SO_LITEM
	        ( SALES_SO_ID ,
	          ITEM_NAME ,
	          QUANTITY ,
	          PRICE
	        )
	VALUES  ( @SOID , -- SALES_SO_ID - int
	          @ItemName , -- ITEM_NAME - varchar(100)
	          @Quantity , -- QUANTITY - int
	          @Price  -- PRICE - float
	        )
			END
END