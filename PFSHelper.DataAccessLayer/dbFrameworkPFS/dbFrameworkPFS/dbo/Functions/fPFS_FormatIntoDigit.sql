/*****************************************************************************  
  Copyright (c) 2005, PT. Profescipta Wahanatehnik. All Rights Reserved.  
   
  This software, all associated documentation, and all copies  
  are CONFIDENTIAL INFORMATION of PT. Profescipta Wahanatehnik.  
   
   
  DESCRIPTION  
 Name     :   fPFS_FormatIntoDigit  
 Desc     : This function is used to format running number.  
 Input    :  @iNumberOfDigit, @sTextTobeFormatted  
 Output   : formatted running number  
 Comments :   
 Status   :    
 Sample Data : SELECT dbo.fPFS_FormatIntoDigit(5, '101')    --> result : 00101  
******************************************************************************/  
  
CREATE FUNCTION [dbo].[fPFS_FormatIntoDigit] (  
 @iNumberOfDigit INT,  
 @sTextTobeFormatted VARCHAR(10)  
)  
RETURNS VARCHAR(10)   
AS  
BEGIN  
 DECLARE @sFormattedText AS VARCHAR(10)  
 DECLARE @iCounter AS INT   
   
 SET @sFormattedText = @sTextTobeFormatted  
 SET @iCounter = 0  
 WHILE @iCounter < @iNumberOfDigit - LEN(@sTextTobeFormatted)  
 BEGIN  
  SET @sFormattedText = '0' + @sFormattedText  
  SET @iCounter = @iCounter + 1  
 END  
 RETURN @sFormattedText  
END
