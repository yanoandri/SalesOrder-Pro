
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionList
	Desc    		:	This store procedure is use to get list of PSC_JATIS_TRANSACTION
	Create Date 	:	22 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_RmwCipListReportFrequentChangesReport]
(
	@dtDateFrom DATETIME = NULL,
	@dtDateTo DATETIME = NULL,
	@iBranchid int = null
)
AS
BEGIN
	SELECT
		prc.PSC_RMW_CIP_ID,
		cb.Branch_Code,
		cb.Branch_Name,
		prc.CIF,
		cc2.full_name,
		css.CUSTOMER_SEGMENT_NAME,
		prc.CREATE_DATE,
		ccrs.RISK_RATING_SCORE,
		prc.COM_CUSTOMER_SEGMENT_ID
	FROM
		com_customer cc2 WITH (NOLOCK),
		PSC_RMW_CIP prc with(nolock),
		COM_CUSTOMER_SEGMENT css with(nolock),
		COM_BRANCH cb with(nolock),
		COM_CUSTOMER_RISK_RATING ccrs WITH(NOLOCK)
	WHERE
		cb.COM_BRANCH_ID = prc.COM_BRANCH_ID AND
		prc.COM_CUSTOMER_SEGMENT_ID = css.COM_CUSTOMER_SEGMENT_ID and
		ccrs.COM_CUSTOMER_RISK_RATING_ID = prc.COM_CUSTOMER_RISK_RATING_ID AND
		cc2.COM_CUSTOMER_ID = prc.COM_CUSTOMER_ID AND
		(@dtDateFrom IS NULL OR CONVERT(VARCHAR, prc.CREATE_DATE, 12) >= CONVERT(VARCHAR, @dtDateFrom, 12)) AND
		(@dtDateTo IS NULL OR CONVERT(VARCHAR, prc.CREATE_DATE, 12) <= CONVERT(VARCHAR, @dtDateTo, 12)) AND
		(@iBranchid IS NULL OR cb.COM_BRANCH_ID = @iBranchid) 
	ORDER BY
		prc.CIF asc,
		prc.COM_BRANCH_ID asc,
		prc.COM_CUSTOMER_SEGMENT_ID asc,	
		ccrs.RISK_RATING_SCORE asc,	
		prc.CREATE_DATE desc
END
