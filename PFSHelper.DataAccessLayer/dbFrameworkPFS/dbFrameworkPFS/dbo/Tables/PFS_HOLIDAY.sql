﻿CREATE TABLE [dbo].[PFS_HOLIDAY] (
    [PFS_HOLIDAY_ID]        INT            IDENTITY (1, 1) NOT NULL,
    [PFS_HOLIDAY_STARTDATE] DATETIME       NOT NULL,
    [PFS_HOLIDAY_ENDDATE]   DATETIME       NOT NULL,
    [PFS_HOLIDAY_DESC]      VARCHAR (1000) NOT NULL,
    [RECURRANCE]            VARCHAR (200)  NULL,
    [RECURRANCE_PARENT_ID]  INT            NULL,
    [IS_NEED_APPROVAL]      BIT            NOT NULL,
    [CREATE_BY_USER_ID]     INT            NOT NULL,
    [CREATE_DATE]           DATETIME       NOT NULL,
    [UPDATE_BY_USER_ID]     INT            NOT NULL,
    [UPDATE_DATE]           DATETIME       NOT NULL,
    CONSTRAINT [PK_PFS_HOLIDAY] PRIMARY KEY CLUSTERED ([PFS_HOLIDAY_ID] ASC)
);
