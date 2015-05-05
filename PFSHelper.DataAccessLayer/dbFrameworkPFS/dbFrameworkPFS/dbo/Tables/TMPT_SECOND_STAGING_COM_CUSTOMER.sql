CREATE TABLE [dbo].[TMPT_SECOND_STAGING_COM_CUSTOMER] (
    [TMPT_SECOND_STAGING_COM_CUSTOMER_ID] INT           IDENTITY (1, 1) NOT NULL,
    [PSC_FILE_IMPORT_ID]                  INT           NOT NULL,
    [CIF]                                 VARCHAR (15)  NOT NULL,
    [CUSTOMER_DOB]                        VARCHAR (50)  NOT NULL,
    [CONTROL_CENTER]                      VARCHAR (5)   NOT NULL,
    [COM_EDUCATION_ID]                    INT           CONSTRAINT [DF_TMPT_SECOND_STAGING_COM_CUSTOMER_COM_EDUCATION_ID] DEFAULT ((0)) NULL,
    [FULL_NAME]                           VARCHAR (255) NOT NULL,
    [COM_BRANCH_ID]                       INT           NOT NULL,
    [IS_VALID]                            BIT           NOT NULL,
    [INVALID_REMARK]                      VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_TMPT_SECOND_STAGING_COM_CUSTOMER] PRIMARY KEY CLUSTERED ([TMPT_SECOND_STAGING_COM_CUSTOMER_ID] ASC)
);

