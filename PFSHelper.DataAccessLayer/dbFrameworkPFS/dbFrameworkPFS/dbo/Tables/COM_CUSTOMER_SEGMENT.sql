﻿CREATE TABLE [dbo].[COM_CUSTOMER_SEGMENT] (
    [COM_CUSTOMER_SEGMENT_ID] INT          NOT NULL,
    [CUSTOMER_SEGMENT_NAME]   VARCHAR (10) NOT NULL,
    [SEGMENT_CODE]            VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_COM_CUSTOMER_SEGMENT] PRIMARY KEY CLUSTERED ([COM_CUSTOMER_SEGMENT_ID] ASC)
);
