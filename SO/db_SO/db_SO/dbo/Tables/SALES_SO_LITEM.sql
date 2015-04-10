﻿CREATE TABLE [dbo].[SALES_SO_LITEM] (
    [SALES_SO_LITEM_ID] INT           IDENTITY (1, 1) NOT NULL,
    [SALES_SO_ID]       INT           NULL,
    [ITEM_NAME]         VARCHAR (100) NULL,
    [QUANTITY]          INT           NULL,
    [PRICE]             FLOAT (53)    NULL,
    CONSTRAINT [PK_SALES_SO_LITEM] PRIMARY KEY CLUSTERED ([SALES_SO_LITEM_ID] ASC),
    CONSTRAINT [FK_SALES_SO_LITEM_SALES_SO] FOREIGN KEY ([SALES_SO_ID]) REFERENCES [dbo].[SALES_SO] ([SALES_SO_ID])
);
