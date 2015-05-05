/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayUpdate
	Desc    		:	This store procedure is use to update PFS_HOLIDAY
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayUpdate]
(
	@iHolidayID INT,
	@dtHolidayStartdate DATETIME,
	@dtHolidayEnddate DATETIME,
	@sHolidayDesc VARCHAR(1000),
	@sRecurrance VARCHAR(200),
	@iRecurranceParentID INT,
	@bIsNeedApproval BIT,
	@iCreateByUserID INT,
	@dtCreateDate DATETIME,
	@iUpdateByUserID INT,
	@dtUpdateDate DATETIME
)
AS
BEGIN

	UPDATE [PFS_HOLIDAY] SET
		pfs_holiday_startdate = @dtHolidayStartdate,
		pfs_holiday_enddate = @dtHolidayEnddate,
		pfs_holiday_desc = @sHolidayDesc,
		recurrance = @sRecurrance,
		recurrance_parent_id = @iRecurranceParentID,
		is_need_approval = @bIsNeedApproval,
		create_by_user_id = @iCreateByUserID,
		create_date = @dtCreateDate,
		update_by_user_id = @iUpdateByUserID,
		update_date = @dtUpdateDate
	WHERE
      	pfs_holiday_id = @iHolidayID
			
	SELECT @@ERROR		
END
