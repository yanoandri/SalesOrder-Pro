
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionList
	Desc    		:	This store procedure is use to get list of PSC_JATIS_TRANSACTION
	Create Date 	:	22 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	: exec uspPSC_JatisTransactionListExcepitonCustomer
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_JatisTransactionListExcepitonCustomer]
(
	@dtDatePeriod DATETIME = NULL,
	@iBranchID int  = NULL
)
AS
BEGIN
	SELECT
		cb.branch_code,
		cb.branch_name,
		count(distinct pjt0.cif) as Total_Transaction,
		(
			select 
				count(distinct pjt1.CIF) 
			from 
				psc_jatis_transaction pjt1 with(nolock)
			where 
				pjt1.IS_WITH_EXCEPTION = 1 AND
				(@dtDatePeriod IS NULL OR CONVERT(VARCHAR(6), pjt1.DATE, 112) = CONVERT(VARCHAR(6), @dtDatePeriod, 112)) AND	
				(pjt1.branch_code = cb.branch_code)
		) as Number_Exception 
	FROM
		COM_BRANCH cb with(nolock) LEFT JOIN 
		psc_jatis_transaction pjt0 WITH (NOLOCK) ON (cb.COM_BRANCH_ID = pjt0.BRANCH_ID)
	WHERE
		(@dtDatePeriod IS NULL OR CONVERT(VARCHAR(6), pjt0.DATE, 112) = CONVERT(VARCHAR(6), @dtDatePeriod, 112)) AND	
		(@iBranchID IS NULL OR pjt0.BRANCH_ID = @iBranchID) 
	group by
		cb.BRANCH_CODE,
		cb.BRANCH_NAME
END
