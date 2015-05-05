
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionList
	Desc    		:	This store procedure is use to get list of PSC_JATIS_TRANSACTION
	Create Date 	:	22 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	: exec uspPSC_JatisTransactionListReportTransactionHistory
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_JatisTransactionListReportTransactionHistory]
(
	@dtDateFrom DATETIME = NULL,
	@dtDateTo DATETIME = NULL,
	@iBranchID INT = NULL
)
AS
BEGIN
	SELECT
		pjt0.psc_jatis_transaction_id,
		pjt0.psc_file_import_id,
		pjt0.date,
		pjt0.branch_id,
		cb.branch_code,
		cb.branch_name,
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
		cr4.rm_name,
		css.CUSTOMER_SEGMENT_NAME,
		case when exists(select top 1 * from PSC_EXCEPTION_FORM pef with(nolock) 
						where pef.CIF = pjt0.CIF and
						pef.COM_ASSET_CLASS_ID = pjt0.ASSET_CLASS_ID)
				THEN 'YES'
			ELSE
			'NO'
		END as Exception
	FROM
		psc_jatis_transaction pjt0 WITH (NOLOCK),
		com_customer cc2 WITH (NOLOCK),
		com_rm cr4 WITH (NOLOCK),
		PSC_RMW_CIP prc with(nolock),
		COM_CUSTOMER_SEGMENT css with(nolock),
		COM_BRANCH cb with(nolock)
	WHERE
		pjt0.com_customer_id = cc2.com_customer_id AND
		pjt0.psc_rmw_cip_id = prc.PSC_RMW_CIP_ID and
		pjt0.com_rm_id = cr4.com_rm_id and
		prc.COM_CUSTOMER_ID = pjt0.COM_CUSTOMER_ID and
		prc.COM_CUSTOMER_SEGMENT_ID = css.COM_CUSTOMER_SEGMENT_ID and
		cb.COM_BRANCH_ID = pjt0.BRANCH_ID AND
		(@dtDateFrom IS NULL OR CONVERT(VARCHAR, pjt0.date, 12) >= CONVERT(VARCHAR, @dtDateFrom, 12)) AND
		(@dtDateTo IS NULL OR CONVERT(VARCHAR, pjt0.date, 12) <= CONVERT(VARCHAR, @dtDateTo, 12)) AND
		(@iBranchID IS NULL OR pjt0.BRANCH_ID = @iBranchID)
END
