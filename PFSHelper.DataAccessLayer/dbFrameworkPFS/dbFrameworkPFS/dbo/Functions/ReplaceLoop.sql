CREATE  FUNCTION  [dbo].[ReplaceLoop] 
(
	@str VARCHAR(50)
)
	RETURNS  VARCHAR(50)  
	
AS
BEGIN

	WHILE  PATINDEX(  '%[^x ]%',  @str )  >  0 
		SET  @str =  REPLACE(  @str,  SUBSTRING(  @str,PATINDEX(  '%[^x ]%',  @str ),  1 ),  'X'  )  
	
	RETURN  @str

END
