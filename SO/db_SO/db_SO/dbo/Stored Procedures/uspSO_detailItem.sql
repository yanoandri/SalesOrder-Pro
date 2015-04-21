-- =============================================
--Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
--This software, all associated documentation, and all copies
-- Author	  :	uspSO_detailItem
-- Create date: yandriyanto 21-4-2015
-- Description:	-
-- =============================================
CREATE PROCEDURE [dbo].[uspSO_detailItem]
	@p_SOID AS INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT  SALES_SO_LITEM_ID ,
	        SALES_SO_ID ,
	        ITEM_NAME ,
	        QUANTITY ,
	        PRICE
	FROM SALES_SO_LITEM WITH (NOLOCK)
	WHERE SALES_SO_ID = @p_SOID
END