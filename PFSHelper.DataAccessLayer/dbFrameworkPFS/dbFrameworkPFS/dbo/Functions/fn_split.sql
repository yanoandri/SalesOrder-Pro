/*****************************************************************************
  DESCRIPTION
	Name    	:   fn_split
	Desc    	:	This function is used to split string into table
	Input   	: 	@keyword, @delimiter
	Sample Data :	SELECT * FROM dbo.fn_split('AAABB+BBBCC+CCCDD+DDDEE','+')    
******************************************************************************/
CREATE FUNCTION [dbo].[fn_split] 
(
	@keyword VARCHAR(8000),
	@delimiter VARCHAR(255)
)
RETURNS @tblKey TABLE (keyword VARCHAR(8000))
AS
BEGIN
	DECLARE @word VARCHAR(255)

	WHILE (CHARINDEX(@delimiter, @keyword, 1) > 0)
	BEGIN
		SET @word = SUBSTRING(@keyword, 1, CHARINDEX(@delimiter, @keyword, 1) - 1)
		SET @keyword = SUBSTRING(@keyword, CHARINDEX(@delimiter, @keyword, 1) + 1, LEN(@keyword))
		INSERT INTO @tblKey VALUES(@word)
	END
	
	INSERT INTO @tblKey VALUES(@keyword)
	RETURN
END
