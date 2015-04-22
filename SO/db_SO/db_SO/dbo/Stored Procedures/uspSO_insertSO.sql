-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_insertSO
-- Create date: yandriyanto 21-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE [dbo].[uspSO_insertSO]
	-- Add the parameters for the stored procedure here
    @p_SONO AS VARCHAR(20) ,
    @p_OrderDate AS DATETIME ,
    @p_CUSTOMER AS INT ,
    @p_ADDRESS AS VARCHAR(MAX)
AS 
    BEGIN
        INSERT  INTO [dbo].[SALES_SO] WITH ( ROWLOCK )
                ( [SO_NO] ,
                  [ORDER_DATE] ,
                  [COM_CUSTOMER_ID] ,
                  [ADDRESS]
                )
        VALUES  ( @p_SONO ,
                  @p_OrderDate ,
                  @p_CUSTOMER ,
                  @p_ADDRESS
                )

        SELECT  @@IDENTITY AS lastId
    END