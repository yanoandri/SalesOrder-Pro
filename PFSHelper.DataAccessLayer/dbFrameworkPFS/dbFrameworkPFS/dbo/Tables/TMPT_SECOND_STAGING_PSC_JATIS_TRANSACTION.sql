CREATE TABLE [dbo].[TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION] (
    [TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION_ID] INT           IDENTITY (1, 1) NOT NULL,
    [PSC_FILE_IMPORT_ID]                           INT           NOT NULL,
    [DATE]                                         VARCHAR (50)  NOT NULL,
    [BRANCH_ID]                                    INT           NOT NULL,
    [BRANCH_CODE]                                  VARCHAR (20)  NOT NULL,
    [BRANCH_NAME]                                  VARCHAR (250) NOT NULL,
    [COM_CUSTOMER_ID]                              INT           NOT NULL,
    [CIF]                                          VARCHAR (15)  NOT NULL,
    [CUSTOMER_NAME]                                VARCHAR (255) NOT NULL,
    [PRODUCT_ID]                                   INT           NOT NULL,
    [PRODUCT_CODE]                                 VARCHAR (20)  NOT NULL,
    [PRODUCT_NAME]                                 VARCHAR (250) NOT NULL,
    [ASSET_CLASS_ID]                               INT           CONSTRAINT [DF_TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION_ASSET_CLASS_ID] DEFAULT ((0)) NOT NULL,
    [COM_CURRENCY_ID]                              INT           NOT NULL,
    [AMOUNT]                                       FLOAT (53)    NOT NULL,
    [COM_RM_ID]                                    INT           NOT NULL,
    [PSC_RMW_CIP_ID]                               INT           CONSTRAINT [DF_TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION_PSC_RMW_CIP_ID] DEFAULT ((0)) NOT NULL,
    [IS_VALID]                                     BIT           CONSTRAINT [DF_TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION_IS_VALID] DEFAULT ((0)) NOT NULL,
    [INVALID_REMARK]                               VARCHAR (500) CONSTRAINT [DF_TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION_INVALID_REMARK] DEFAULT ('-') NOT NULL,
    CONSTRAINT [PK_TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION] PRIMARY KEY CLUSTERED ([TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION_ID] ASC),
    CONSTRAINT [FK_TMPT_SECOND_STAGING_PSC_JATIS_TRANSACTION_PSC_FILE_IMPORT] FOREIGN KEY ([PSC_FILE_IMPORT_ID]) REFERENCES [dbo].[PSC_FILE_IMPORT] ([PSC_FILE_IMPORT_ID])
);

