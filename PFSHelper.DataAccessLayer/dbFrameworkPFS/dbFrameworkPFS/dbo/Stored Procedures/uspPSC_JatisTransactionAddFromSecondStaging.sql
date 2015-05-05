/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_JatisTransactionAddFromSecondStaging
	Desc    		:	This store procedure is use to add PSC_JATIS_TRANSACTION
	Create Date 	:	22 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_JatisTransactionAddFromSecondStaging]
(	
	@iCreateByUserID INT
)
AS
BEGIN
	DECLARE @iJatisTransactionID INT

	
	DECLARE 
		@TempJatisTransaction 
	Table
		(CIF varchar(50), 
		PRODUCT_ID int, 
		COM_CUSTOMER_RISK_RATING_ID int, 
		RATING_SCORE varchar(10),
		COM_ASSET_CLASS_ID int, 
		Date datetime, 
		IsValid bit,
		RMW_CIP_ID int)

	INSERT INTO @TempJatisTransaction
 
	SELECT 
		tsspjt0.CIF, 
		tsspjt0.PRODUCT_ID,
		prc0.COM_CUSTOMER_RISK_RATING_ID,
		cpr0.RATING_SCORE,
		tsspjt0.ASSET_CLASS_ID,
		tsspjt0.DATE,
		'true',
		MAX(prc0.PSC_RMW_CIP_ID)
	FROM
		TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION tsspjt0 with(nolock) 
	INNER JOIN 
		PSC_RMW_CIP prc0 with(nolock)
	ON
		tsspjt0.CIF = prc0.CIF
	INNER JOIN
		COM_PRODUCT cp0 with(nolock)
	ON
		tsspjt0.PRODUCT_ID = cp0.COM_PRODUCT_ID
	INNER JOIN
		COM_PRODUCT_RATING cpr0 with(nolock)
	ON
		cp0.COM_PRODUCT_RATING_ID = cpr0.COM_PRODUCT_RATING_ID
	WHERE
		exists
		(
			SELECT 
				COM_CUSTOMER_RISK_RATING_ID, 
				PRODUCT_RATING_TO_WITH_EXCEPTION 
			FROM 
				PSC_CUSTOMER_RATING_VS_PRODUCT_RATING pcr0 with(nolock)
			WHERE
				pcr0.COM_CUSTOMER_RISK_RATING_ID = prc0.COM_CUSTOMER_RISK_RATING_ID and
				pcr0.PRODUCT_RATING_TO_WITH_EXCEPTION like '%'+cpr0.RATING_SCORE+'%' 
		)
	GROUP BY 
		tsspjt0.CIF, 
		tsspjt0.PRODUCT_ID,
		prc0.COM_CUSTOMER_RISK_RATING_ID,
		cpr0.RATING_SCORE,
		tsspjt0.ASSET_CLASS_ID,
		tsspjt0.DATE

    
	INSERT INTO PSC_JATIS_TRANSACTION WITH(ROWLOCK)
    ( 	
		psc_file_import_id,
		date,
		branch_id,
		branch_code,
		branch_name,
		com_customer_id,
		cif,
		customer_name,
		product_id,
		product_code,
		product_name,
		asset_class_id,
		com_currency_id,
		amount,
		com_rm_id,
		create_by_user_id,
		create_date,
		update_date,
		update_by_user_id,
		psc_rmw_cip_id,
		is_with_exception
	)
	SELECT
		tsspjt0.psc_file_import_id,
		tsspjt0.date,
		tsspjt0.branch_id,
		tsspjt0.branch_code,
		tsspjt0.branch_name,
		tsspjt0.com_customer_id,
		tsspjt0.cif,
		tsspjt0.customer_name,
		tsspjt0.product_id,
		tsspjt0.product_code,
		tsspjt0.product_name,
		tsspjt0.asset_class_id,
		tsspjt0.com_currency_id,
		tsspjt0.amount,
		tsspjt0.com_rm_id,
		@iCreateByUserID,
		getdate(),
		getdate(),
		@iCreateByUserID,
		tsspjt0.psc_rmw_cip_id,
		case when exists ( 
			select 
				tmp0.CIF,
				tmp0.PRODUCT_ID 
			from 
				@TempJatisTransaction tmp0 
			INNER JOIN
				psc_exception_form pef0 with(nolock)
			on
				tmp0.cif = pef0.CIF and 
				tmp0.COM_ASSET_CLASS_ID = pef0.COM_ASSET_CLASS_ID and
				tmp0.Date <= pef0.EXPIRY_DATE and
				tmp0.Date >= pef0.EXCEPTION_DATE
			WHERE	
				tmp0.CIF=tsspjt0.CIF AND
				tmp0.COM_ASSET_CLASS_ID = tsspjt0.ASSET_CLASS_ID AND
				tmp0.Date = tsspjt0.DATE ) then 'true' else 'false' end as is_with_exception
	FROM
		tmpt_second_staging_psc_jatis_transaction tsspjt0 WITH (NOLOCK)
	WHERE
		tsspjt0.is_valid = 1
		
	
END
