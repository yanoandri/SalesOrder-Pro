﻿CREATE TABLE [dbo].[PFS_USER_LOGIN_ATTEMPT] (
    [PFS_USER_LOGIN_ATTEMPT_ID]   INT           IDENTITY (1, 1) NOT NULL,
    [USER_NAME]                   VARCHAR (50)  NOT NULL,
    [LAST_SUCCESSFULL_LOGIN_DATE] DATETIME      NOT NULL,
    [LAST_FAILED_LOGIN_DATE]      DATETIME      NOT NULL,
    [TOTAL_SUCCESS]               INT           NOT NULL,
    [TOTAL_FAILED]                INT           NOT NULL,
    [LAST_FAILED_DESCRIPTION]     VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_PFS_USER_LOGIN_ATTEMPT] PRIMARY KEY CLUSTERED ([PFS_USER_LOGIN_ATTEMPT_ID] ASC)
);
