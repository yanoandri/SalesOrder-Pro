/***********************************************************************************************************************
   Copyright (c) 2012 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayDelete
	Desc    		:	This store procedure is use to delete PFS_HOLIDAY
	Create Date 	:	02 Jan 2012		- Created By  : PFS Generator v5.0
	Modified Date 	:	02 Jan 2012		- Modified By : PFS Generator v5.0
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayDelete]
(
	@iHolidayID INT
)
AS
BEGIN

	DELETE [PFS_HOLIDAY] 
    WHERE
      [PFS_HOLIDAY_ID] = @iHolidayID	
	
END
