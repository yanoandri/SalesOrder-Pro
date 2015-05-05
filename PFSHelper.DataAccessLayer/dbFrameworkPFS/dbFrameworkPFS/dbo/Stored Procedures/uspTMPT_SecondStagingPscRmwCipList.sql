
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_SecondStagingPscRmwCipList
	Desc    		:	This store procedure is use to get list of TMPT_SECOND_STAGING_PSC_RMW_CIP
	Create Date 	:	23 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_SecondStagingPscRmwCipList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iFileImportID INT = NULL,
	@iCustomerID INT = NULL,
	@iCusID INT = NULL,
	@iBranchID INT = NULL,
	@iCustomerSegmentID INT = NULL,
	@iCustomerRiskRatingID INT = NULL,
	@iRmID INT = NULL,
	@bQ1Em BIT = NULL,
	@bQ31 BIT = NULL,
	@bQ32 BIT = NULL,
	@bQ33 BIT = NULL,
	@bQ34 BIT = NULL,
	@bQ35 BIT = NULL,
	@bQ36 BIT = NULL,
	@bQ37 BIT = NULL,
	@bQ38 BIT = NULL,
	@bQ39 BIT = NULL,
	@bQ310 BIT = NULL,
	@bQ311 BIT = NULL,
	@bQ312 BIT = NULL,
	@bQ313 BIT = NULL,
	@bQ41 BIT = NULL,
	@bQ42 BIT = NULL,
	@bQ43 BIT = NULL,
	@bQ44 BIT = NULL,
	@bQ45 BIT = NULL,
	@bQ46 BIT = NULL,
	@bQ61 BIT = NULL,
	@bQ62 BIT = NULL,
	@bQ63 BIT = NULL,
	@bQ64 BIT = NULL,
	@bQ65 BIT = NULL,
	@bQ66 BIT = NULL,
	@bIsValid BIT = NULL
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
		(@iFileImportID IS NULL OR tssprc0.psc_file_import_id = @iFileImportID) AND
		(@iCustomerID IS NULL OR tssprc0.com_customer_id = @iCustomerID) AND
		(@iCusID IS NULL OR tssprc0.cus_id = @iCusID) AND
		(@iBranchID IS NULL OR tssprc0.com_branch_id = @iBranchID) AND
		(@iCustomerSegmentID IS NULL OR tssprc0.com_customer_segment_id = @iCustomerSegmentID) AND
		(@iCustomerRiskRatingID IS NULL OR tssprc0.com_customer_risk_rating_id = @iCustomerRiskRatingID) AND
		(@iRmID IS NULL OR tssprc0.com_rm_id = @iRmID) AND
		(@bQ1Em IS NULL OR tssprc0.q1_em = @bQ1Em) AND
		(@bQ31 IS NULL OR tssprc0.q3_1 = @bQ31) AND
		(@bQ32 IS NULL OR tssprc0.q3_2 = @bQ32) AND
		(@bQ33 IS NULL OR tssprc0.q3_3 = @bQ33) AND
		(@bQ34 IS NULL OR tssprc0.q3_4 = @bQ34) AND
		(@bQ35 IS NULL OR tssprc0.q3_5 = @bQ35) AND
		(@bQ36 IS NULL OR tssprc0.q3_6 = @bQ36) AND
		(@bQ37 IS NULL OR tssprc0.q3_7 = @bQ37) AND
		(@bQ38 IS NULL OR tssprc0.q3_8 = @bQ38) AND
		(@bQ39 IS NULL OR tssprc0.q3_9 = @bQ39) AND
		(@bQ310 IS NULL OR tssprc0.q3_10 = @bQ310) AND
		(@bQ311 IS NULL OR tssprc0.q3_11 = @bQ311) AND
		(@bQ312 IS NULL OR tssprc0.q3_12 = @bQ312) AND
		(@bQ313 IS NULL OR tssprc0.q3_13 = @bQ313) AND
		(@bQ41 IS NULL OR tssprc0.q4_1 = @bQ41) AND
		(@bQ42 IS NULL OR tssprc0.q4_2 = @bQ42) AND
		(@bQ43 IS NULL OR tssprc0.q4_3 = @bQ43) AND
		(@bQ44 IS NULL OR tssprc0.q4_4 = @bQ44) AND
		(@bQ45 IS NULL OR tssprc0.q4_5 = @bQ45) AND
		(@bQ46 IS NULL OR tssprc0.q4_6 = @bQ46) AND
		(@bQ61 IS NULL OR tssprc0.q6_1 = @bQ61) AND
		(@bQ62 IS NULL OR tssprc0.q6_2 = @bQ62) AND
		(@bQ63 IS NULL OR tssprc0.q6_3 = @bQ63) AND
		(@bQ64 IS NULL OR tssprc0.q6_4 = @bQ64) AND
		(@bQ65 IS NULL OR tssprc0.q6_5 = @bQ65) AND
		(@bQ66 IS NULL OR tssprc0.q6_6 = @bQ66) AND
		(@bIsValid IS NULL OR tssprc0.is_valid = @bIsValid) AND
		(@sKeyWords IS NULL OR
		tssprc0.cif LIKE '%' + @sKeyWords + '%' OR
		tssprc0.customer_dob LIKE '%' + @sKeyWords + '%' OR
		tssprc0.branch_code LIKE '%' + @sKeyWords + '%' OR
		tssprc0.branch_name LIKE '%' + @sKeyWords + '%' OR
		tssprc0.education_name LIKE '%' + @sKeyWords + '%' OR
		tssprc0.p1_q1 LIKE '%' + @sKeyWords + '%' OR
		tssprc0.p1_q2 LIKE '%' + @sKeyWords + '%' OR
		tssprc0.p1_q3 LIKE '%' + @sKeyWords + '%' OR
		tssprc0.p1_q4 LIKE '%' + @sKeyWords + '%' OR
		tssprc0.p1_q5 LIKE '%' + @sKeyWords + '%' OR
		tssprc0.p1_q6 LIKE '%' + @sKeyWords + '%' OR
		tssprc0.p1_q7 LIKE '%' + @sKeyWords + '%' OR
		tssprc0.invalid_remark LIKE '%' + @sKeyWords + '%' OR
		tssprc0.create_date LIKE '%' + @sKeyWords + '%')
END
