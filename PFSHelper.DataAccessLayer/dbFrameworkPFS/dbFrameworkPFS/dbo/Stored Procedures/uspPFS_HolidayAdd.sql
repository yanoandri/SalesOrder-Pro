/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayAdd
	Desc    		:	This store procedure is use to add PFS_HOLIDAY
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayAdd]
(
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

	DECLARE @iHolidayID INT
	INSERT INTO [PFS_HOLIDAY] 
    ( 	
		pfs_holiday_startdate,
		pfs_holiday_enddate,
		pfs_holiday_desc,
		recurrance,
		recurrance_parent_id,
		is_need_approval,
		create_by_user_id,
		create_date,
		update_by_user_id,
		update_date
	)
	VALUES
	(
		@dtHolidayStartdate,
		@dtHolidayEnddate,
		@sHolidayDesc,
		@sRecurrance,
		@iRecurranceParentID,
		@bIsNeedApproval,
		@iCreateByUserID,
		@dtCreateDate,
		@iUpdateByUserID,
		@dtUpdateDate
	)
	
	SET  @iHolidayID = ISNULL(@@IDENTITY, 0)
	SELECT @iHolidayID
	
END
