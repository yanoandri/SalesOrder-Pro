
/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPSC_ExceptionFormUpdateByApprovalStatus
	Desc    		:	This store procedure is use to update PFS_USER
	Create Date 	:	13 Oct 2011		- Created By  : PFS Generator v5.0
	Modified Date 	:	21 Jan 2015		- Modified By : mtoha
	Comments		:
	Sample Data 	: 
						uspPSC_ExceptionFormUpdateByApprovalStatus 52,0,'2011-10-29',52
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ExceptionFormUpdateByApprovalStatus]
(
	@iExceptionFormID INT,
	@bIsNeedApproval BIT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN

	IF(@bIsNeedApproval=1)
	BEGIN
		UPDATE [PSC_EXCEPTION_FORM] SET
			is_need_approval = @bIsNeedApproval
		WHERE
      		PSC_EXCEPTION_FORM_ID = @iExceptionFormID
	END
	ELSE
	BEGIN
		UPDATE [PSC_EXCEPTION_FORM] SET
			is_need_approval = @bIsNeedApproval,
			update_date = @dtUpdateDate,
			update_by_user_id = @iUpdateByUserID
		WHERE
      		PSC_EXCEPTION_FORM_ID = @iExceptionFormID
	END
	select @@ERROR
			
END
