/***************************************************************************************
Name		: uspGenerateText
Create Date	: ssaputra - 2014-02-23
Sample Data	: uspGenerateText spName
****************************************************************************************/
CREATE PROC uspGenerateText
(
	@p_sObjectName VARCHAR(255)
)
AS
BEGIN
	DECLARE @sResult NVARCHAR(MAX)
	DECLARE @iIndex INT, @iTotal INT
	
	SELECT 
		@iIndex = 1,
		@iTotal = COUNT(*) 
	FROM 
		[sys].[syscomments] AS s WITH(NOLOCK)
	WHERE
		[id] = OBJECT_ID(@p_sObjectName)

	WHILE @iIndex <= @iTotal
	BEGIN
		SELECT 
			@iIndex = @iIndex + 1, 
			@sResult = [text]
		FROM 
			[sys].[syscomments] AS s WITH(NOLOCK) 
		WHERE
			[id] = OBJECT_ID(@p_sObjectName) 
			AND [colid] = @iIndex

		PRINT @sResult
	END
END
