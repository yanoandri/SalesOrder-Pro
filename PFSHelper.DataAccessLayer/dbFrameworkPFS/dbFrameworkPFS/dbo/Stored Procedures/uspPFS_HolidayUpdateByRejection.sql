/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPFS_HolidayUpdateByRejection]
	Desc    		:	This store procedure is use to update PFS_HOLIDAY
	Create Date 	:	03 Oct 2013		- Created By  : slimanto
	Modified Date 	:	03 Oct 2013		- Modified By : slimanto
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayUpdateByRejection]
(
	@iHolidayID INT
)
AS
BEGIN

	BEGIN  
	
		UPDATE dbo.PFS_HOLIDAY SET
			is_need_approval = 0
		WHERE  
			pfs_holiday_id = @iHolidayID 
			 
	END  
	 
	select @@ERROR  
 	
END
