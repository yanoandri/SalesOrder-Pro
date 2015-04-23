-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_findlist 
-- Create date: yandriyanto 23-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE uspSO_findlist 
	-- Add the parameters for the stored procedure here
	@Keyword AS VARCHAR(MAX),
    @OrderDate AS DATETIME
AS
BEGIN
	IF @Keyword != '' 
    BEGIN
        SELECT  SALES_SO_ID ,
                a.SO_NO ,
                a.ORDER_DATE ,
                b.CUSTOMER_NAME ,
                a.ADDRESS
        FROM    dbo.SALES_SO a
                JOIN dbo.COM_CUSTOMER b WITH ( NOLOCK ) ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID
        WHERE   a.SO_NO LIKE '%' + @Keyword + '%'
                OR b.CUSTOMER_NAME LIKE '%' + @Keyword + '%'
    END
IF @OrderDate != '' 
    BEGIN
        SELECT  SALES_SO_ID ,
                a.SO_NO ,
                a.ORDER_DATE ,
                b.CUSTOMER_NAME ,
                a.ADDRESS
        FROM    dbo.SALES_SO a
                JOIN dbo.COM_CUSTOMER b WITH ( NOLOCK ) ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID
        WHERE   a.ORDER_DATE = @OrderDate
    END
IF @Keyword != '' AND @OrderDate != ''
BEGIN
SELECT  SALES_SO_ID ,
                a.SO_NO ,
                a.ORDER_DATE ,
                b.CUSTOMER_NAME ,
                a.ADDRESS
        FROM    dbo.SALES_SO a
                JOIN dbo.COM_CUSTOMER b WITH ( NOLOCK ) ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID
        WHERE   (a.SO_NO LIKE '%' + @Keyword + '%'
                OR b.CUSTOMER_NAME LIKE '%' + @Keyword + '%') AND a.ORDER_DATE = @OrderDate
END 
ELSE 
    BEGIN
        SELECT  SALES_SO_ID ,
                a.SO_NO ,
                a.ORDER_DATE ,
                b.CUSTOMER_NAME ,
                a.ADDRESS
        FROM    dbo.SALES_SO a
                JOIN dbo.COM_CUSTOMER b WITH ( NOLOCK ) ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID
    END
END
GO
