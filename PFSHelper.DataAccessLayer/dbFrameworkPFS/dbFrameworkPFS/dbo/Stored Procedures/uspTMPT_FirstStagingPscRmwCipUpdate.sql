
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscRmwCipUpdate
	Desc    		:	This store procedure is use to update TMPT_FIRST_STAGING_PSC_RMW_CIP
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingPscRmwCipUpdate
(
	@iFirstStagingPscRmwCipID INT,
	@iFileImportID INT,
	@sCif VARCHAR(15),
	@sCustomerID VARCHAR(25),
	@sCustomerDob VARCHAR(20),
	@sBranchCode VARCHAR(10),
	@sBranchName VARCHAR(100),
	@sCustomerSegmentName VARCHAR(10),
	@sCustomerRiskRatingScore VARCHAR(5),
	@sEducationName VARCHAR(100),
	@sRmCode VARCHAR(10),
	@sRmName VARCHAR(255),
	@sP1Q1 VARCHAR(2),
	@sP1Q2 VARCHAR(2),
	@sP1Q3 VARCHAR(2),
	@sP1Q4 VARCHAR(2),
	@sP1Q5 VARCHAR(2),
	@sP1Q6 VARCHAR(2),
	@sP1Q7 VARCHAR(2),
	@sQ1Em VARCHAR(3),
	@sQ2TotalAsset VARCHAR(50),
	@sQ2TotalLiabilities VARCHAR(50),
	@sQ31 VARCHAR(3),
	@sQ32 VARCHAR(3),
	@sQ33 VARCHAR(3),
	@sQ34 VARCHAR(3),
	@sQ35 VARCHAR(3),
	@sQ36 VARCHAR(3),
	@sQ37 VARCHAR(3),
	@sQ38 VARCHAR(3),
	@sQ39 VARCHAR(3),
	@sQ310 VARCHAR(3),
	@sQ311 VARCHAR(3),
	@sQ312 VARCHAR(3),
	@sQ313 VARCHAR(3),
	@sQ41 VARCHAR(3),
	@sQ42 VARCHAR(3),
	@sQ43 VARCHAR(3),
	@sQ44 VARCHAR(3),
	@sQ45 VARCHAR(3),
	@sQ46 VARCHAR(3),
	@sQ5Ith VARCHAR(30),
	@sQ61 VARCHAR(3),
	@sQ62 VARCHAR(3),
	@sQ63 VARCHAR(3),
	@sQ64 VARCHAR(3),
	@sQ65 VARCHAR(3),
	@sQ66 VARCHAR(3),
	@sCreateDate VARCHAR(50),
	@bIsValid BIT,
	@sRemark VARCHAR(250)
)
AS
BEGIN
	UPDATE TMPT_FIRST_STAGING_PSC_RMW_CIP SET
		psc_file_import_id = @iFileImportID,
		cif = @sCif,
		customer_id = @sCustomerID,
		customer_dob = @sCustomerDob,
		branch_code = @sBranchCode,
		branch_name = @sBranchName,
		customer_segment_name = @sCustomerSegmentName,
		customer_risk_rating_score = @sCustomerRiskRatingScore,
		education_name = @sEducationName,
		rm_code = @sRmCode,
		rm_name = @sRmName,
		p1_q1 = @sP1Q1,
		p1_q2 = @sP1Q2,
		p1_q3 = @sP1Q3,
		p1_q4 = @sP1Q4,
		p1_q5 = @sP1Q5,
		p1_q6 = @sP1Q6,
		p1_q7 = @sP1Q7,
		q1_em = @sQ1Em,
		q2_total_asset = @sQ2TotalAsset,
		q2_total_liabilities = @sQ2TotalLiabilities,
		q3_1 = @sQ31,
		q3_2 = @sQ32,
		q3_3 = @sQ33,
		q3_4 = @sQ34,
		q3_5 = @sQ35,
		q3_6 = @sQ36,
		q3_7 = @sQ37,
		q3_8 = @sQ38,
		q3_9 = @sQ39,
		q3_10 = @sQ310,
		q3_11 = @sQ311,
		q3_12 = @sQ312,
		q3_13 = @sQ313,
		q4_1 = @sQ41,
		q4_2 = @sQ42,
		q4_3 = @sQ43,
		q4_4 = @sQ44,
		q4_5 = @sQ45,
		q4_6 = @sQ46,
		q5_ith = @sQ5Ith,
		q6_1 = @sQ61,
		q6_2 = @sQ62,
		q6_3 = @sQ63,
		q6_4 = @sQ64,
		q6_5 = @sQ65,
		q6_6 = @sQ66,
		create_date = @sCreateDate,
		is_valid = @bIsValid,
		remark = @sRemark
	WHERE
      	tmpt_first_staging_psc_rmw_cip_id = @iFirstStagingPscRmwCipID

	SELECT @@ERROR
END
