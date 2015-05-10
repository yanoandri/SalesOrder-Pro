﻿CREATE TABLE [dbo].[PSC_CUSTOMER_OBJECTIVE] (
    [PSC_CUSTOMER_OBJECTIVE_ID] BIGINT        IDENTITY (1, 1) NOT NULL,
    [CUSTOMER_OBJECTIVE_NAME]   VARCHAR (100) CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_CUSTOMER_OBJECTIVE_NAME] DEFAULT ('-') NOT NULL,
    [OBJECTIVE_CODE]            VARCHAR (3)   CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_OBJECTIVE_CODE] DEFAULT ('-') NOT NULL,
    [DESCRIPTION]               VARCHAR (255) CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_DESCRIPTION] DEFAULT ('-') NOT NULL,
    [IS_ACTIVE]                 BIT           CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_IS_ACTIVE] DEFAULT ((0)) NOT NULL,
    [IS_DELETED]                BIT           CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_IS_DELETED] DEFAULT ((0)) NOT NULL,
    [CREATE_DATE]               DATETIME      CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_CREATE_DATE] DEFAULT (((1900)-(1))-(1)) NOT NULL,
    [CREATE_BY_USER_ID]         INT           CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_CREATE_BY_USER_ID] DEFAULT ((0)) NOT NULL,
    [UPDATE_DATE]               DATETIME      CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_UPDATE_DATE] DEFAULT (((1900)-(1))-(1)) NOT NULL,
    [UPDATE_BY_USER_ID]         INT           CONSTRAINT [DF_PSC_CUSTOMER_OBJECTIVE_UPDATE_BY_USER_ID] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PSC_CUSTOMER_OBJECTIVE] PRIMARY KEY CLUSTERED ([PSC_CUSTOMER_OBJECTIVE_ID] ASC)
);
