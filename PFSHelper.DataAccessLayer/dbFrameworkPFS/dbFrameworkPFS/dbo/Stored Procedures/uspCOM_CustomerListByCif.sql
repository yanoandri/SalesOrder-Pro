
/***********************************************************************************************************************
   Copyright (c) 2015 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_CustomerList
	Desc    		:	This store procedure is use to get list of COM_CUSTOMER By CIF
	Create Date 	:	27 Jan 2015		- Created By  : akusnadi
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	: exec uspCOM_CustomerListByCif
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_CustomerListByCif]
(
	@sCif varchar(200) = NULL,
	@sName varchar(200) = NULL
)
AS
BEGIN
	SELECT
		cc0.com_customer_id,
		cc0.cif,
		cc0.full_name,
		cc0.com_branch_id,
		cb3.branch_name
	FROM
		com_customer cc0 WITH (NOLOCK),
		com_branch cb3 WITH (NOLOCK)
	WHERE
		cc0.com_branch_id = cb3.com_branch_id AND
		(@sCif IS NULL OR cc0.CIF LIKE @sCif + '%') AND
		(@sName IS NULL OR cc0.FULL_NAME LIKE @sName + '%') 
END
