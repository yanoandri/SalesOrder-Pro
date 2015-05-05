
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscRmwCipGet
	Desc    		:	This store procedure is use to get TMPT_FIRST_STAGING_PSC_RMW_CIP by id
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingPscRmwCipGet
(
	@iFirstStagingPscRmwCipID INT
)
AS
BEGIN
	SELECT
		tfsprc0.tmpt_first_staging_psc_rmw_cip_id,
		tfsprc0.psc_file_import_id,
		tfsprc0.cif,
		tfsprc0.customer_id,
		tfsprc0.customer_dob,
		tfsprc0.branch_code,
		tfsprc0.branch_name,
		tfsprc0.customer_segment_name,
		tfsprc0.customer_risk_rating_score,
		tfsprc0.education_name,
		tfsprc0.rm_code,
		tfsprc0.rm_name,
		tfsprc0.p1_q1,
		tfsprc0.p1_q2,
		tfsprc0.p1_q3,
		tfsprc0.p1_q4,
		tfsprc0.p1_q5,
		tfsprc0.p1_q6,
		tfsprc0.p1_q7,
		tfsprc0.q1_em,
		tfsprc0.q2_total_asset,
		tfsprc0.q2_total_liabilities,
		tfsprc0.q3_1,
		tfsprc0.q3_2,
		tfsprc0.q3_3,
		tfsprc0.q3_4,
		tfsprc0.q3_5,
		tfsprc0.q3_6,
		tfsprc0.q3_7,
		tfsprc0.q3_8,
		tfsprc0.q3_9,
		tfsprc0.q3_10,
		tfsprc0.q3_11,
		tfsprc0.q3_12,
		tfsprc0.q3_13,
		tfsprc0.q4_1,
		tfsprc0.q4_2,
		tfsprc0.q4_3,
		tfsprc0.q4_4,
		tfsprc0.q4_5,
		tfsprc0.q4_6,
		tfsprc0.q5_ith,
		tfsprc0.q6_1,
		tfsprc0.q6_2,
		tfsprc0.q6_3,
		tfsprc0.q6_4,
		tfsprc0.q6_5,
		tfsprc0.q6_6,
		tfsprc0.create_date,
		tfsprc0.is_valid,
		tfsprc0.remark,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name
	FROM
		tmpt_first_staging_psc_rmw_cip tfsprc0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK)
	WHERE
		tfsprc0.psc_file_import_id = pfi1.psc_file_import_id AND
		tfsprc0.tmpt_first_staging_psc_rmw_cip_id = @iFirstStagingPscRmwCipID
END
