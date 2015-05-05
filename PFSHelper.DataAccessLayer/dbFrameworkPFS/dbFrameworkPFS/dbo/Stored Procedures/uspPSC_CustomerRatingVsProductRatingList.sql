
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_CustomerRatingVsProductRatingList
	Desc    		:	This store procedure is use to get list of PSC_CUSTOMER_RATING_VS_PRODUCT_RATING
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspPSC_CustomerRatingVsProductRatingList
(
	@sKeyWords VARCHAR(1280) = NULL,
	@iCustomerRiskRatingID INT = NULL,
	@bIsActive BIT = NULL,
	@dtCreateDateFrom DATETIME = NULL,
	@dtCreateDateTo DATETIME = NULL,
	@iCreateByUserID INT = NULL,
	@dtUpdateDateFrom DATETIME = NULL,
	@dtUpdateDateTo DATETIME = NULL,
	@iUpdateByUserID INT = NULL
	,@iPageSize INT = 10
    ,@iPageNumber INT = 1 
)
AS
BEGIN
	DECLARE @iFirstRow INT, @iLastRow INT
    SET @iFirstRow = NULL
    SET @iLastRow= NULL
	
	SELECT
		@iFirstRow = ( @iPageNumber - 1) * @iPageSize + 1,
        @iLastRow = (@iPageNumber - 1) * @iPageSize + @iPageSize;
    
	WITH Paging AS (
		SELECT
		ROW_NUMBER() OVER (ORDER BY pcrvpr0.psc_customer_rating_vs_product_rating_id ASC) AS row_number,
			pcrvpr0.psc_customer_rating_vs_product_rating_id,
		pcrvpr0.com_customer_risk_rating_id,
		pcrvpr0.product_rating_to_with_exception,
		pcrvpr0.product_rating_to_with_no_exception,
		pcrvpr0.is_active,
		pcrvpr0.create_date,
		pcrvpr0.create_by_user_id,
		pcrvpr0.update_date,
		pcrvpr0.update_by_user_id
	FROM
		psc_customer_rating_vs_product_rating pcrvpr0 WITH (NOLOCK),
		com_customer_risk_rating ccrr1 WITH (NOLOCK)
	WHERE
		pcrvpr0.com_customer_risk_rating_id = ccrr1.com_customer_risk_rating_id AND
		(@iCustomerRiskRatingID IS NULL OR pcrvpr0.com_customer_risk_rating_id = @iCustomerRiskRatingID) AND
		(@bIsActive IS NULL OR pcrvpr0.is_active = @bIsActive) AND
		(@dtCreateDateFrom IS NULL OR CONVERT(VARCHAR, pcrvpr0.create_date, 12) >= CONVERT(VARCHAR, @dtCreateDateFrom, 12)) AND
		(@dtCreateDateTo IS NULL OR CONVERT(VARCHAR, pcrvpr0.create_date, 12) <= CONVERT(VARCHAR, @dtCreateDateTo, 12)) AND
		(@iCreateByUserID IS NULL OR pcrvpr0.create_by_user_id = @iCreateByUserID) AND
		(@dtUpdateDateFrom IS NULL OR CONVERT(VARCHAR, pcrvpr0.update_date, 12) >= CONVERT(VARCHAR, @dtUpdateDateFrom, 12)) AND
		(@dtUpdateDateTo IS NULL OR CONVERT(VARCHAR, pcrvpr0.update_date, 12) <= CONVERT(VARCHAR, @dtUpdateDateTo, 12)) AND
		(@iUpdateByUserID IS NULL OR pcrvpr0.update_by_user_id = @iUpdateByUserID) AND
		(@sKeyWords IS NULL OR
		pcrvpr0.product_rating_to_with_exception LIKE '%' + @sKeyWords + '%' OR
		pcrvpr0.product_rating_to_with_no_exception LIKE '%' + @sKeyWords + '%')
		GROUP BY		
		pcrvpr0.psc_customer_rating_vs_product_rating_id,
		pcrvpr0.com_customer_risk_rating_id,
		pcrvpr0.product_rating_to_with_exception,
		pcrvpr0.product_rating_to_with_no_exception,
		pcrvpr0.is_active,
		pcrvpr0.create_date,
		pcrvpr0.create_by_user_id,
		pcrvpr0.update_date,
		pcrvpr0.update_by_user_id
		)
		SELECT		
		p.psc_customer_rating_vs_product_rating_id,
		p.com_customer_risk_rating_id,
		p.product_rating_to_with_exception,
		p.product_rating_to_with_no_exception,
		p.is_active,
		p.create_date,
		p.create_by_user_id,
		p.update_date,
		p.update_by_user_id
		FROM Paging p WHERE (@iPageSize IS NULL OR @iFirstRow IS NULL OR @iLastRow IS NULL) OR (p.row_number BETWEEN @iFirstRow AND @iLastRow)
END
