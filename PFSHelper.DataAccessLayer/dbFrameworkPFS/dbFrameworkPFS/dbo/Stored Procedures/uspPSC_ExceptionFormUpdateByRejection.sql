
/***********************************************************************************************************************
   Copyright (c) 2011 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	[uspPSC_ExceptionFormUpdateByRejection]
	Desc    		:	This store procedure is use to update PFS_USER
	Create Date 	:	02 Nov 2011		- Created By  : kprasetyo
	Modified Date 	:	02 Nov 2011		- Modified By : mtoha
	Comments		:
	Sample Data 	: 
						uspPSC_ExceptionFormUpdateByRejection 52,0,'2011-10-29',52
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspPSC_ExceptionFormUpdateByRejection]
(
	@iExceptionFormID INT
)
AS
BEGIN

	UPDATE [PSC_EXCEPTION_FORM] SET
		is_need_approval = 0
	WHERE
  		PSC_EXCEPTION_FORM_ID = @iExceptionFormID 
	
	select @@ERROR
			
END
