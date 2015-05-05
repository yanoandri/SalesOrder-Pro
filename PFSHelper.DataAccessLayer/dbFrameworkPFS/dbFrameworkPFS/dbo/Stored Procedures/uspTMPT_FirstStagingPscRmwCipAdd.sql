﻿/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscRmwCipAdd
	Desc    		:	This store procedure is use to add TMPT_FIRST_STAGING_PSC_RMW_CIP
	Create Date 	:	29 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspTMPT_FirstStagingPscRmwCipAdd
(
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
	DECLARE @iFirstStagingPscRmwCipID INT
    
	INSERT INTO TMPT_FIRST_STAGING_PSC_RMW_CIP 
    ( 	
		psc_file_import_id,
		cif,
		customer_id,
		customer_dob,
		branch_code,
		branch_name,
		customer_segment_name,
		customer_risk_rating_score,
		education_name,
		rm_code,
		rm_name,
		p1_q1,
		p1_q2,
		p1_q3,
		p1_q4,
		p1_q5,
		p1_q6,
		p1_q7,
		q1_em,
		q2_total_asset,
		q2_total_liabilities,
		q3_1,
		q3_2,
		q3_3,
		q3_4,
		q3_5,
		q3_6,
		q3_7,
		q3_8,
		q3_9,
		q3_10,
		q3_11,
		q3_12,
		q3_13,
		q4_1,
		q4_2,
		q4_3,
		q4_4,
		q4_5,
		q4_6,
		q5_ith,
		q6_1,
		q6_2,
		q6_3,
		q6_4,
		q6_5,
		q6_6,
		create_date,
		is_valid,
		remark
	)
	VALUES
	(
		@iFileImportID,
		@sCif,
		@sCustomerID,
		@sCustomerDob,
		@sBranchCode,
		@sBranchName,
		@sCustomerSegmentName,
		@sCustomerRiskRatingScore,
		@sEducationName,
		@sRmCode,
		@sRmName,
		@sP1Q1,
		@sP1Q2,
		@sP1Q3,
		@sP1Q4,
		@sP1Q5,
		@sP1Q6,
		@sP1Q7,
		@sQ1Em,
		@sQ2TotalAsset,
		@sQ2TotalLiabilities,
		@sQ31,
		@sQ32,
		@sQ33,
		@sQ34,
		@sQ35,
		@sQ36,
		@sQ37,
		@sQ38,
		@sQ39,
		@sQ310,
		@sQ311,
		@sQ312,
		@sQ313,
		@sQ41,
		@sQ42,
		@sQ43,
		@sQ44,
		@sQ45,
		@sQ46,
		@sQ5Ith,
		@sQ61,
		@sQ62,
		@sQ63,
		@sQ64,
		@sQ65,
		@sQ66,
		@sCreateDate,
		@bIsValid,
		@sRemark
	)
    
	SET @iFirstStagingPscRmwCipID = ISNULL(@@IDENTITY, 0)
	SELECT @iFirstStagingPscRmwCipID
END
