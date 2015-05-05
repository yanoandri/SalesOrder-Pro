﻿CREATE TABLE [dbo].[COM_PRODUCT] (
    [COM_PRODUCT_ID]             INT           IDENTITY (1, 1) NOT NULL,
    [PRODUCT_NAME]               VARCHAR (500) CONSTRAINT [DF_COM_PRODUCT_PRODUCT_NAME] DEFAULT ('-') NOT NULL,
    [PRODUCT_CODE]               VARCHAR (15)  CONSTRAINT [DF_COM_PRODUCT_PRODUCT_CODE] DEFAULT ('-') NULL,
    [COM_PRODUCT_RATING_ID]      INT           CONSTRAINT [DF_COM_PRODUCT_COM_PRODUCT_RATING_ID] DEFAULT ((0)) NOT NULL,
    [PSC_CUSTOMER_OBJECTIVE1_ID] INT           CONSTRAINT [DF_COM_PRODUCT_PSC_CUSTOMER_OBJECTIVE1_ID] DEFAULT ((0)) NOT NULL,
    [PSC_CUSTOMER_OBJECTIVE2_ID] INT           CONSTRAINT [DF_COM_PRODUCT_PSC_CUSTOMER_OBJECTIVE2_ID] DEFAULT ((0)) NOT NULL,
    [PSC_CUSTOMER_OBJECTIVE3_ID] INT           CONSTRAINT [DF_COM_PRODUCT_PSC_CUSTOMER_OBJECTIVE3_ID] DEFAULT ((0)) NOT NULL,
    [PSC_CUSTOMER_OBJECTIVE4_ID] INT           CONSTRAINT [DF_COM_PRODUCT_PSC_CUSTOMER_OBJECTIVE4_ID] DEFAULT ((0)) NOT NULL,
    [PSC_CUSTOMER_OBJECTIVE5_ID] INT           CONSTRAINT [DF_COM_PRODUCT_PSC_CUSTOMER_OBJECTIVE5_ID] DEFAULT ((0)) NOT NULL,
    [PSC_CUSTOMER_OBJECTIVE6_ID] INT           CONSTRAINT [DF_COM_PRODUCT_PSC_CUSTOMER_OBJECTIVE6_ID] DEFAULT ((0)) NOT NULL,
    [COM_ASSET_CLASS_ID]         INT           CONSTRAINT [DF_COM_PRODUCT_COM_ASSET_CLASS_ID] DEFAULT ((0)) NOT NULL,
    [ITH_FROM]                   VARCHAR (3)   CONSTRAINT [DF_COM_PRODUCT_ITH_FROM] DEFAULT ('-') NOT NULL,
    [ITH_TO]                     VARCHAR (3)   CONSTRAINT [DF_COM_PRODUCT_ITH_TO] DEFAULT ('-') NOT NULL,
    [IS_ACTIVE]                  BIT           CONSTRAINT [DF_COM_PRODUCT_IS_ACTIVE] DEFAULT ((0)) NOT NULL,
    [IS_DELETED]                 BIT           CONSTRAINT [DF_COM_PRODUCT_IS_DELETED] DEFAULT ((0)) NOT NULL,
    [IS_NEED_APPROVAL]           BIT           CONSTRAINT [DF_COM_PRODUCT_IS_NEED_APPROVAL] DEFAULT ((0)) NOT NULL,
    [CREATE_DATE]                DATETIME      CONSTRAINT [DF_COM_PRODUCT_CREATE_DATE] DEFAULT (((1900)-(1))-(1)) NOT NULL,
    [CREATE_BY_USER_ID]          INT           CONSTRAINT [DF_COM_PRODUCT_CREATE_BY_USER_ID] DEFAULT ((0)) NOT NULL,
    [UPDATE_DATE]                DATETIME      CONSTRAINT [DF_COM_PRODUCT_UPDATE_DATE] DEFAULT (((1900)-(1))-(1)) NOT NULL,
    [UPDATE_BY_USER_ID]          INT           CONSTRAINT [DF_COM_PRODUCT_UPDATE_BY_USER_ID] DEFAULT ((0)) NOT NULL,
    [FUND_HOUSE]                 VARCHAR (100) CONSTRAINT [DF_COM_PRODUCT_FUND_HOUSE] DEFAULT ('-') NOT NULL,
    [CURRENCY_CODE]              VARCHAR (3)   CONSTRAINT [DF_COM_PRODUCT_CURRENCY_CODE] DEFAULT ('-') NOT NULL,
    CONSTRAINT [PK_COM_PRODUCT] PRIMARY KEY CLUSTERED ([COM_PRODUCT_ID] ASC)
);

