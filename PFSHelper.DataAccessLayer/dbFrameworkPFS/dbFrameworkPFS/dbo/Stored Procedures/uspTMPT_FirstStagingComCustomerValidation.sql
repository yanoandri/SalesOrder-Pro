/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingComCustomerValidation
	Desc    		:	This store procedure is use to validation firs staging com customer
	Create Date 	:	19 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:	uspTMPT_FirstStagingComCustomerValidation 1 
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspTMPT_FirstStagingComCustomerValidation]
(
	@iFileProcessStatusID INT
)
AS
BEGIN

	DECLARE @iFileImportID INT = 0
	DECLARE @iTotalFile INT = 0
	DECLARE @iTotalValidData INT = 0
	DECLARE @iTotalInvalidData INT = 0
	DECLARE @sFileName VARCHAR(100)
	
	SELECT 
		@iFileImportID = pfi.psc_file_import_id,
		@sFileName = pfi.file_name
	FROM 
		PSC_FILE_IMPORT pfi with(nolock) 
	WHERE
		pfi.psc_process_status_id = @iFileProcessStatusID	
	
	--ADD OR UPDATE COM BRANCH
	insert into com_branch WITH(ROWLOCK)
	(
		branch_code,
		branch_name
	)
	select
		tfscc0.branch_code,
		tfscc0.branch_name
	from
		tmpt_first_staging_com_customer tfscc0 with(nolock)
	where
		tfscc0.branch_code not in
			( select 
				branch_code 
			  from 
				com_branch with(nolock) )
	group by 
		tfscc0.branch_code, 
		tfscc0.branch_name
		
	update 
		cb0
	set
		cb0.branch_name = tfscc0.branch_name
	from
		com_branch cb0 with(rowlock)
	INNER JOIN
		tmpt_first_staging_com_customer tfscc0 with(rowlock)
	ON 
		cb0.BRANCH_CODE = tfscc0.BRANCH_CODE
		
	
	--VALIDATING
	UPDATE
		tmpt_first_staging_com_customer with(rowlock)
	SET
		is_valid = 0,
		remark = 'Customer Dob is invalid format'
	where
		isdate(customer_dob) = 0
	

	INSERT INTO TMPT_SECOND_STAGING_COM_CUSTOMER WITH(ROWLOCK)
    ( 	
		psc_file_import_id,
		cif,
		customer_dob,
		control_center,
		com_education_id,
		full_name,
		com_branch_id,
		is_valid,
		invalid_remark
	)
	SELECT
		tfscc0.psc_file_import_id,
		tfscc0.cif,
		tfscc0.customer_dob,
		tfscc0.control_center,
		(select 
			top 1 com_education_id 
		from 
			com_education with(nolock) 
		where 
			education_name = tfscc0.education_name),
		tfscc0.full_name,
		(select 
			top 1 com_branch_id 
		from 
			com_branch WITH(NOLOCK)
		where 
			branch_code = tfscc0.branch_code ),
		1,
		'-'
	FROM
		tmpt_first_staging_com_customer tfscc0 WITH (NOLOCK)
	where
		tfscc0.is_valid = 1
		
	--TOTAL IMPORTING FILE
	SELECT 
		@iTotalFile	= COUNT(*)
	FROM 
		tmpt_first_staging_com_customer tfscc0 with(nolock)
	WHERE
		tfscc0.psc_file_import_id = @iFileImportID
	
	SELECT 
		@iTotalValidData = COUNT(*)
	FROM 
		tmpt_first_staging_com_customer tfscc0 with(nolock)
	WHERE
		tfscc0.is_valid = 1	AND
		tfscc0.psc_file_import_id = @iFileImportID
		
	SELECT 
		@iTotalInvalidData = COUNT(*)
	FROM 
		tmpt_first_staging_com_customer tfscc0 with(nolock)
	WHERE
		tfscc0.is_valid = 0	AND
		tfscc0.psc_file_import_id = @iFileImportID
		
	UPDATE PSC_FILE_IMPORT SET		
		total_input_data = @iTotalFile,
		total_valid_data = @iTotalValidData,
		total_invalid_data = @iTotalInvalidData
	WHERE
      	psc_file_import_id = @iFileImportID
	
END





