
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionList
	Desc    		:	This store procedure is use to get list of PSC_JATIS_TRANSACTION
	Create Date 	:	22 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	: exec uspPSC_ExceptionFormListReport
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ExceptionFormListReport]
(
	@dtPeriod DATETIME = NULL,
	@iBranchID INT = NULL
)
AS
DECLARE @dtGenerateDate datetime = getdate()

BEGIN
	SELECT
		@dtGenerateDate as Date,
		pef.PSC_EXCEPTION_FORM_ID,
		cb.Branch_Code,
		cb.Branch_Name,
		pef.CIF,
		pef.CUSTOMER_FULL_NAME,
		pef.CREATE_DATE,
		ISNULL(
			(SELECT top 1 ccs.CUSTOMER_SEGMENT_NAME from PSC_RMW_CIP prc1 with(nolock) 
			inner join COM_CUSTOMER_SEGMENT ccs with(nolock) on (prc1.CIF = pef.CIF)
			order by prc1.CREATE_DATE desc)
			,'') as CUSTOMER_SEGMENT_NAME,
		ISNULL(
			(SELECT top 1 ccs.RISK_RATING_SCORE from PSC_RMW_CIP prc1 with(nolock) 
			inner join COM_CUSTOMER_RISK_RATING ccs with(nolock) on (prc1.CIF = pef.CIF)
			order by prc1.CREATE_DATE desc)
			,'') as RISK_RATING_SCORE,	
		cas.ASSET_CLASS_NAME,
		pef.EXPIRY_DATE,
		dbo.fPFS_CountBussinessDayWithoutHolidayTable(@dtGenerateDate,pef.EXPIRY_DATE) as Aging
	FROM
		COM_BRANCH cb with(nolock),
		PSC_EXCEPTION_FORM pef with(nolock),
		COM_ASSET_CLASS cas WITH(NOLOCK)
	WHERE
		cb.COM_BRANCH_ID = pef.COM_BRANCH_ID AND
		cas.COM_ASSET_CLASS_ID = pef.COM_ASSET_CLASS_ID AND
		(@dtPeriod IS NULL OR  
		(CONVERT(VARCHAR(6), pef.EXPIRY_DATE, 112) >= CONVERT(VARCHAR(6), @dtPeriod, 112)) AND
		(CONVERT(VARCHAR(6), pef.EXPIRY_DATE, 112) <= CONVERT(VARCHAR(6), dateadd(MONTH,1,@dtPeriod), 112))) AND
		(@iBranchID IS NULL OR cb.COM_BRANCH_ID = @iBranchID) 
		AND pef.IS_DELETED = 0
		AND pef.IS_ACTIVE = 1
	ORDER BY
		pef.PSC_EXCEPTION_FORM_ID desc,
		pef.CIF asc
END
