/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspTMPT_FirstStagingPscRmwCipAdd
	Desc    		:	This store procedure is use to add TMPT_FIRST_STAGING_PSC_RMW_CIP
	Create Date 	:	19 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspTMPT_FirstStagingPscRmwCipAddWithXml]
(
	@iFileImportID INT,
	@sXml XML
)
AS
BEGIN
    
	INSERT INTO TMPT_FIRST_STAGING_PSC_RMW_CIP WITH(ROWLOCK)
    ( 	
		psc_file_import_id,
		cif,
		customer_id,
		customer_dob,
		branch_code,
		branch_name,
		customer_segment_name,
		customer_risk_rating_score,
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
		rm_code,
		rm_name,
		education_name
	)
	SELECT
		  @iFileImportID,
	      TXM.M.value('@CIF', 'varchar(100)'),
		  TXM.M.value('@CUSTOMER_ID', 'varchar(100)'),
	      TXM.M.value('@CUSTOMER_DOB', 'varchar(100)'),
		  TXM.M.value('@BRANCH_CODE', 'varchar(100)'),
	      TXM.M.value('@BRANCH_NAME', 'varchar(100)'),
		  TXM.M.value('@CUSTOMER_SEGMENT_NAME', 'varchar(100)'),
	      TXM.M.value('@CUSTOMER_RISK_RATING_SCORE', 'varchar(100)'),
	      TXM.M.value('@P1_Q1', 'varchar(5)'),
		  TXM.M.value('@P1_Q2', 'varchar(5)'),
	      TXM.M.value('@P1_Q3', 'varchar(5)'),
		  TXM.M.value('@P1_Q4', 'varchar(5)'),
	      TXM.M.value('@P1_Q5', 'varchar(5)'),
		  TXM.M.value('@P1_Q6', 'varchar(5)'),
	      TXM.M.value('@P1_Q7', 'varchar(5)'),
		  TXM.M.value('@Q1_EM', 'varchar(100)'),
	      TXM.M.value('@Q2_TOTAL_ASSET', 'varchar(100)'),
		  TXM.M.value('@Q2_TOTAL_LIABILITIES', 'varchar(100)'),
	      TXM.M.value('@Q3_1', 'varchar(5)'),
		  TXM.M.value('@Q3_2', 'varchar(5)'),
	      TXM.M.value('@Q3_3', 'varchar(5)'),
		  TXM.M.value('@Q3_4', 'varchar(5)'),
	      TXM.M.value('@Q3_5', 'varchar(5)'),
		  TXM.M.value('@Q3_6', 'varchar(5)'),
	      TXM.M.value('@Q3_7', 'varchar(5)'),
		  TXM.M.value('@Q3_8', 'varchar(5)'),
	      TXM.M.value('@Q3_9', 'varchar(5)'),
		  TXM.M.value('@Q3_10', 'varchar(5)'),
	      TXM.M.value('@Q3_11', 'varchar(5)'),
		  TXM.M.value('@Q3_12', 'varchar(5)'),
	      TXM.M.value('@Q3_13', 'varchar(5)'),
		  TXM.M.value('@Q4_1', 'varchar(5)'),
	      TXM.M.value('@Q4_2', 'varchar(5)'),
		  TXM.M.value('@Q4_3', 'varchar(5)'),
	      TXM.M.value('@Q4_4', 'varchar(5)'),
		  TXM.M.value('@Q4_5', 'varchar(5)'),
	      TXM.M.value('@Q4_6', 'varchar(6)'),
		  TXM.M.value('@Q5_ITH', 'varchar(100)'),
	      TXM.M.value('@Q6_1', 'varchar(5)'),
		  TXM.M.value('@Q6_2', 'varchar(5)'),
	      TXM.M.value('@Q6_3', 'varchar(5)'),
		  TXM.M.value('@Q6_4', 'varchar(5)'),
	      TXM.M.value('@Q6_5', 'varchar(5)'),
		  TXM.M.value('@Q6_6', 'varchar(6)'),
		  TXM.M.value('@CREATE_DATE', 'varchar(50)'),
	      TXM.M.value('@RM_CODE', 'varchar(100)'),
		  TXM.M.value('@RM_NAME', 'varchar(100)'),
		  TXM.M.value('@EDUCATION_NAME', 'varchar(100)')
	FROM        
		@sXml.nodes('/FIRST_STAGING_RMW_CIP/MEMBER') AS TXM(M)
    
END

