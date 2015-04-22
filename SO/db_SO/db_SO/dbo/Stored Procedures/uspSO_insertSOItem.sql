-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_insertSOItem
-- Create date: yandriyanto 21-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE [dbo].[uspSO_insertSOItem]
    @p_SOID AS INT ,
    @p_ItemName AS VARCHAR(MAX) ,
    @p_Quantity AS INT ,
    @p_Price AS FLOAT
AS 
    BEGIN
	
        INSERT  INTO [dbo].[SALES_SO_LITEM] WITH ( ROWLOCK )
                ( [SALES_SO_ID] ,
                  [ITEM_NAME] ,
                  [QUANTITY] ,
                  [PRICE]
                )
        VALUES  ( @p_SOID ,
                  @p_ItemName ,
                  @p_Quantity ,
                  @p_Price
                )
    END