﻿CREATE TABLE [dbo].[TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION] (
    [TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_ID] INT           IDENTITY (1, 1) NOT NULL,
    [PSC_FILE_IMPORT_ID]                          INT           NOT NULL,
    [DATE]                                        VARCHAR (25)  CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_DATE] DEFAULT ('1900-01-01') NOT NULL,
    [BRANCH_CODE]                                 VARCHAR (10)  CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_BRANCH_CODE] DEFAULT ('-') NOT NULL,
    [BRANCH_NAME]                                 VARCHAR (100) CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_BRANCH_NAME] DEFAULT ('-') NOT NULL,
    [CIF]                                         VARCHAR (15)  CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_CIF] DEFAULT ('-') NOT NULL,
    [CUSTOMER_NAME]                               VARCHAR (255) CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_CUSTOMER_NAME] DEFAULT ('-') NOT NULL,
    [PROUCT_CODE]                                 VARCHAR (15)  CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_PROUCT_CODE] DEFAULT ('-') NOT NULL,
    [PRODUCT_NAME]                                VARCHAR (500) CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_PRODUCT_NAME] DEFAULT ('-') NOT NULL,
    [ASSET_CLASS_NAME]                            VARCHAR (100) CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_ASSET_CLASS_NAME] DEFAULT ('-') NOT NULL,
    [CURRENCY_CODE]                               VARCHAR (3)   CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_CURRENCY_CODE] DEFAULT ('-') NOT NULL,
    [AMOUNT]                                      VARCHAR (100) CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_AMOUNT] DEFAULT ('-') NOT NULL,
    [RM_NAME]                                     VARCHAR (255) CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_RM_NAME] DEFAULT ('-') NOT NULL,
    [IS_VALID]                                    BIT           CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_IS_VALID] DEFAULT ((1)) NOT NULL,
    [REMARK]                                      VARCHAR (250) CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_REMARK] DEFAULT ('-') NULL,
    CONSTRAINT [PK_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION] PRIMARY KEY CLUSTERED ([TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_ID] ASC),
    CONSTRAINT [FK_TMPT_FIRST_STAGING_PSC_JATIS_TRANSACTION_PSC_FILE_IMPORT] FOREIGN KEY ([PSC_FILE_IMPORT_ID]) REFERENCES [dbo].[PSC_FILE_IMPORT] ([PSC_FILE_IMPORT_ID])
);

