
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_RmwCipUpdate
	Desc    		:	This store procedure is use to update PSC_RMW_CIP
	Create Date 	:	20 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_RmwCipUpdate
(
	@iRmwCipID INT,
	@iFileImportID INT,
	@sCif VARCHAR(15),
	@iCustomerID INT,
	@iCusID INT,
	@dtCustomerDob DATETIME,
	@iBranchID INT,
	@iCustomerSegmentID INT,
	@iCustomerRiskRatingID INT,
	@sEducationName VARCHAR(100),
	@iRmID INT,
	@sP1Q1 VARCHAR(2),
	@sP1Q2 VARCHAR(2),
	@sP1Q3 VARCHAR(2),
	@sP1Q4 VARCHAR(2),
	@sP1Q5 VARCHAR(2),
	@sP1Q6 VARCHAR(2),
	@sP1Q7 VARCHAR(2),
	@bQ1Em BIT,
	@dQ2TotalAsset FLOAT,
	@dQ2TotalLiabilities FLOAT,
	@bQ31 BIT,
	@bQ32 BIT,
	@bQ33 BIT,
	@bQ34 BIT,
	@bQ35 BIT,
	@bQ36 BIT,
	@bQ37 BIT,
	@bQ38 BIT,
	@bQ39 BIT,
	@bQ310 BIT,
	@bQ311 BIT,
	@bQ312 BIT,
	@bQ313 BIT,
	@bQ41 BIT,
	@bQ42 BIT,
	@bQ43 BIT,
	@bQ44 BIT,
	@bQ45 BIT,
	@bQ46 BIT,
	@dQ5Ith FLOAT,
	@bQ61 BIT,
	@bQ62 BIT,
	@bQ63 BIT,
	@bQ64 BIT,
	@bQ65 BIT,
	@bQ66 BIT,
	@dtExpiryDate DATETIME,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	UPDATE PSC_RMW_CIP SET
		psc_file_import_id = @iFileImportID,
		cif = @sCif,
		com_customer_id = @iCustomerID,
		cus_id = @iCusID,
		customer_dob = @dtCustomerDob,
		com_branch_id = @iBranchID,
		com_customer_segment_id = @iCustomerSegmentID,
		com_customer_risk_rating_id = @iCustomerRiskRatingID,
		education_name = @sEducationName,
		com_rm_id = @iRmID,
		p1_q1 = @sP1Q1,
		p1_q2 = @sP1Q2,
		p1_q3 = @sP1Q3,
		p1_q4 = @sP1Q4,
		p1_q5 = @sP1Q5,
		p1_q6 = @sP1Q6,
		p1_q7 = @sP1Q7,
		q1_em = @bQ1Em,
		q2_total_asset = @dQ2TotalAsset,
		q2_total_liabilities = @dQ2TotalLiabilities,
		q3_1 = @bQ31,
		q3_2 = @bQ32,
		q3_3 = @bQ33,
		q3_4 = @bQ34,
		q3_5 = @bQ35,
		q3_6 = @bQ36,
		q3_7 = @bQ37,
		q3_8 = @bQ38,
		q3_9 = @bQ39,
		q3_10 = @bQ310,
		q3_11 = @bQ311,
		q3_12 = @bQ312,
		q3_13 = @bQ313,
		q4_1 = @bQ41,
		q4_2 = @bQ42,
		q4_3 = @bQ43,
		q4_4 = @bQ44,
		q4_5 = @bQ45,
		q4_6 = @bQ46,
		q5_ith = @dQ5Ith,
		q6_1 = @bQ61,
		q6_2 = @bQ62,
		q6_3 = @bQ63,
		q6_4 = @bQ64,
		q6_5 = @bQ65,
		q6_6 = @bQ66,
		expiry_date = @dtExpiryDate,
		create_date = @dtCreateDate,
		create_by_user_id = @iCreateByUserID,
		update_date = @dtUpdateDate,
		update_by_user_id = @iUpdateByUserID
	WHERE
      	psc_rmw_cip_id = @iRmwCipID

	SELECT @@ERROR
END
