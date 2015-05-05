/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspPFS_HolidayCheck
	Desc    		:	This store procedure is use to get COM_HOLIDAY by id
	Create Date 	:	20 Dec 2011		- Created By  : kprasetyo
	Modified Date 	:	23 Dec 2011		- Modified By : kprasetyo
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPFS_HolidayCheck]

AS
BEGIN

		SELECT
			ph0.pfs_holiday_id,
			ph0.pfs_holiday_startdate,
			ph0.pfs_holiday_enddate,
			ph0.pfs_holiday_desc,
			ph0.recurrance,
			ph0.recurrance_parent_id
		FROM
			pfs_holiday ph0 WITH (NOLOCK)
		WHERE 
			(
				(
					GETDATE()
					BETWEEN 
						CAST(CAST(DATEPART(yy,GETDATE()) AS VARCHAR(4)) + RIGHT(CONVERT(VARCHAR(10), pfs_holiday_startdate,120),6) AS DATETIME)
					AND
						CAST(CAST(DATEPART(yy,GETDATE()) AS VARCHAR(4)) + RIGHT(CONVERT(VARCHAR(10), ph0.pfs_holiday_enddate,120),6) AS DATETIME)
					
				) AND
				ph0.recurrance_parent_id IS NULL
			) OR
			(
				(
					GETDATE() 
					BETWEEN ph0.pfs_holiday_startdate AND ph0.pfs_holiday_enddate
					
				) AND
				ph0.recurrance_parent_id IS NOT NULL
			)
		
		
END
