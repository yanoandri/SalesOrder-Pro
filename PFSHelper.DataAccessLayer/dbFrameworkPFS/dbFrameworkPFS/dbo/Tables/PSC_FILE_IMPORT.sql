CREATE TABLE [dbo].[PSC_FILE_IMPORT] (
    [PSC_FILE_IMPORT_ID]             INT            IDENTITY (1, 1) NOT NULL,
    [PSC_PROCESS_STATUS_ID]          INT            NOT NULL,
    [PSC_FILE_TYPE_ID]               INT            NOT NULL,
    [REFERENCE_NUMBER]               VARCHAR (25)   CONSTRAINT [DF_PSC_FILE_IMPORT_REFERENCE_NUMBER] DEFAULT ('-') NOT NULL,
    [UPLOAD_DATE]                    DATETIME       NOT NULL,
    [UPLOAD_BY]                      INT            NOT NULL,
    [FILE_NAME]                      VARCHAR (50)   NOT NULL,
    [ARCHIVE_FILE_NAME]              VARCHAR (250)  NOT NULL,
    [ARCHIVE_FILE_PASSWORD]          VARCHAR (50)   NOT NULL,
    [ARCHIVE_INVALID_DATA_FILE_NAME] VARCHAR (500)  NOT NULL,
    [REMARK]                         VARCHAR (1000) NOT NULL,
    [TOTAL_INPUT_DATA]               INT            NOT NULL,
    [TOTAL_VALID_DATA]               INT            NOT NULL,
    [TOTAL_INVALID_DATA]             INT            NOT NULL,
    [IS_VALID]                       BIT            CONSTRAINT [DF_PSC_FILE_IMPORT_IS_VALID] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PSC_FILE_IMPORT] PRIMARY KEY CLUSTERED ([PSC_FILE_IMPORT_ID] ASC)
);

