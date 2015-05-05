/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CurrencyAdd
	Desc    		:	This store procedure is use to add COM_CURRENCY
	Create Date 	:	14 Jan 2015		- Created By  : PFS Generator v5.1
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE dbo.uspCOM_CurrencyAdd
(
	@sCurrencyCode VARCHAR(3),
	@sDescription VARCHAR(4),
	@bIsActive BIT,
	@bIsDeleted BIT,
	@dtCreateDate DATETIME,
	@iCreateByUserID INT,
	@dtUpdateDate DATETIME,
	@iUpdateByUserID INT
)
AS
BEGIN
	DECLARE @lCurrencyID INT
    
	INSERT INTO COM_CURRENCY 
    ( 	
		currency_code,
		description,
		is_active,
		is_deleted,
		create_date,
		create_by_user_id,
		update_date,
		update_by_user_id
	)
	VALUES
	(
		@sCurrencyCode,
		@sDescription,
		@bIsActive,
		@bIsDeleted,
		@dtCreateDate,
		@iCreateByUserID,
		@dtUpdateDate,
		@iUpdateByUserID
	)
    
	SET @lCurrencyID = ISNULL(@@IDENTITY, 0)
	SELECT @lCurrencyID
END
