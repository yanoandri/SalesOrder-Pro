-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_updateSO
-- Create date: yandriyanto 21-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE [dbo].[uspSO_updateSO]
	@p_SONO AS VARCHAR(20),
	@p_Customer AS INT,
	@p_OrderDate AS DATETIME,
	@p_Address AS VARCHAR(MAX),
	@p_SOID AS int
AS
BEGIN
	UPDATE SALES_SO WITH(ROWLOCK)
	SET	SO_NO = @p_SONO,
		COM_CUSTOMER_ID = @p_Customer,
		ORDER_DATE = @p_OrderDate,
		ADDRESS = @p_Address
	WHERE SALES_SO_ID = @p_SOID
END