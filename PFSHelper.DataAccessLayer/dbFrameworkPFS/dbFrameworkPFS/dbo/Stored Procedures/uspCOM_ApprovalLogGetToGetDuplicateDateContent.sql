/***********************************************************************************************************************
   Copyright (c) 2013 PT Profescipta Wahanatehnik. All Rights Reserved.
   This software, all associated documentation, and all copies
   DESCRIPTION
	Name    		:	uspCOM_ApprovalLogGetToGetDuplicateDateContent
	Desc    		:	This store procedure is use to get COM_APPROVAL_LOG 
	Create Date 	:	29 Nov 2013		- Created By  : slimanto
	Modified Date 	:	            	- Modified By :
	Comments		:
	Sample Data 	:
***********************************************************************************************************************/
CREATE PROCEDURE [dbo].[uspCOM_ApprovalLogGetToGetDuplicateDateContent]
(
	@sObjectParent varchar(max),
	@sObjectChildStartDate varchar(max),
	@sObjectChildEndDate varchar(max),
	@sObjectComparer varchar(max),
	@iModuleObjectMemberID INT,
	@iApprovalLogID INT = null
)
AS
declare @XML xml
declare @sNodeStartDate varchar(max)
declare @sNodeEndDate varchar(max)
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
		---------------------------- Get Start Date and End Date from each XML ---------------------------------------------
		SELECT
			@sNodeStartDate = (XMLNode.value('(*[local-name()=sql:variable("@sObjectChildStartDate")])[1]','varchar(max)')),
			@sNodeEndDate = (XMLNode.value('(*[local-name()=sql:variable("@sObjectChildEndDate")])[1]','varchar(max)'))
		FROM
			@XML.nodes('*[local-name()=sql:variable("@sObjectParent")]') AS XTbl(XMLNode)
		--------------------------------------------------------------------------------------------------------------------

		------------------------- Comparing the object between start date and end date -----------------------------
		if(CONVERT(DATE, @sObjectComparer) BETWEEN CONVERT(DATE, @sNodeStartDate) AND CONVERT(DATE, @sNodeEndDate)) 
		begin
			set @bExist = 1
			break
		end
		------------------------------------------------------------------------------------------------------------

		FETCH NEXT FROM MY_CURSOR INTO @XML
	END
	CLOSE MY_CURSOR
	DEALLOCATE MY_CURSOR

	select @bExist

END
