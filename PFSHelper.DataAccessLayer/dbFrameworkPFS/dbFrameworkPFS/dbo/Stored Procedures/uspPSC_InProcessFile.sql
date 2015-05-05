--select *from psc_process_status

/***********************************************************************************************************************
   Copyright (c) 2014 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspOTSC_InProcessFile
	Desc    		:	This store procedure is use to get Status Process 
	Create Date 	:	24 Oct 2014		- Created By  : sbakhri
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_InProcessFile]
AS
BEGIN
	SELECT
	 TOP 1 pfi0.psc_process_status_id
	FROM
		psc_file_import pfi0 WITH (NOLOCK)
	WHERE
		pfi0.psc_process_status_id NOT IN(1,11,12)
		
	/*
	0 Not Process
	10 Finished
	12 Failed

	*/
END

