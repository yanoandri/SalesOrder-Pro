/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscRmwCipValidation
	Desc    		:	This store procedure is use to add TMPT_FIRST_STAGING_PSC_RMW_CIP
	Create Date 	:	19 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:	[uspTMPT_FirstStagingPscRmwCipValidation] 1 
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspTMPT_FirstStagingPscRmwCipValidation]
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
		
	
	--INSERT OR UPDATE COM_RM
	insert into com_rm WITH(ROWLOCK)
	(
		rm_code,
		rm_name
	)
	select
		tfsprc0.rm_code,
		tfsprc0.rm_name
	from
		tmpt_first_staging_psc_rmw_cip tfsprc0 with(nolock)
	where
		not exists(
			select 
				rm_code,
				rm_name
			from
				com_rm WITH(NOLOCK)
			where
				rm_code = tfsprc0.rm_code and
				rm_name = tfsprc0.rm_name
		)
	
	update
		cr0
	set
		cr0.rm_code = tfs0.rm_code,
		cr0.rm_name = tfs0.rm_name
	from
		com_rm cr0 with(rowlock)
	INNER JOIN
		tmpt_first_staging_psc_rmw_cip tfs0 with(rowlock)
	ON 
		cr0.RM_CODE = tfs0.RM_CODE
	
	--SELECT *FROM tmpt_first_staging_psc_rmw_cip
	--VALIDATING 
	--DOB
	UPDATE
		TMPT_FIRST_STAGING_PSC_RMW_CIP with(rowlock)
	SET
		is_valid = 0,
		remark = 'Customer Dob is invalid format'
	where
		isdate(customer_dob) = 0

	--CREATE DATE	
	UPDATE
		TMPT_FIRST_STAGING_PSC_RMW_CIP with(rowlock)
	SET
		is_valid = 0,
		remark = 'Create date is invalid format'
	where
		isdate(SUBSTRING(CREATE_DATE,1,4)+SUBSTRING(CREATE_DATE,6,2)+SUBSTRING(CREATE_DATE,9,2)) = 0	

	--BRANCH
	UPDATE 
		tFsprc0
	SET
		tFsprc0.is_valid = 0,
		tFsprc0.remark = 'Branch is not valid'	
	FROM
		TMPT_FIRST_STAGING_PSC_RMW_CIP tFsprc0 with(rowlock)
	WHERE
		not exists
		(
			select 
				cb0.branch_code 
			from 
				com_branch cb0 with(nolock) 
			where
				cb0.BRANCH_CODE = tFsprc0.BRANCH_CODE
		)

	--RISK RATING
	UPDATE
		TMPT_FIRST_STAGING_PSC_RMW_CIP with(rowlock)
	SET
		is_valid = 0,
		remark = 'Risk Rating is not valid'	
		
	WHERE
	    CUSTOMER_RISK_RATING_SCORE NOT IN
		(
			select 
				ccr0.RISK_RATING_SCORE  
			from 
				COM_CUSTOMER_RISK_RATING ccr0 with(nolock)
		)

	--RISK RATING AND CREATE DATE WHEN SAME ON DB
	UPDATE
		tfsprc0
	SET
		tfsprc0.is_valid = 0,
		tfsprc0.remark = 'cif is not valid because risk rating and create date is already exists'
	FROM	
		TMPT_FIRST_STAGING_PSC_RMW_CIP tfsprc0 with(rowlock)
	WHERE
		exists
			(
			 select
				prc0.CIF ,
				prc0.COM_CUSTOMER_RISK_RATING_ID,
				prc0.CREATE_DATE 
			from 
				PSC_RMW_CIP prc0 with(nolock)
			where
				prc0.CIF = tfsprc0.CIF and
				prc0.CREATE_DATE = tfsprc0.CREATE_DATE and
				prc0.COM_CUSTOMER_RISK_RATING_ID = 
					(select 
						top 1 COM_CUSTOMER_RISK_RATING_ID 
					from 
						COM_CUSTOMER_RISK_RATING ccr0 with(nolock) 
					where 
						ccr0.RISK_RATING_SCORE = tfsprc0.CUSTOMER_RISK_RATING_SCORE)
			)

	--segment		
	UPDATE
		tmpt_first_staging_psc_rmw_cip with(rowlock)
	SET
		is_valid = 0,
		remark = 'Segment is not valid'	
	WHERE
		not exists
			(
				select 
					ccs0.SEGMENT_CODE 
				from 
					COM_CUSTOMER_SEGMENT ccs0 with(nolock) 
				where 
					ccs0.CUSTOMER_SEGMENT_NAME = CUSTOMER_SEGMENT_NAME
			)
	
	
	--update when cif is not valid		
	UPDATE 
		tfsprc0
	SET
		tfsprc0.is_valid = 0,
		tfsprc0.remark = 'Cif is not valid'	
	FROM
		TMPT_FIRST_STAGING_PSC_RMW_CIP tfsprc0 with(rowlock)
	WHERE
		not exists
		(		
		select 
			cc0.cif
		from 
			com_customer cc0 with(nolock)
		where
			cc0.cif = tfsprc0.cif
		) AND
		not exists
		(		
		select 
			tfscc0.cif
		from 
			dbo.TMPT_FIRST_STAGING_COM_CUSTOMER tfscc0 with(nolock)
		where
			tfscc0.cif = tfsprc0.cif
		) 
	
	
	UPDATE 
		tfsprc0
	SET
		tfsprc0.is_valid = 0,
		tfsprc0.remark = 'Record is not valid'	
	FROM
		TMPT_FIRST_STAGING_PSC_RMW_CIP tfsprc0 with(rowlock)
	WHERE
		exists	(
			SELECT prc0.COM_RM_ID,prc0.CIF FROM
				psc_rmw_cip prc0 with(nolock)
			WHERE
				prc0.q1_em = CASE WHEN tfsprc0.q1_em = '' THEN 0 ELSE 1 end   AND
				prc0.q3_1  =case when tfsprc0.q3_1  = '' then 0 else 1 end AND
				prc0.q3_2  =case when tfsprc0.q3_2  = '' then 0 else 1 end AND
				prc0.q3_3  =case when tfsprc0.q3_3  = '' then 0 else 1 end AND
				prc0.q3_4  =case when tfsprc0.q3_4  = '' then 0 else 1 end AND
				prc0.q3_5  =case when tfsprc0.q3_5  = '' then 0 else 1 end AND
				prc0.q3_6  =case when tfsprc0.q3_6  = '' then 0 else 1 end AND
				prc0.q3_7  =case when tfsprc0.q3_7  = '' then 0 else 1 end AND
				prc0.q3_8  =case when tfsprc0.q3_8  = '' then 0 else 1 end AND
				prc0.q3_9  =case when tfsprc0.q3_9  = '' then 0 else 1 end AND
				prc0.q3_10 =case when tfsprc0.q3_10 = '' then 0 else 1 end AND
				prc0.q3_11 =case when tfsprc0.q3_11 = '' then 0 else 1 end AND
				prc0.q3_12 =case when tfsprc0.q3_12 = '' then 0 else 1 end AND
				prc0.q3_13 =case when tfsprc0.q3_13 = '' then 0 else 1 end AND
				prc0.q4_1  =case when tfsprc0.q4_1  = '' then 0 else 1 end AND
				prc0.q4_2  =case when tfsprc0.q4_2  = '' then 0 else 1 end AND
				prc0.q4_3  =case when tfsprc0.q4_3  = '' then 0 else 1 end AND
				prc0.q4_4  =case when tfsprc0.q4_4  = '' then 0 else 1 end AND
				prc0.q4_5  =case when tfsprc0.q4_5  = '' then 0 else 1 end AND
				prc0.q4_6  =case when tfsprc0.q4_6  = '' then 0 else 1 end AND
				prc0.q6_1  =case when tfsprc0.q6_1  = '' then 0 else 1 end AND
				prc0.q6_2  =case when tfsprc0.q6_2  = '' then 0 else 1 end AND
				prc0.q6_3  =case when tfsprc0.q6_3  = '' then 0 else 1 end AND
				prc0.q6_4  =case when tfsprc0.q6_4  = '' then 0 else 1 end AND
				prc0.q6_5  =case when tfsprc0.q6_5  = '' then 0 else 1 end AND
				prc0.q6_6  =case when tfsprc0.q6_6  = '' then 0 else 1 end AND
				prc0.p1_q1 = tfsprc0.p1_q1 AND
				prc0.p1_q2 = tfsprc0.p1_q2 AND
		        prc0.p1_q3 = tfsprc0.p1_q3 AND
		        prc0.p1_q4 = tfsprc0.p1_q4 AND
		        prc0.p1_q5 = tfsprc0.p1_q5 AND
		        prc0.p1_q6 = tfsprc0.p1_q6 AND
		        prc0.p1_q7 = tfsprc0.p1_q7 AND
		        prc0.education_name = tfsprc0.education_name AND
		        prc0.COM_CUSTOMER_ID = 
		        (Select 
					top 1 com_customer_id 
				from 
					com_customer WITH(NOLOCK)
				where 
					cif = tfsprc0.cif) AND
				prc0.COM_BRANCH_ID  = 
				(select 
					top 1 com_branch_id 
				from 
					com_branch  WITH(NOLOCK)
				where 
					branch_code = tfsprc0.branch_code) AND
				prc0.COM_CUSTOMER_SEGMENT_ID = 
				(select 
					top 1 com_customer_segment_id 
				from 
					com_customer_segment  WITH(NOLOCK)
				where 
					customer_segment_name = tfsprc0.customer_segment_name) AND
				prc0.COM_CUSTOMER_RISK_RATING_ID = 
				(select 
					top 1 com_customer_risk_rating_id 
				from 
					com_customer_risk_rating  WITH(NOLOCK)
				where 
					risk_rating_score = tfsprc0.customer_risk_rating_score) AND
				prc0.COM_RM_ID = 
				(select 
					top 1 com_rm_id 
				from 
					com_rm WITH(NOLOCK)
				where 
					rm_code = tfsprc0.rm_code)
		)		
	AND		
		tfsprc0.psc_file_import_id = @iFileImportID		
	AND
		tfsprc0.IS_VALID = 1

	 --add to second staging	
	INSERT INTO tmpt_second_staging_psc_rmw_cip WITH(ROWLOCK)
    ( 	
		psc_file_import_id,
		cif,
		com_customer_id,
		cus_id,
		customer_dob,
		com_branch_id,
		com_customer_segment_id,
		com_customer_risk_rating_id,
		education_name,
		com_rm_id,
		p1_q1,
		p1_q2,
		p1_q3,
		p1_q4,
		p1_q5,
		p1_q6,
		p1_q7,
		q1_em,
		q2_total_asset,
		q2_total_liabilities,
		q3_1,
		q3_2,
		q3_3,
		q3_4,
		q3_5,
		q3_6,
		q3_7,
		q3_8,
		q3_9,
		q3_10,
		q3_11,
		q3_12,
		q3_13,
		q4_1,
		q4_2,
		q4_3,
		q4_4,
		q4_5,
		q4_6,
		q5_ith,
		q6_1,
		q6_2,
		q6_3,
		q6_4,
		q6_5,
		q6_6,
		is_valid,
		invalid_remark,
		create_date,
		branch_code,
		branch_name
	)
	SELECT
		tfsprc0.psc_file_import_id,
		tfsprc0.cif,
		(Select 
			top 1 com_customer_id 
		from 
			com_customer WITH(NOLOCK) 
		where 
			cif = tfsprc0.cif),
		tfsprc0.customer_id,
		tfsprc0.customer_dob,
		(select 
			top 1 com_branch_id 
		from 
			com_branch  WITH(NOLOCK)
		where 
			branch_code = tfsprc0.branch_code),
		(select 
			top 1 com_customer_segment_id 
		from 
			com_customer_segment  WITH(NOLOCK)
		where 
			customer_segment_name = tfsprc0.customer_segment_name),
		(select 
			top 1 com_customer_risk_rating_id 
		from 
			com_customer_risk_rating  WITH(NOLOCK)
		where 
			risk_rating_score = tfsprc0.customer_risk_rating_score),
		tfsprc0.education_name,
		(select 
			top 1 com_rm_id 
		from 
			com_rm  WITH(NOLOCK)
		where 
			rm_code = tfsprc0.rm_code),
		tfsprc0.p1_q1,
		tfsprc0.p1_q2,
		tfsprc0.p1_q3,
		tfsprc0.p1_q4,
		tfsprc0.p1_q5,
		tfsprc0.p1_q6,
		tfsprc0.p1_q7,
		case when tfsprc0.q1_em = '' then '0' else '1' end as q1_em,
		tfsprc0.q2_total_asset,
		tfsprc0.q2_total_liabilities,
		case when tfsprc0.q3_1 = '' then '0' else '1' end as q3_1,
		case when tfsprc0.q3_2 = '' then '0' else '1' end as q3_2,
		case when tfsprc0.q3_3 = '' then '0' else '1' end as q3_3,
		case when tfsprc0.q3_4 = '' then '0' else '1' end as q3_4,
		case when tfsprc0.q3_5 = '' then '0' else '1' end as q3_5,
		case when tfsprc0.q3_6 = '' then '0' else '1' end as q3_6,
		case when tfsprc0.q3_7 = '' then '0' else '1' end as q3_7,
		case when tfsprc0.q3_8 = '' then '0' else '1' end as q3_8,
		case when tfsprc0.q3_9 = '' then '0' else '1' end as q3_9,
		case when tfsprc0.q3_10= '' then  '0' else '1' end as q3_10,
		case when tfsprc0.q3_11= '' then  '0' else '1' end as q3_11,
		case when tfsprc0.q3_12= '' then  '0' else '1' end as q3_12,
		case when tfsprc0.q3_13= '' then  '0' else '1' end as q3_13,
		case when tfsprc0.q4_1 = '' then '0' else '1' end as q4_1,
		case when tfsprc0.q4_2 = '' then '0' else '1' end as q4_2,
		case when tfsprc0.q4_3 = '' then '0' else '1' end as q4_4,
		case when tfsprc0.q4_4 = '' then '0' else '1' end as q4_4,
		case when tfsprc0.q4_5 = '' then '0' else '1' end as q4_5,
		case when tfsprc0.q4_6 = '' then '0' else '1' end as q4_6,
		tfsprc0.q5_ith,
		case when tfsprc0.q6_1 = '' then '0' else '1' end as q6_1,
		case when tfsprc0.q6_2 = '' then '0' else '1' end as q6_2,
		case when tfsprc0.q6_3 = '' then '0' else '1' end as q6_3,
		case when tfsprc0.q6_4 = '' then '0' else '1' end as q6_4,
		case when tfsprc0.q6_5 = '' then '0' else '1' end as q6_5,
		case when tfsprc0.q6_6 = '' then '0' else '1' end as q6_6,		
		1,
		'-',
		tfsprc0.create_date,
		tfsprc0.branch_code,
		tfsprc0.branch_name
	FROM
		tmpt_first_staging_psc_rmw_cip tfsprc0 WITH (NOLOCK)
	where
		tfsprc0.is_valid = 1
		
	--TOTAL IMPORTING FILE
	SELECT 
		@iTotalFile	= COUNT(*)
	FROM 
		tmpt_first_staging_psc_rmw_cip tfs0 with(nolock)
	WHERE
		tfs0.psc_file_import_id = @iFileImportID
	
	SELECT 
		@iTotalValidData = COUNT(*)
	FROM 
		tmpt_first_staging_psc_rmw_cip tfs0 with(nolock)
	WHERE
		tfs0.is_valid = 1	AND
		tfs0.psc_file_import_id = @iFileImportID
		
	SELECT 
		@iTotalInvalidData = COUNT(*)
	FROM 
		tmpt_first_staging_psc_rmw_cip tfs0 with(nolock)
	WHERE
		tfs0.is_valid = 0	AND
		tfs0.psc_file_import_id = @iFileImportID
		
	UPDATE PSC_FILE_IMPORT with(rowlock) SET		
		total_input_data = @iTotalFile,
		total_valid_data = @iTotalValidData,
		total_invalid_data = @iTotalInvalidData
	WHERE
      	psc_file_import_id = @iFileImportID
	
END





