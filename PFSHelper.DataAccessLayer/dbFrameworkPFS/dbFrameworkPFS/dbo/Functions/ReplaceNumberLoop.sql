CREATE  FUNCTION  [dbo].[ReplaceNumberLoop] 
(
	@sString VARCHAR(50),
	@iIndex INT
)
	RETURNS  VARCHAR(50)  
AS
BEGIN

	WHILE  PATINDEX(  '%[1-9]%',  @sString )  >  0 
	SET @sString =  REPLACE(RIGHT(@sString,@iIndex),  SUBSTRING(RIGHT(@sString,@iIndex), PATINDEX('%[1-9]%',RIGHT(@sString,@iIndex) ),  1 ),  '0'  )  


	RETURN  @sString

END
