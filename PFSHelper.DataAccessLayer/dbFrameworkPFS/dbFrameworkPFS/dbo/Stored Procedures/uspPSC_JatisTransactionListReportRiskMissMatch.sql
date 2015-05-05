﻿
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionList
	Desc    		:	This store procedure is use to get list of PSC_JATIS_TRANSACTION
	Create Date 	:	22 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_JatisTransactionListReportRiskMissMatch]
(
	@dtDateFrom DATETIME = NULL,
	@dtDateTo DATETIME = NULL,
	@iBranchID varchar(50) = NULL
)
AS
BEGIN
	SELECT
		pjt0.psc_jatis_transaction_id,
		pjt0.psc_file_import_id,
		pjt0.date,
		pjt0.branch_id,
		pjt0.branch_code,
		pjt0.branch_name,
		pjt0.com_customer_id,
		pjt0.cif,
		pjt0.customer_name,
		pjt0.product_id,
		pjt0.product_code,
		pjt0.product_name,
		pjt0.asset_class_id,
		pjt0.com_currency_id,
		pjt0.amount,
		pjt0.com_rm_id,
		pjt0.create_date,
		pjt0.create_by_user_id,
		pjt0.update_date,
		pjt0.update_by_user_id,
		cc2.full_name,
		ccs.CUSTOMER_SEGMENT_NAME,
		ccrs.RISK_RATING_SCORE,
		(select top 1 cpr.RATING_SCORE
		from 
			COM_PRODUCT cp,
			COM_PRODUCT_RATING cpr
		where
			cpr.COM_PRODUCT_RATING_ID = cp.COM_PRODUCT_RATING_ID AND 
			cp.PRODUCT_NAME = pjt0.PRODUCT_NAME 
			and cp.CURRENCY_CODE = cc3.CURRENCY_CODE) as PRODUCT_RISK_RATING
	FROM
		psc_jatis_transaction pjt0 WITH (NOLOCK),
		com_customer cc2 WITH (NOLOCK),
		com_currency cc3 WITH (NOLOCK),
		PSC_RMW_CIP prc WITH(NOLOCK),
		COM_CUSTOMER_SEGMENT ccs WITH(NOLOCK),
		COM_CUSTOMER_RISK_RATING ccrs WITH(NOLOCK)
	WHERE
		pjt0.com_customer_id = cc2.com_customer_id AND
		pjt0.com_currency_id = cc3.com_currency_id AND
		pjt0.COM_CUSTOMER_ID = prc.COM_CUSTOMER_ID AND
		pjt0.psc_rmw_cip_id = prc.psc_rmw_cip_id and
		ccs.COM_CUSTOMER_SEGMENT_ID = prc.COM_CUSTOMER_SEGMENT_ID AND
		ccrs.COM_CUSTOMER_RISK_RATING_ID = prc.COM_CUSTOMER_RISK_RATING_ID AND
		(@dtDateFrom IS NULL OR CONVERT(VARCHAR, pjt0.date, 12) >= CONVERT(VARCHAR, @dtDateFrom, 12)) AND
		(@dtDateTo IS NULL OR CONVERT(VARCHAR, pjt0.date, 12) <= CONVERT(VARCHAR, @dtDateTo, 12)) AND
		(@iBranchID IS nuLL OR pjt0.BRANCH_ID = @iBranchID)
		
END
