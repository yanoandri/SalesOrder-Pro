
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_RmwCipGet
	Desc    		:	This store procedure is use to get PSC_RMW_CIP by id
	Create Date 	:	20 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_RmwCipGetByCif
(
	@sCif VARCHAR(50)
)
AS
BEGIN
	SELECT TOP 1
		prc0.psc_rmw_cip_id,
		prc0.psc_file_import_id,
		prc0.cif,
		prc0.com_customer_id,
		prc0.cus_id,
		prc0.customer_dob,
		prc0.com_branch_id,
		prc0.com_customer_segment_id,
		prc0.com_customer_risk_rating_id,
		prc0.education_name,
		prc0.com_rm_id,
		prc0.p1_q1,
		prc0.p1_q2,
		prc0.p1_q3,
		prc0.p1_q4,
		prc0.p1_q5,
		prc0.p1_q6,
		prc0.p1_q7,
		prc0.q1_em,
		prc0.q2_total_asset,
		prc0.q2_total_liabilities,
		prc0.q3_1,
		prc0.q3_2,
		prc0.q3_3,
		prc0.q3_4,
		prc0.q3_5,
		prc0.q3_6,
		prc0.q3_7,
		prc0.q3_8,
		prc0.q3_9,
		prc0.q3_10,
		prc0.q3_11,
		prc0.q3_12,
		prc0.q3_13,
		prc0.q4_1,
		prc0.q4_2,
		prc0.q4_3,
		prc0.q4_4,
		prc0.q4_5,
		prc0.q4_6,
		prc0.q5_ith,
		prc0.q6_1,
		prc0.q6_2,
		prc0.q6_3,
		prc0.q6_4,
		prc0.q6_5,
		prc0.q6_6,
		prc0.expiry_date,
		prc0.create_date,
		prc0.create_by_user_id,
		prc0.update_date,
		prc0.update_by_user_id,
		pfi1.file_name,
		pfi1.archive_file_name,
		pfi1.archive_invalid_data_file_name,
		cc2.full_name,
		cb3.branch_code,
		cb3.branch_name,
		ccs4.customer_segment_name,
		ccs4.segment_code,
		cr6.rm_code,
		cr6.rm_name,
		cc2.CUSTOMER_DOB,
		ISNULL(ce.COM_EDUCATION_ID,0) as COM_EDUCATION_ID,
		ccrr5.RISK_RATING_SCORE,
		cc2.FULL_NAME
	FROM
		psc_rmw_cip prc0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK),
		com_customer cc2 WITH (NOLOCK) left join	
		COM_EDUCATION ce with(nolock) 
		ON (ce.COM_EDUCATION_ID = cc2.COM_EDUCATION_ID),
		com_branch cb3 WITH (NOLOCK),
		com_customer_segment ccs4 WITH (NOLOCK),
		com_customer_risk_rating ccrr5 WITH (NOLOCK),
		com_rm cr6 WITH (NOLOCK)
	WHERE
		prc0.psc_file_import_id = pfi1.psc_file_import_id AND
		prc0.com_customer_id = cc2.com_customer_id AND
		prc0.com_branch_id = cb3.com_branch_id AND
		prc0.com_customer_segment_id = ccs4.com_customer_segment_id AND
		prc0.com_customer_risk_rating_id = ccrr5.com_customer_risk_rating_id AND
		prc0.com_rm_id = cr6.com_rm_id AND
		prc0.CIF = @sCif
	ORDER BY 
		prc0.PSC_RMW_CIP_ID desc
END
