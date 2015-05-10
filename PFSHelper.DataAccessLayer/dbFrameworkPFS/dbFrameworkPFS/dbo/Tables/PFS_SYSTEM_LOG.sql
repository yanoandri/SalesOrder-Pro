﻿CREATE TABLE [dbo].[PFS_SYSTEM_LOG] (
    [PFS_SYSTEM_LOG_ID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [REFERENCE_NUMBER]  VARCHAR (25)   DEFAULT ('-') NULL,
    [COM_PROCESS_ID]    INT            DEFAULT ((0)) NOT NULL,
    [LOG_DATE]          DATETIME       DEFAULT ('1900-01-01') NOT NULL,
    [STATUS]            INT            DEFAULT ((0)) NOT NULL,
    [DESCRIPTION]       VARCHAR (1280) DEFAULT ('-') NOT NULL,
    [DETAIL]            XML            DEFAULT ('<xml />') NULL,
    PRIMARY KEY CLUSTERED ([PFS_SYSTEM_LOG_ID] ASC) ON [ANZ_PSC_ErrorLog]
) TEXTIMAGE_ON [ANZ_PSC_ErrorLog];
