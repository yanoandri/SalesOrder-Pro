/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CustomerAddFromSecondStaging
	Desc    		:	This store procedure is use to add COM_CUSTOMER
	Create Date 	:	20 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_CustomerAddFromSecondStaging]
(	
	@iCreateByUserID INT
)
AS
BEGIN
	DECLARE @iCustomerID INT
    
    --update where cif exists in com customer
    UPDATE 
		cc0
	SET
		cc0.psc_file_import_id = tsscc0.psc_file_import_id,
		cc0.cif = tsscc0.cif,
		cc0.customer_dob = tsscc0.customer_dob,
		cc0.control_center = tsscc0.control_center,
		cc0.com_education_id = isnull(tsscc0.com_education_id,0) ,
		cc0.full_name = tsscc0.full_name,
		cc0.com_branch_id = tsscc0.com_branch_id,
		cc0.update_by_user_id = @iCreateByUserID,
		cc0.update_date = getdate()
	FROM 
		COM_CUSTOMER cc0 WITH(ROWLOCK)
	INNER JOIN
		tmpt_second_staging_com_customer tsscc0 with(ROWLOCK)
	ON 
		cc0.CIF = tsscc0.CIF
	WHERE
		tsscc0.IS_VALID = 1
    
    --insert when cif not in com customer
	INSERT INTO COM_CUSTOMER WITH(ROWLOCK)
    ( 	
		psc_file_import_id,
		cif,
		customer_dob,
		control_center,
		com_education_id,
		full_name,
		com_branch_id,
		create_by_user_id,
		create_date,
		update_by_user_id,
		update_date
	)
	SELECT
		tsscc0.psc_file_import_id,
		tsscc0.cif,
		tsscc0.customer_dob,
		tsscc0.control_center,
		isnull(tsscc0.com_education_id,0) as com_education_id,
		tsscc0.full_name,
		tsscc0.com_branch_id,
		@iCreateByUserID,
		getdate(),
		@iCreateByUserID,
		GETDATE()
	FROM
		tmpt_second_staging_com_customer tsscc0 with(nolock)
	where
		tsscc0.is_valid = 1 AND 
		tsscc0.CIF NOT IN (SELECT 
							cc0.CIF 
						   FROM 
							dbo.COM_CUSTOMER cc0 WITH(NOLOCK) 
						   WHERE 
							cc0.CIF = tsscc0.CIF)
END




