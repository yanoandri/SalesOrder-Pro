/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_HolidayUpdateByApprovalStatus]
	Desc    		:	This store procedure is use to update PFS_HOLIDAY
	Create Date 	:	03 Oct 2012		- Created By  : slimanto
	Modified Date 	:	03 Oct 2012		- Modified By : slimanto
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayUpdateByApprovalStatus]
(
	@iHolidayID INT,
	@bIsNeedApproval BIT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN

	IF(@bIsNeedApproval=1)  
		BEGIN  
		
			UPDATE dbo.PFS_HOLIDAY SET
				is_need_approval = @bIsNeedApproval  
			WHERE  
				pfs_holiday_id = @iHolidayID 
				 
		END  
	ELSE  
		BEGIN  
			
			UPDATE dbo.PFS_HOLIDAY SET  
				is_need_approval = @bIsNeedApproval,  
				update_date = @dtUpdateDate,  
				update_by_user_id = @iUpdateByUserID  
			WHERE  
				pfs_holiday_id = @iHolidayID 
		END  
 
	select @@ERROR  
 	
END
