﻿CREATE TABLE [dbo].[PFS_GROUP] (
    [PFS_GROUP_ID]      INT            IDENTITY (1, 1) NOT NULL,
    [GROUP_NAME]        VARCHAR (30)   NOT NULL,
    [GROUP_DESCR]       VARCHAR (1280) NOT NULL,
    [IS_ACTIVE]         BIT            NOT NULL,
    [IS_NEED_APPROVAL]  BIT            NOT NULL,
    [CREATE_DATE]       DATETIME       NOT NULL,
    [CREATE_BY_USER_ID] INT            NOT NULL,
    [UPDATE_DATE]       DATETIME       NOT NULL,
    [UPDATE_BY_USER_ID] INT            NOT NULL,
    CONSTRAINT [PK_PFS_GROUP] PRIMARY KEY CLUSTERED ([PFS_GROUP_ID] ASC)
);
