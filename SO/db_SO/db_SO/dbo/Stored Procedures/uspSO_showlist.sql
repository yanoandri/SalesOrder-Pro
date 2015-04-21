-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_showlist
-- Create date: yandriyanto 21-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE [dbo].[uspSO_showlist]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT SALES_SO_ID, a.SO_NO, a.ORDER_DATE, b.CUSTOMER_NAME, a.ADDRESS 
	FROM dbo.SALES_SO a JOIN dbo.COM_CUSTOMER b WITH (NOLOCK)
	ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID 
	ORDER BY SALES_SO_ID ASC
END