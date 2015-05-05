
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CustomerGet
	Desc    		:	This store procedure is use to get COM_CUSTOMER by id
	Create Date 	:	27 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_CustomerGet
(
	@iCustomerID INT
)
AS
BEGIN
	SELECT
		cc0.com_customer_id,
		cc0.psc_file_import_id,
		cc0.cif,
		cc0.customer_dob,
		cc0.control_center,
		cc0.com_education_id,
		cc0.full_name,
		cc0.com_branch_id,
		cc0.field_reserve_1,
		cc0.field_reserve_2,
		cc0.field_reserve_3,
		cc0.is_active,
		cc0.is_deleted,
		cc0.create_date,
		cc0.create_by_user_id,
		cc0.update_date,
		cc0.update_by_user_id,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name,
		ce2.education_name,
		cb3.branch_code,
		cb3.branch_name
	FROM
		com_customer cc0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK),
		com_education ce2 WITH (NOLOCK),
		com_branch cb3 WITH (NOLOCK)
	WHERE
		cc0.psc_file_import_id = pfi1.psc_file_import_id AND
		cc0.com_education_id = ce2.com_education_id AND
		cc0.com_branch_id = cb3.com_branch_id AND
		cc0.com_customer_id = @iCustomerID
END
