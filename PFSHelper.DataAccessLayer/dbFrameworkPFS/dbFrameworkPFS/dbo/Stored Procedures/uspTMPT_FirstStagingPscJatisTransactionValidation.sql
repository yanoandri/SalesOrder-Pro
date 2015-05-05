
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingJatisTransactionValidation
	Desc    		:	This store procedure is use to add 
	Create Date 	:	19 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:	uspTMPT_FirstStagingJatisTransactionValidation 1 
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspTMPT_FirstStagingPscJatisTransactionValidation]
(
	@iFileProcessStatusID INT
)
AS
BEGIN

	DECLARE @iFileImportID INT = 0
	DECLARE @iTotalFile INT = 0
	DECLARE @iTotalValidData INT = 0
	DECLARE @iTotalInvalidData INT = 0
	DECLARE @sFileNameRmwCIP VARCHAR(100)
	
	SELECT 
		@iFileImportID = pfi.psc_file_import_id,
		@sFileNameRMWCIP = pfi.file_name
	FROM 
		PSC_FILE_IMPORT pfi with(nolock) 
	WHERE
		pfi.psc_process_status_id = @iFileProcessStatusID	
	

	--VALIDATING
	UPDATE
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION with(rowlock)
	SET
		is_valid = 0,
		remark = 'date is invalid format'
	where
		isdate(date) = 0

	--branch
	update
		tfspjt0
	set
		tfspjt0.is_valid = 0,
		tfspjt0.remark = 'branch is not valid'
	from
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION tfspjt0 with(rowlock)
	where
		not exists (
					select 
						BRANCH_CODE 
					from 
						COM_BRANCH cb0 with(nolock) 
					where 
						BRANCH_CODE = tfspjt0.BRANCH_CODE or
						BRANCH_NAME = tfspjt0.BRANCH_NAME
					)
			

	--customer
	update
		tfspjt1
	set
		tfspjt1.is_valid = 0,
		tfspjt1.remark = 'Customer is not valid'
	from
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION tfspjt1 with(rowlock)
	where
		not exists (
			select 
				CUSTOMER_NAME 
			from 
				COM_CUSTOMER cc0 with(nolock) 
			where 
				CIF=tfspjt1.CIF)
			
	--product
	update
		tfspjt2
	set
		tfspjt2.is_valid = 0,
		tfspjt2.remark = 'product is not valid'
	from
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION tfspjt2 with(rowlock)
	where
		not exists (select 
						PRODUCT_NAME 
					from 
						COM_PRODUCT cp0 with(nolock) 
					where 
						PRODUCT_CODE=tfspjt2.PROUCT_CODE or 
						PRODUCT_NAME=tfspjt2.PRODUCT_NAME)
			
	--currency
	update
		tfspjt3
	set
		tfspjt3.is_valid = 0,
		tfspjt3.remark = 'currency is not valid'
	from
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION tfspjt3 with(rowlock)
	where
		not exists (
					select 
						CURRENCY_CODE 
					from 
						COM_CURRENCY cc0 with(nolock) 
					where 
						cc0.CURRENCY_CODE = tfspjt3.CURRENCY_CODE)
			
	--rm
	update
		tfspjt4
	set
		tfspjt4.is_valid = 0,
		tfspjt4.remark = 'rm is not valid'
	from
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION tfspjt4 with(rowlock)
	where
		not exists (
					select 
						cr0.RM_NAME 
					from 
						COM_RM cr0 with(nolock) 
					where 
						cr0.RM_NAME=tfspjt4.RM_NAME)

	--asset class 
	update
		tfspjt5
	set
		tfspjt5.is_valid = 0,
		tfspjt5.remark = 'asset class is not valid'		
	from
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION tfspjt5 with(rowlock)
	where
		not exists
		(
			select  
				cp0.PRODUCT_CODE, cp0.PRODUCT_NAME
			from 
				COM_PRODUCT cp0 with(nolock)
			where
				cp0.CURRENCY_CODE = tfspjt5.CURRENCY_CODE and
				cp0.PRODUCT_NAME = tfspjt5.PRODUCT_NAME
		)
		and
		is_valid = 1
		
	--rmw cip is not exist
	update
		tfspjt5
	set
		tfspjt5.is_valid = 0,
		tfspjt5.remark = 'cif is not exist in rmw cip'		
	from
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION tfspjt5 with(rowlock)
	WHERE
	NOT EXISTS	
		(
			SELECT 
				TOP 1 cif 
			FROM 
				PSC_RMW_CIP prc0 WITH(NOLOCK) 
			WHERE 
				prc0.CIF = tfspjt5.CIF 
		)
		
	--duplicate record
	update
		tfspjt5
	set
		tfspjt5.is_valid = 0,
		tfspjt5.remark = 'record is not valid'		
	from
		TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION tfspjt5 with(rowlock)
	where
	exists
		(
		select
			pjt0.date,
	        pjt0.branch_id,
	        pjt0.com_customer_id,
	        pjt0.product_id,
	        pjt0.asset_class_id,
	        pjt0.com_currency_id,
	        pjt0.amount,
	        pjt0.com_rm_id
		from
			PSC_JATIS_TRANSACTION pjt0 with(nolock)
		where
			pjt0.DATE = tfspjt5.date and
			pjt0.BRANCH_ID in (
				Select 
					cb0.com_branch_id 
				from 
					COM_BRANCH cb0 with(nolock) 
				where 
					cb0.BRANCH_CODE = tfspjt5.BRANCH_CODE or
					cb0.BRANCH_NAME = tfspjt5.BRANCH_NAME) and
			pjt0.COM_CUSTOMER_ID in (
				Select 
					cc0.COM_CUSTOMER_ID 
				from 
					COM_CUSTOMER cc0 with(nolock) 
				where 
					cc0.cif=tfspjt5.CIF) and
			pjt0.PRODUCT_ID in (
				Select 
					cp0.com_product_id 
				from 
					COM_PRODUCT cp0 with(nolock) 
				where 
					cp0.PRODUCT_CODE = tfspjt5.PROUCT_CODE or
					cp0.PRODUCT_NAME = tfspjt5.product_name) and
			pjt0.asset_class_id in (
				select  
					cas0.COM_ASSET_CLASS_ID
				from 
					COM_PRODUCT cp0 with(nolock)
				inner join
					COM_ASSET_CLASS cas0 with(nolock)
				on
					cp0.COM_ASSET_CLASS_ID = cas0.COM_ASSET_CLASS_ID
				where
					cp0.PRODUCT_NAME = tfspjt5.PRODUCT_NAME and
					cp0.CURRENCY_CODE = tfspjt5.CURRENCY_CODE) and
			pjt0.COM_CURRENCY_ID in (
				select 
					cc0.com_currency_id 
				from 
					com_currency cc0 with(nolock) 
				where 
					cc0.currency_code = tfspjt5.currency_code) and
			pjt0.AMOUNT = tfspjt5.AMOUNT and
			pjt0.COM_RM_ID in(	
				select 
					cr0.com_rm_id 
				from 
					com_rm cr0 with(nolock) 
				where 
					cr0.rm_name = tfspjt5.rm_name)

		)

	-- add to second staging
	INSERT INTO TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION WITH(ROWLOCK)
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
		psc_rmw_cip_id,
		is_valid
	)
	SELECT
		tfspjt0.psc_file_import_id,
		tfspjt0.date,
		isnull((select 
					top 1 com_branch_id 
				from 
					com_branch cb0 with(nolock) 
				where 
					cb0.branch_code = tfspjt0.branch_code or
					cb0.branch_name = tfspjt0.branch_name),0),
		tfspjt0.branch_code,
		tfspjt0.branch_name,
		isnull((select 
					top 1 com_customer_id 
				from 
					com_customer cc0 with(nolock) 
				where 
					cc0.cif = tfspjt0.cif),0),
		tfspjt0.cif,
		tfspjt0.customer_name,
		isnull((select 
					top 1 com_product_id 
				from 
					com_product cp0 with(nolock) 
				where
					cp0.product_code = tfspjt0.prouct_code or
					cp0.product_name = tfspjt0.product_name),0),
		tfspjt0.prouct_code,
		tfspjt0.product_name,
		isnull((
			select  
				cas0.COM_ASSET_CLASS_ID
			from 
				COM_PRODUCT cp0 with(nolock)
			inner join
				COM_ASSET_CLASS cas0 with(nolock)
			on
				cp0.COM_ASSET_CLASS_ID = cas0.COM_ASSET_CLASS_ID
			where
				cp0.PRODUCT_NAME = tfspjt0.PRODUCT_NAME and
				cp0.CURRENCY_CODE = tfspjt0.CURRENCY_CODE
			
			),0),
		isnull((select 
					top 1 com_currency_id 
				from 
					com_currency cc0 with(nolock) 
				where 
					cc0.currency_code = tfspjt0.currency_code),0),
		tfspjt0.amount,
		isnull((select 
					top 1 com_rm_id 
				from 
					com_rm cr0 with(nolock) 
				where 
					cr0.rm_name = tfspjt0.rm_name),0),
		(SELECT 
			TOP 1 prc0.PSC_RMW_CIP_ID 
		FROM 
			dbo.PSC_RMW_CIP prc0 WITH(NOLOCK) 
		WHERE 
			prc0.CIF = tfspjt0.cif 
		ORDER BY 
			prc0.PSC_RMW_CIP_ID DESC),
		1
	FROM
		tmpt_first_staging_psc_jatis_transaction tfspjt0 WITH (NOLOCK)	
	where
		tfspjt0.is_valid = 1
	
		
	--TOTAL IMPORTING FILE
	SELECT 
		@iTotalFile	= COUNT(*)
	FROM 
		tmpt_first_staging_psc_jatis_transaction tfspjt0 with(nolock)
	WHERE
		tfspjt0.psc_file_import_id = @iFileImportID
	
	SELECT 
		@iTotalValidData = COUNT(*)
	FROM 
		tmpt_first_staging_psc_jatis_transaction tfspjt0 with(nolock)
	WHERE
		tfspjt0.is_valid = 1	AND
		tfspjt0.psc_file_import_id = @iFileImportID
		
	SELECT 
		@iTotalInvalidData = COUNT(*)
	FROM 
		tmpt_first_staging_psc_jatis_transaction tfspjt0 with(nolock)
	WHERE
		tfspjt0.is_valid = 0	AND
		tfspjt0.psc_file_import_id = @iFileImportID
		
	UPDATE PSC_FILE_IMPORT with(rowlock) SET		
		total_input_data = @iTotalFile,
		total_valid_data = @iTotalValidData,
		total_invalid_data = @iTotalInvalidData
	WHERE
      	psc_file_import_id = @iFileImportID
	
END







