﻿CREATE TABLE [dbo].[SALES_SO] (
    [SALES_SO_ID]     INT           NOT NULL,
    [SO_NO]           VARCHAR (20)  NULL,
    [ORDER_DATE]      DATETIME      NULL,
    [COM_CUSTOMER_ID] INT           NULL,
    [ADDRESS]         VARCHAR (500) NULL,
    CONSTRAINT [PK_SALES_SO] PRIMARY KEY CLUSTERED ([SALES_SO_ID] ASC),
    CONSTRAINT [FK_SALES_SO_COM_CUSTOMER] FOREIGN KEY ([COM_CUSTOMER_ID]) REFERENCES [dbo].[COM_CUSTOMER] ([COM_CUSTOMER_ID])
);

