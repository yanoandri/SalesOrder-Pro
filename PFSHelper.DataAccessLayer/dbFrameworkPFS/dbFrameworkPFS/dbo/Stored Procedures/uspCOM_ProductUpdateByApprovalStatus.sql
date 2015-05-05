
/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductUpdateByApprovalStatus
	Desc    		:	This store procedure is use to update COM_PRODUCT
	Create Date 	:	20 Jan 2015		- Created By  : mtoha
	Modified Date 	:					- Modified By : mtoha
	Comments		:
	Sample Data 	: 
						[uspCOM_ProductUpdateByApprovalStatus]
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ProductUpdateByApprovalStatus]
(
	@iProductID INT,
	@bIsNeedApproval BIT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN

	IF(@bIsNeedApproval=1)
	BEGIN
		UPDATE [COM_PRODUCT] SET
			is_need_approval = @bIsNeedApproval
		WHERE
      		COM_PRODUCT_ID = @iProductID
	END
	ELSE
	BEGIN
		UPDATE [COM_PRODUCT] SET
			is_need_approval = @bIsNeedApproval,
			update_date = @dtUpdateDate,
			update_by_user_id = @iUpdateByUserID
		WHERE
      		COM_PRODUCT_ID = @iProductID
	END
	select @@ERROR
			
END
