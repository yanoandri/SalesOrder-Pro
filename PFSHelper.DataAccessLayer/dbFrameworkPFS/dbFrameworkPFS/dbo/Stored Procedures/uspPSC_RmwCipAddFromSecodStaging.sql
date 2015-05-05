/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_RmwCipAdd
	Desc    		:	This store procedure is use to add PSC_RMW_CIP
	Create Date 	:	20 Jan 2015		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_RmwCipAddFromSecodStaging]
(	
	@iCreateByUserID INT
)
AS
BEGIN	
    
	INSERT INTO PSC_RMW_CIP WITH(rowlock)
    ( 	
		psc_file_import_id,
		cif,
		com_customer_id,
		cus_id,
		customer_dob,
		com_branch_id,
		com_customer_segment_id,
		com_customer_risk_rating_id,
		education_name,
		com_rm_id,
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
		expiry_date,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	SELECT
		tssprc0.psc_file_import_id,
		tssprc0.cif,
		ISNULL(tssprc0.com_customer_id,
		(SELECT 
			TOP 1 cc0.COM_CUSTOMER_ID 
		FROM 
			dbo.COM_CUSTOMER cc0 WITH(NOLOCK) 
		WHERE 
			cc0.CIF = tssprc0.CIF)),
		tssprc0.cus_id,
		tssprc0.customer_dob,
		tssprc0.com_branch_id,
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
		--DATEADD(YEAR,1,tssprc0.create_date),
		DATEADD(MONTH,
			CONVERT(INT,(SELECT 
							VALUE 
						 FROM 
							dbo.PFS_SYS_PARAM WITH(NOLOCK) 
						 WHERE 
							code ='RMW_CIP_EXPIRY_PERIOD')),
			tssprc0.CREATE_DATE),
		tssprc0.create_date,
		@iCreateByUserID,
		GETDATE(),
		@iCreateByUserID

	FROM
		TMPT_SECOND_STAGING_PSC_RMW_CIP tssprc0 WITH(NOLOCK)
	where
		is_valid = 1
	
END

