
/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ProductUpdateByRejection
	Desc    		:	This store procedure is use to update COM_PRODUCT
	Create Date 	:	20 Jan 2015		- Created By  : mtoha
	Modified Date 	:					- Modified By : mtoha
	Comments		:
	Sample Data 	: 
						uspPFS_UserUpdateForNeedApproval 52,0,'2011-10-29',52
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ProductUpdateByRejection]
(
	@iProductID INT
)
AS
BEGIN

	UPDATE [COM_PRODUCT] SET
		is_need_approval = 0
	WHERE
  		COM_PRODUCT_ID = @iProductID
	
	select @@ERROR
			
END
