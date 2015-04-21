-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_checkItem
-- Create date: yandriyanto 21-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE [dbo].[uspSO_checkItem] 
	@p_SOID AS INT,
	@p_ITEMID AS INT,
	@p_ItemName AS VARCHAR(MAX),
	@p_Quantity AS int,
	@p_Price AS FLOAT
AS
BEGIN
	IF EXISTS(SELECT * FROM dbo.SALES_SO_LITEM WHERE SALES_SO_LITEM_ID = @p_ITEMID AND SALES_SO_ID = @p_SOID)
BEGIN
	UPDATE	dbo.SALES_SO_LITEM WITH(ROWLOCK)
	SET	ITEM_NAME = @p_ItemName,
		QUANTITY = @p_Quantity,
		PRICE = @p_Price
	WHERE SALES_SO_LITEM_ID = @p_ITEMID AND SALES_SO_ID = @p_SOID
END
ELSE	
BEGIN
INSERT INTO dbo.SALES_SO_LITEM WITH(ROWLOCK)
	        ( SALES_SO_ID ,
	          ITEM_NAME ,
	          QUANTITY ,
	          PRICE
	        )
	VALUES  ( @p_SOID , 
	          @p_ItemName , 
	          @p_Quantity , 
	          @p_Price 
	        )
			END
END