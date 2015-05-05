
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
CREATE PROCEDURE [dbo].[uspPSC_RmwCipListReportExpiryDate]
(
	@dtDateFrom DATETIME = NULL,
	@iBranchID INT = NULL
)
AS
BEGIN
	declare @dtGenerationDate as datetime = getdate()
	
	SELECT
		prc.PSC_RMW_CIP_ID,
		@dtGenerationDate as DATE,
		prc.CIF,
		cc2.full_name,
		ccs.CUSTOMER_SEGMENT_NAME,
		ccrr.RISK_RATING_SCORE,
		cr.RM_NAME,
		prc.EXPIRY_DATE,
		dbo.fPFS_CountBussinessDayWithoutHolidayTable(getdate(),prc.EXPIRY_DATE) as Aging,
		cb.branch_code,
		cb.branch_name
	FROM
		com_customer cc2 WITH (NOLOCK),
		PSC_RMW_CIP prc WITH(NOLOCK),
		COM_CUSTOMER_SEGMENT ccs WITH(NOLOCK),
		COM_CUSTOMER_RISK_RATING ccrr WITH(NOLOCK),
		COM_RM cr with(nolock),
		COM_BRANCH cb with(nolock) 
	WHERE
		ccs.COM_CUSTOMER_SEGMENT_ID = prc.COM_CUSTOMER_SEGMENT_ID AND
		ccrr.COM_CUSTOMER_RISK_RATING_ID = prc.COM_CUSTOMER_RISK_RATING_ID AND
		cc2.COM_CUSTOMER_ID = prc.COM_CUSTOMER_ID AND
		cr.COM_RM_ID = prc.COM_RM_ID AND
		cb.COM_BRANCH_ID = prc.COM_BRANCH_ID AND
		(@iBranchID IS NULL OR cb.COM_BRANCH_ID = @iBranchID) AND
		(@dtDateFrom IS NULL OR  
		(CONVERT(VARCHAR(6), prc.EXPIRY_DATE, 112) >= CONVERT(VARCHAR(6), @dtDateFrom, 112)) AND
		(CONVERT(VARCHAR(6), prc.EXPIRY_DATE, 112) <= CONVERT(VARCHAR(6), dateadd(MONTH,1,@dtDateFrom), 112))) 
		
END
