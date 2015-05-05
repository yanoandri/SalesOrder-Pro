CREATE TABLE [dbo].[COM_ASSET_CLASS] (
    [COM_ASSET_CLASS_ID]             INT           DEFAULT ((0)) NOT NULL,
    [ASSET_CLASS_CODE]               VARCHAR (15)  DEFAULT ('-') NOT NULL,
    [ASSET_CLASS_NAME]               VARCHAR (100) DEFAULT ('-') NOT NULL,
    [DESCRIPTION]                    VARCHAR (255) DEFAULT ('-') NOT NULL,
    [CONCENTRATION_LIMIT_PERCENTAGE] FLOAT (53)    DEFAULT ((0)) NOT NULL,
    [IS_ACTIVE]                      BIT           DEFAULT ((0)) NOT NULL,
    [IS_DELETED]                     BIT           DEFAULT ((0)) NOT NULL,
    [CREATE_DATE]                    DATETIME      DEFAULT ('1900-01-01') NOT NULL,
    [CREATE_BY_USER_ID]              INT           DEFAULT ((0)) NOT NULL,
    [UPDATE_DATE]                    DATETIME      DEFAULT ('1900-01-01') NOT NULL,
    [UPDATE_BY_USER_ID]              INT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([COM_ASSET_CLASS_ID] ASC)
);

