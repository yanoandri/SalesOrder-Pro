
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_EducationList
	Desc    		:	This store procedure is use to get list of COM_EDUCATION
	Create Date 	:	12 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_EducationList
(
	@sKeyWords VARCHAR(1280) = NULL
	,@iPageSize INT = 10
    ,@iPageNumber INT = 1 
)
AS
BEGIN
	DECLARE @iFirstRow INT, @iLastRow INT
    SET @iFirstRow = NULL
    SET @iLastRow= NULL
	
	SELECT
		@iFirstRow = ( @iPageNumber - 1) * @iPageSize + 1,
        @iLastRow = (@iPageNumber - 1) * @iPageSize + @iPageSize;
    
	WITH Paging AS (
		SELECT
		ROW_NUMBER() OVER (ORDER BY ce0.com_education_id ASC) AS row_number,
			ce0.com_education_id,
		ce0.education_name,
		ce0.description
	FROM
		com_education ce0 WITH (NOLOCK)
	WHERE
		(@sKeyWords IS NULL OR
		ce0.education_name LIKE '%' + @sKeyWords + '%' OR
		ce0.description LIKE '%' + @sKeyWords + '%')
		GROUP BY		
		ce0.com_education_id,
		ce0.education_name,
		ce0.description
		)
		SELECT		
		p.com_education_id,
		p.education_name,
		p.description
		FROM Paging p WHERE (@iPageSize IS NULL OR @iFirstRow IS NULL OR @iLastRow IS NULL) OR (p.row_number BETWEEN @iFirstRow AND @iLastRow)
END
