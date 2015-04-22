-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_deleteso
-- Create date: yandriyanto 21-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE [dbo].[uspSO_deleteso] @p_SOID VARCHAR(MAX)
AS 
    BEGIN
        SET NOCOUNT ON;

        DELETE  dbo.SALES_SO_LITEM WITH ( ROWLOCK )
        WHERE   SALES_SO_ID = @p_SOID
        DELETE  dbo.SALES_SO WITH ( ROWLOCK )
        WHERE   SALES_SO_ID = @p_SOID
	
    END