/*****************************************************************************  
  Copyright (c) 2005, PT. Profescipta Wahanatehnik. All Rights Reserved.  
   
  This software, all associated documentation, and all copies  
  are CONFIDENTIAL INFORMATION of PT. Profescipta Wahanatehnik.  
   
   
  DESCRIPTION  
 Name     :   fPFS_IncreaseAlphabethCounter  
 Desc     : This function is used to increase alphabeth running number.  
 Input    :  @sLastedCharacter  
 Output   : increased alphabeth running number  
 Comments :   
 Status   :    
 Sample Data : SELECT dbo.fPFS_IncreaseAlphabethCounter('ABCZ')    
     SELECT dbo.fPFS_IncreaseAlphabethCounter('ZZZY')    
     SELECT dbo.fPFS_IncreaseAlphabethCounter('ZZZZ')    
     SELECT dbo.fPFS_IncreaseAlphabethCounter('AZAA')    
     SELECT dbo.fPFS_IncreaseAlphabethCounter('XYZZ')    
******************************************************************************/  
  
CREATE FUNCTION [dbo].[fPFS_IncreaseAlphabethCounter] (  
 @sLastedCharacter VARCHAR(5)  
)  
RETURNS VARCHAR(10)   
AS  
BEGIN  
 DECLARE @iLength AS INT  
 SET @iLength = LEN(@sLastedCharacter)  
  
 DECLARE @bIsLoop BIT, @iPosition AS INT, @sCurChar AS VARCHAR(1)  
 SET @bIsLoop = 1  
 SET @iPosition = @iLength  
 WHILE @bIsLoop = 1 AND @iPosition > 0  
 BEGIN  
  SET @sCurChar = SUBSTRING(@sLastedCharacter, @iPosition, 1)  
  IF ASCII(@sCurChar) < 90  
  BEGIN  
   SET @sLastedCharacter = STUFF(@sLastedCharacter, @iPosition, 1, CHAR(ASCII(@sCurChar) + 1))  
   SET @bIsLoop = 0  
  END  
  ELSE  
   SET @iPosition = @iPosition - 1  
 END  
  
 WHILE @iPosition < @iLength  
 BEGIN  
  SET @iPosition = @iPosition + 1  
  SET @sLastedCharacter = STUFF(@sLastedCharacter, @iPosition, 1, 'A')  
 END  
  
 RETURN @sLastedCharacter  
END
