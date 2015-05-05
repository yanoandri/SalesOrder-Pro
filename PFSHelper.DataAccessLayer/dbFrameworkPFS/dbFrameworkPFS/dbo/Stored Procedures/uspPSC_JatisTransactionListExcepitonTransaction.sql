
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionList
	Desc    		:	This store procedure is use to get list of PSC_JATIS_TRANSACTION
	Create Date 	:	22 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	: exec uspPSC_JatisTransactionListExcepitonTransaction
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_JatisTransactionListExcepitonTransaction]
(
	@dtDatePeriod DATETIME = NULL,
	@iBranchID int  = NULL
)
AS
BEGIN
	SELECT
		cb.branch_code,
		cb.branch_name,
		count(pjt0.PSC_JATIS_TRANSACTION_ID)
		as Total_Transaction,
		(
			sum(
			(CASE WHEN pjt0.IS_WITH_EXCEPTION=1 THEN 1 ELSE 0 END)
			) 
		) as Number_Exception 
	FROM
		COM_BRANCH cb with(nolock)
		LEFT JOIN psc_jatis_transaction pjt0 WITH (NOLOCK) ON (cb.COM_BRANCH_ID = pjt0.BRANCH_ID)		
	WHERE
		(@dtDatePeriod IS NULL OR CONVERT(VARCHAR(6), pjt0.DATE, 112) = CONVERT(VARCHAR(6), @dtDatePeriod, 112)) AND	
		(@iBranchID IS NULL OR pjt0.BRANCH_ID = @iBranchID)
	group by cb.BRANCH_CODE,
			cb.BRANCH_NAME
END
