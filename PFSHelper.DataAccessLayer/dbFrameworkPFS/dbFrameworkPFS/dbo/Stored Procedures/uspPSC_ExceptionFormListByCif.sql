﻿
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionFormListByCif
	Desc    		:	This store procedure is use to get list of PSC_EXCEPTION_FORM
	Create Date 	:	21 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By : mtoha
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ExceptionFormListByCif]
(
	@sCif VARCHAR(1280) = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT
		pef0.psc_exception_form_id,
		pef0.com_branch_id,
		pef0.branch_name,
		pef0.cif,
		cc0.COM_CUSTOMER_ID,
		pef0.customer_full_name,
		pef0.com_asset_class_id,
		pef0.com_product_rating_id,
		cpr3.RATING_SCORE,
		pef0.exception_date,
		pef0.approved_date,
		pef0.expiry_date,
		pef0.is_active,
		pef0.is_deleted,
		pef0.create_date,
		pef0.create_by_user_id,
		pef0.update_date,
		pef0.update_by_user_id,
		pef0.is_need_approval,
		cb1.branch_code,
		cb1.branch_name,
		cac2.asset_class_code,
		cac2.asset_class_name
	FROM
		psc_exception_form pef0 WITH (NOLOCK),
		com_branch cb1 WITH (NOLOCK),
		com_asset_class cac2 WITH (NOLOCK),
		com_product_rating cpr3 WITH (NOLOCK),
		COM_CUSTOMER cc0 WITH (NOLOCK)
	WHERE
		pef0.com_branch_id = cb1.com_branch_id AND
		pef0.com_asset_class_id = cac2.com_asset_class_id AND
		pef0.com_product_rating_id = cpr3.com_product_rating_id AND
		pef0.CIF = @sCif AND
		pef0.IS_ACTIVE = 1 AND
		pef0.IS_DELETED = 0
END