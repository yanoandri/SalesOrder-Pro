
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionFormListByCif
	Desc    		:	This store procedure is use to get list of PSC_EXCEPTION_FORM
	Create Date 	:	21 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By : 
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ExceptionFormListByCifAndAssetClass]
(
	@sCif VARCHAR(1280) = NULL,
	@iAssetClassID INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT
		cac2.ASSET_CLASS_NAME
	FROM
		psc_exception_form pef0 WITH (NOLOCK),
		com_asset_class cac2 WITH (NOLOCK)
	WHERE
		pef0.com_asset_class_id = cac2.com_asset_class_id AND
		pef0.CIF = @sCif AND
		cac2.COM_ASSET_CLASS_ID = @iAssetClassID AND 
		pef0.IS_ACTIVE = 1 AND
		pef0.IS_DELETED = 0
END
