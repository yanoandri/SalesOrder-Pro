﻿CREATE TABLE [dbo].[COM_CUSTOMER_RISK_RATING] (
    [COM_CUSTOMER_RISK_RATING_ID] INT           DEFAULT ((0)) NOT NULL,
    [RISK_RATING_SCORE]           VARCHAR (5)   DEFAULT ('-') NOT NULL,
    [DESCRIPTION]                 VARCHAR (255) DEFAULT ('-') NOT NULL,
    PRIMARY KEY CLUSTERED ([COM_CUSTOMER_RISK_RATING_ID] ASC)
);

