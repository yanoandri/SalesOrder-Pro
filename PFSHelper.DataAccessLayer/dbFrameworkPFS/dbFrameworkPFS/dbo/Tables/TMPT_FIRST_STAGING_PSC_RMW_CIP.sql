﻿CREATE TABLE [dbo].[TMPT_FIRST_STAGING_PSC_RMW_CIP] (
    [TMPT_FIRST_STAGING_PSC_RMW_CIP_ID] INT           IDENTITY (1, 1) NOT NULL,
    [PSC_FILE_IMPORT_ID]                INT           NOT NULL,
    [CIF]                               VARCHAR (15)  NOT NULL,
    [CUSTOMER_ID]                       VARCHAR (25)  NOT NULL,
    [CUSTOMER_DOB]                      VARCHAR (30)  NOT NULL,
    [BRANCH_CODE]                       VARCHAR (25)  NOT NULL,
    [BRANCH_NAME]                       VARCHAR (100) NOT NULL,
    [CUSTOMER_SEGMENT_NAME]             VARCHAR (10)  NOT NULL,
    [CUSTOMER_RISK_RATING_SCORE]        VARCHAR (5)   NOT NULL,
    [EDUCATION_NAME]                    VARCHAR (100) NOT NULL,
    [RM_CODE]                           VARCHAR (10)  NOT NULL,
    [RM_NAME]                           VARCHAR (255) NOT NULL,
    [P1_Q1]                             VARCHAR (2)   NOT NULL,
    [P1_Q2]                             VARCHAR (2)   NOT NULL,
    [P1_Q3]                             VARCHAR (2)   NOT NULL,
    [P1_Q4]                             VARCHAR (2)   NOT NULL,
    [P1_Q5]                             VARCHAR (2)   NOT NULL,
    [P1_Q6]                             VARCHAR (2)   NOT NULL,
    [P1_Q7]                             VARCHAR (2)   NOT NULL,
    [Q1_EM]                             VARCHAR (3)   NOT NULL,
    [Q2_TOTAL_ASSET]                    VARCHAR (50)  NOT NULL,
    [Q2_TOTAL_LIABILITIES]              VARCHAR (50)  NOT NULL,
    [Q3_1]                              VARCHAR (3)   NOT NULL,
    [Q3_2]                              VARCHAR (3)   NOT NULL,
    [Q3_3]                              VARCHAR (3)   NOT NULL,
    [Q3_4]                              VARCHAR (3)   NOT NULL,
    [Q3_5]                              VARCHAR (3)   NOT NULL,
    [Q3_6]                              VARCHAR (3)   NOT NULL,
    [Q3_7]                              VARCHAR (3)   NOT NULL,
    [Q3_8]                              VARCHAR (3)   NOT NULL,
    [Q3_9]                              VARCHAR (3)   NOT NULL,
    [Q3_10]                             VARCHAR (3)   NOT NULL,
    [Q3_11]                             VARCHAR (3)   NOT NULL,
    [Q3_12]                             VARCHAR (3)   NOT NULL,
    [Q3_13]                             VARCHAR (3)   NOT NULL,
    [Q4_1]                              VARCHAR (3)   NOT NULL,
    [Q4_2]                              VARCHAR (3)   NOT NULL,
    [Q4_3]                              VARCHAR (3)   NOT NULL,
    [Q4_4]                              VARCHAR (3)   NOT NULL,
    [Q4_5]                              VARCHAR (3)   NOT NULL,
    [Q4_6]                              VARCHAR (3)   NOT NULL,
    [Q5_ITH]                            VARCHAR (30)  NOT NULL,
    [Q6_1]                              VARCHAR (3)   NOT NULL,
    [Q6_2]                              VARCHAR (3)   NOT NULL,
    [Q6_3]                              VARCHAR (3)   NOT NULL,
    [Q6_4]                              VARCHAR (3)   NOT NULL,
    [Q6_5]                              VARCHAR (3)   NOT NULL,
    [Q6_6]                              VARCHAR (3)   NOT NULL,
    [CREATE_DATE]                       VARCHAR (70)  NOT NULL,
    [IS_VALID]                          BIT           CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_RMW_CIP_IS_VALID] DEFAULT ((1)) NOT NULL,
    [REMARK]                            VARCHAR (250) CONSTRAINT [DF_TMPT_FIRST_STAGING_PSC_RMW_CIP_REMARK] DEFAULT ('-') NOT NULL,
    CONSTRAINT [PK_TMPT_FIRST_STAGING_PSC_RMW_CIP] PRIMARY KEY CLUSTERED ([TMPT_FIRST_STAGING_PSC_RMW_CIP_ID] ASC),
    CONSTRAINT [FK_TMPT_FIRST_STAGING_PSC_RMW_CIP_PSC_FILE_IMPORT] FOREIGN KEY ([PSC_FILE_IMPORT_ID]) REFERENCES [dbo].[PSC_FILE_IMPORT] ([PSC_FILE_IMPORT_ID])
);

