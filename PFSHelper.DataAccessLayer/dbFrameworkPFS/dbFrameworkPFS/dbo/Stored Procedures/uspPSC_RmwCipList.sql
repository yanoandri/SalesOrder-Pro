
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_RmwCipList
	Desc    		:	This store procedure is use to get list of PSC_RMW_CIP
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_RmwCipList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iFileImportID INT = NULL,
	@iCustomerID INT = NULL,
	@iCusID INT = NULL,
	@dtCustomerDobFrom DATETIME = NULL,
	@dtCustomerDobTo DATETIME = NULL,
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
	@dtExpiryDateFrom DATETIME = NULL,
	@dtExpiryDateTo DATETIME = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL
)
AS
BEGIN
	SELECT
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
		cr6.rm_name
	FROM
		psc_rmw_cip prc0 WITH (NOLOCK),
		psc_file_import pfi1 WITH (NOLOCK),
		com_customer cc2 WITH (NOLOCK),
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
		(@iFileImportID IS NULL OR prc0.psc_file_import_id = @iFileImportID) AND
		(@iCustomerID IS NULL OR prc0.com_customer_id = @iCustomerID) AND
		(@iCusID IS NULL OR prc0.cus_id = @iCusID) AND
		(@dtCustomerDobFrom IS NULL OR CONVERT(VARCHAR, prc0.customer_dob, 12) >= CONVERT(VARCHAR, @dtCustomerDobFrom, 12)) AND
		(@dtCustomerDobTo IS NULL OR CONVERT(VARCHAR, prc0.customer_dob, 12) <= CONVERT(VARCHAR, @dtCustomerDobTo, 12)) AND
		(@iBranchID IS NULL OR prc0.com_branch_id = @iBranchID) AND
		(@iCustomerSegmentID IS NULL OR prc0.com_customer_segment_id = @iCustomerSegmentID) AND
		(@iCustomerRiskRatingID IS NULL OR prc0.com_customer_risk_rating_id = @iCustomerRiskRatingID) AND
		(@iRmID IS NULL OR prc0.com_rm_id = @iRmID) AND
		(@bQ1Em IS NULL OR prc0.q1_em = @bQ1Em) AND
		(@bQ31 IS NULL OR prc0.q3_1 = @bQ31) AND
		(@bQ32 IS NULL OR prc0.q3_2 = @bQ32) AND
		(@bQ33 IS NULL OR prc0.q3_3 = @bQ33) AND
		(@bQ34 IS NULL OR prc0.q3_4 = @bQ34) AND
		(@bQ35 IS NULL OR prc0.q3_5 = @bQ35) AND
		(@bQ36 IS NULL OR prc0.q3_6 = @bQ36) AND
		(@bQ37 IS NULL OR prc0.q3_7 = @bQ37) AND
		(@bQ38 IS NULL OR prc0.q3_8 = @bQ38) AND
		(@bQ39 IS NULL OR prc0.q3_9 = @bQ39) AND
		(@bQ310 IS NULL OR prc0.q3_10 = @bQ310) AND
		(@bQ311 IS NULL OR prc0.q3_11 = @bQ311) AND
		(@bQ312 IS NULL OR prc0.q3_12 = @bQ312) AND
		(@bQ313 IS NULL OR prc0.q3_13 = @bQ313) AND
		(@bQ41 IS NULL OR prc0.q4_1 = @bQ41) AND
		(@bQ42 IS NULL OR prc0.q4_2 = @bQ42) AND
		(@bQ43 IS NULL OR prc0.q4_3 = @bQ43) AND
		(@bQ44 IS NULL OR prc0.q4_4 = @bQ44) AND
		(@bQ45 IS NULL OR prc0.q4_5 = @bQ45) AND
		(@bQ46 IS NULL OR prc0.q4_6 = @bQ46) AND
		(@bQ61 IS NULL OR prc0.q6_1 = @bQ61) AND
		(@bQ62 IS NULL OR prc0.q6_2 = @bQ62) AND
		(@bQ63 IS NULL OR prc0.q6_3 = @bQ63) AND
		(@bQ64 IS NULL OR prc0.q6_4 = @bQ64) AND
		(@bQ65 IS NULL OR prc0.q6_5 = @bQ65) AND
		(@bQ66 IS NULL OR prc0.q6_6 = @bQ66) AND
		(@dtExpiryDateFrom IS NULL OR CONVERT(VARCHAR, prc0.expiry_date, 12) >= CONVERT(VARCHAR, @dtExpiryDateFrom, 12)) AND
		(@dtExpiryDateTo IS NULL OR CONVERT(VARCHAR, prc0.expiry_date, 12) <= CONVERT(VARCHAR, @dtExpiryDateTo, 12)) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, prc0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, prc0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR prc0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, prc0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, prc0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR prc0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		prc0.cif LIKE '%' + @sKeyWords + '%' OR
		prc0.education_name LIKE '%' + @sKeyWords + '%' OR
		prc0.p1_q1 LIKE '%' + @sKeyWords + '%' OR
		prc0.p1_q2 LIKE '%' + @sKeyWords + '%' OR
		prc0.p1_q3 LIKE '%' + @sKeyWords + '%' OR
		prc0.p1_q4 LIKE '%' + @sKeyWords + '%' OR
		prc0.p1_q5 LIKE '%' + @sKeyWords + '%' OR
		prc0.p1_q6 LIKE '%' + @sKeyWords + '%' OR
		prc0.p1_q7 LIKE '%' + @sKeyWords + '%')
END
