/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogListToGetDuplicateContent
	Desc    		:	This store procedure is use to get COM_APPROVAL_LOG 
	Create Date 	:	29 Nov 2013		- Created By  : slimanto
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogGetToGetDuplicateContent]
(
	@sObjectParent varchar(max),
	@sObjectChild varchar(max),
	@sObjectComparer varchar(max),
	@iModuleObjectMemberID INT,
	@iApprovalLogID INT = null
)
AS
declare @XML xml
declare @sNodeValue varchar(max)
declare @bExist bit
set @bExist = 0

BEGIN
	DECLARE MY_CURSOR CURSOR 
	  LOCAL STATIC READ_ONLY FORWARD_ONLY
	FOR 

	select detail from COM_APPROVAL_LOG
	where COM_APPROVAL_STATUS_ID = 2 -- 2 = Pending
	and PFS_MODULE_OBJECT_MEMBER_ID = @iModuleObjectMemberID
	and (@iApprovalLogID is null or com_approval_log_id <> @iApprovalLogID)

	OPEN MY_CURSOR
	FETCH NEXT FROM MY_CURSOR INTO @XML
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		-------------------------------- Get the value of the child object from each XML ----------------------
		SELECT
			@sNodeValue = (XMLNode.value('(*[local-name()=sql:variable("@sObjectChild")])[1]','varchar(max)'))
		FROM
			@XML.nodes('*[local-name()=sql:variable("@sObjectParent")]') AS XTbl(XMLNode)
		--------------------------------------------------------------------------------------------------------

		-- Comparing the object to the value --
		if(@sNodeValue = @sObjectComparer)
		begin
			set @bExist = 1
			break
		end
		---------------------------------------

		FETCH NEXT FROM MY_CURSOR INTO @XML
	END
	CLOSE MY_CURSOR
	DEALLOCATE MY_CURSOR

	select @bExist

END
