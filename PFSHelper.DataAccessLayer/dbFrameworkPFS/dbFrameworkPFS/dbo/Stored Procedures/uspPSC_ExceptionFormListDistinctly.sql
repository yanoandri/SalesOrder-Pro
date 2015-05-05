
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
       Name                 :      uspPSC_ExceptionFormListDistinctly
       Desc                 :      This store procedure is use to get list of PSC_EXCEPTION_FORM distinctly
       Create Date			:      21 Jan 2015          - Created By  : mtoha
       Modified Date        :	   16 Fer 2015			- Modified By : mtoha
       Comments             :
       Sample Data			:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo]. [uspPSC_ExceptionFormListDistinctly]
(
        @sKeyWords VARCHAR (1280) = NULL,
        @sCif VARCHAR (200) = NULL,
        @iBranchID INT = NULL,
        @bIsActive BIT = NULL,
        @bIsDeleted BIT = NULL,
        @bIsNeedApproval BIT = NULL
)
AS
BEGIN
		SET NOCOUNT ON
        SELECT
               distinct
               pef0.com_branch_id ,
               pef0.branch_name ,
               pef0.cif ,
               ccust.FULL_NAME as CUSTOMER_FULL_NAME,
               pef0.is_active ,
               pef0.is_deleted ,
               pef0.is_need_approval
        FROM
               psc_exception_form pef0 WITH ( NOLOCK) 
               INNER JOIN com_branch cb1 WITH ( NOLOCK) ON pef0.COM_BRANCH_ID = cb1.COM_BRANCH_ID
               INNER JOIN com_asset_class cac2 WITH ( NOLOCK) ON pef0.COM_ASSET_CLASS_ID = cac2.COM_ASSET_CLASS_ID
               INNER JOIN com_product_rating cpr3 WITH ( NOLOCK) ON pef0.COM_PRODUCT_RATING_ID = cpr3.COM_PRODUCT_RATING_ID
			   INNER JOIN COM_CUSTOMER ccust WITH (NOLOCK) ON pef0.CIF = ccust.CIF
        WHERE
               pef0.com_branch_id = cb1.com_branch_id AND
               pef0.com_asset_class_id = cac2.com_asset_class_id AND
               pef0.com_product_rating_id = cpr3.com_product_rating_id AND
               (@iBranchID IS NULL OR pef0.com_branch_id = @iBranchID) AND
               (@bIsActive IS NULL OR pef0.is_active = @bIsActive) AND
               (@bIsDeleted IS NULL OR pef0.is_deleted = @bIsDeleted) AND
               (@bIsNeedApproval IS NULL OR pef0.is_need_approval = @bIsNeedApproval) AND
               (@sCif IS NULL OR pef0.CIF = @sCif) AND
               (@sKeyWords IS NULL OR
               pef0.branch_name LIKE '%' + @sKeyWords + '%' OR
               pef0.cif LIKE '%' + @sKeyWords + '%' OR
               pef0.customer_full_name LIKE '%' + @sKeyWords + '%' )
END
  
