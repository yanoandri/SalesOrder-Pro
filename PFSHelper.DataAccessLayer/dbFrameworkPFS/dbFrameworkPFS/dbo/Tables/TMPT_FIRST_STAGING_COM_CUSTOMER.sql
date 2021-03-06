﻿CREATE TABLE [dbo].[TMPT_FIRST_STAGING_COM_CUSTOMER] (
    [TMPT_FIRST_STAGING_COM_CUSTOMER_ID] INT           IDENTITY (1, 1) NOT NULL,
    [PSC_FILE_IMPORT_ID]                 INT           NOT NULL,
    [CIF]                                VARCHAR (15)  NOT NULL,
    [CUSTOMER_DOB]                       VARCHAR (20)  NOT NULL,
    [BRANCH_CODE]                        VARCHAR (20)  NOT NULL,
    [BRANCH_NAME]                        VARCHAR (100) NOT NULL,
    [CONTROL_CENTER]                     VARCHAR (5)   NOT NULL,
    [EDUCATION_NAME]                     VARCHAR (50)  NOT NULL,
    [FULL_NAME]                          VARCHAR (255) NOT NULL,
    [IS_VALID]                           BIT           CONSTRAINT [DF_TMPT_FIRST_STAGING_COM_CUSTOMER_IS_VALID] DEFAULT ((1)) NOT NULL,
    [REMARK]                             VARCHAR (250) CONSTRAINT [DF_TMPT_FIRST_STAGING_COM_CUSTOMER_REMARK] DEFAULT ('-') NOT NULL,
    CONSTRAINT [PK_TMPT_FIRST_STAGING_COM_CUSTOMER] PRIMARY KEY CLUSTERED ([TMPT_FIRST_STAGING_COM_CUSTOMER_ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_TMPT_FIRST_STAGING_COM_CUSTOMER]
    ON [dbo].[TMPT_FIRST_STAGING_COM_CUSTOMER]([TMPT_FIRST_STAGING_COM_CUSTOMER_ID] ASC);

