CREATE  FUNCTION  [dbo].[ReplaceNumericLoop] 
(
	@str VARCHAR(50)
)
	RETURNS  VARCHAR(50)  
AS
BEGIN

	--WHILE  PATINDEX(  '%[^A-Z,x ]%',  @str )  >  0 
	--SET  @str =  REPLACE(  @str,  SUBSTRING(  @str,PATINDEX(  '%[^A-Z,x ]%',  @str ),  1 ),  'X'  ) 
	 
	WHILE  PATINDEX(  '%[^A-Z]%',  @str )  >  0 
	SET  @str =  LTRIM(RTRIM(REPLACE(  @str,  SUBSTRING(  @str,PATINDEX(  '%[^A-Z]%',  @str ),  1 ),  'X'  )))  
	
	WHILE  PATINDEX(  '%X%',  @str )  >  0 
	SET  @str =  REPLACE(  @str,  SUBSTRING(  @str,PATINDEX(  '%X%',  @str ),  1 ),  '0'  )  
	
	IF  PATINDEX(  '%[A-Z]%',  @str )  >  0 
		SET  @str =  REPLACE(@str,(SUBSTRING(  @str, 1, (PATINDEX(  '%[A-Z]%',  @str )-1))),'0')
	
	ELSE IF  PATINDEX(  '%[^A-Z]%',  @str )  >  0 
		SET  @str =  REPLACE(@str,@str,'0')

	RETURN  @str

END
