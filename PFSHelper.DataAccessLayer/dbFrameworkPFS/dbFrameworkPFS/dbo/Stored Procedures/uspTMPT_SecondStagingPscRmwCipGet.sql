
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingPscRmwCipGet
	Desc    		:	This store procedure is use to get TMPT_SECOND_STAGING_PSC_RMW_CIP by id
	Create Date 	:	23 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingPscRmwCipGet
(
	@iSecondStagingPscRmwCipID INT
)
AS
BEGIN
	SELECT
		tssprc0.tmpt_second_staging_psc_rmw_cip_id,
		tssprc0.psc_file_import_id,
		tssprc0.cif,
		tssprc0.com_customer_id,
		tssprc0.cus_id,
		tssprc0.customer_dob,
		tssprc0.com_branch_id,
		tssprc0.branch_code,
		tssprc0.branch_name,
		tssprc0.com_customer_segment_id,
		tssprc0.com_customer_risk_rating_id,
		tssprc0.education_name,
		tssprc0.com_rm_id,
		tssprc0.p1_q1,
		tssprc0.p1_q2,
		tssprc0.p1_q3,
		tssprc0.p1_q4,
		tssprc0.p1_q5,
		tssprc0.p1_q6,
		tssprc0.p1_q7,
		tssprc0.q1_em,
		tssprc0.q2_total_asset,
		tssprc0.q2_total_liabilities,
		tssprc0.q3_1,
		tssprc0.q3_2,
		tssprc0.q3_3,
		tssprc0.q3_4,
		tssprc0.q3_5,
		tssprc0.q3_6,
		tssprc0.q3_7,
		tssprc0.q3_8,
		tssprc0.q3_9,
		tssprc0.q3_10,
		tssprc0.q3_11,
		tssprc0.q3_12,
		tssprc0.q3_13,
		tssprc0.q4_1,
		tssprc0.q4_2,
		tssprc0.q4_3,
		tssprc0.q4_4,
		tssprc0.q4_5,
		tssprc0.q4_6,
		tssprc0.q5_ith,
		tssprc0.q6_1,
		tssprc0.q6_2,
		tssprc0.q6_3,
		tssprc0.q6_4,
		tssprc0.q6_5,
		tssprc0.q6_6,
		tssprc0.is_valid,
		tssprc0.invalid_remark,
		tssprc0.create_date,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name,
		cc2.full_name,
		cb3.branch_code,
		cb3.branch_name,
		ccs4.customer_segment_name,
		ccs4.segment_code,
		cr6.rm_code,
		cr6.rm_name
	FROM
		tmpt_second_staging_psc_rmw_cip tssprc0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK),
		com_customer cc2 WITH (NOLOCK),
		com_branch cb3 WITH (NOLOCK),
		com_customer_segment ccs4 WITH (NOLOCK),
		com_customer_risk_rating ccrr5 WITH (NOLOCK),
		com_rm cr6 WITH (NOLOCK)
	WHERE
		tssprc0.psc_file_import_id = pfi1.psc_file_import_id AND
		tssprc0.com_customer_id = cc2.com_customer_id AND
		tssprc0.com_branch_id = cb3.com_branch_id AND
		tssprc0.com_customer_segment_id = ccs4.com_customer_segment_id AND
		tssprc0.com_customer_risk_rating_id = ccrr5.com_customer_risk_rating_id AND
		tssprc0.com_rm_id = cr6.com_rm_id AND
		tssprc0.tmpt_second_staging_psc_rmw_cip_id = @iSecondStagingPscRmwCipID
END
