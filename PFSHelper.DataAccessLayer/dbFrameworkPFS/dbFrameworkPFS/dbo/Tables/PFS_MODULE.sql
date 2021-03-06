﻿CREATE TABLE [dbo].[PFS_MODULE] (
    [PFS_MODULE_ID] INT            NOT NULL,
    [MODULE_CODE]   VARCHAR (50)   CONSTRAINT [DF_PFS_MODULE_MODULE_CODE] DEFAULT ('NONE') NOT NULL,
    [MODULE_NAME]   VARCHAR (100)  CONSTRAINT [DF_PFS_MODULE_MODULE_NAME] DEFAULT ('NONE') NOT NULL,
    [MODULE_DESCR]  VARCHAR (1280) CONSTRAINT [DF_PFS_MODULE_MODULE_DESCR] DEFAULT ('NONE') NOT NULL,
    [INDEX_ORDER]   INT            CONSTRAINT [DF_PFS_MODULE_INDEX_ORDER] DEFAULT ((0)) NOT NULL,
    [IS_VISIBLE]    BIT            CONSTRAINT [DF__PFS_MODUL__IS_VI__662BF692] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_COM_MODULE] PRIMARY KEY CLUSTERED ([PFS_MODULE_ID] ASC)
);

