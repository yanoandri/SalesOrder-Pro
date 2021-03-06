﻿CREATE TABLE [dbo].[PFS_SYS_PARAM] (
    [CODE]                   VARCHAR (100)  NOT NULL,
    [DESCRIPTION]            VARCHAR (255)  NOT NULL,
    [VALUE]                  VARCHAR (1280) NOT NULL,
    [DATA_TYPE]              VARCHAR (20)   NOT NULL,
    [IS_VISIBLE]             BIT            NOT NULL,
    [PFS_SYS_PARAM_GROUP_ID] INT            NOT NULL,
    [SYS_PARAM_NAME]         VARCHAR (100)  NOT NULL,
    [INDEX_ORDER]            INT            NOT NULL,
    [IS_ENCRYPTED]           BIT            NOT NULL,
    CONSTRAINT [PK_PFS_SYS_PARAM] PRIMARY KEY CLUSTERED ([CODE] ASC),
    CONSTRAINT [PFS_SYS_PARAM_GROUP_PFS_SYS_PARAM_FK1] FOREIGN KEY ([PFS_SYS_PARAM_GROUP_ID]) REFERENCES [dbo].[PFS_SYS_PARAM_GROUP] ([PFS_SYS_PARAM_GROUP_ID])
);

