CREATE TABLE [dbo].[PSC_EXCEPTION_REQUIRED_MATRIX] (
    [PSC_EXCEPTION_REQUIRED_MATRIX_ID] INT      IDENTITY (1, 1) NOT NULL,
    [IS_VC]                            BIT      NOT NULL,
    [IS_RISK_MISMATCH]                 BIT      NOT NULL,
    [EXCEPTION_REQUIRE_STATUS]         BIT      NOT NULL,
    [IS_ACTIVE]                        BIT      NOT NULL,
    [IS_DELETED]                       BIT      NOT NULL,
    [CREATE_DATE]                      DATETIME NOT NULL,
    [CREATE_BY_USER_ID]                INT      NOT NULL,
    [UPDATE_DATE]                      DATETIME NOT NULL,
    [UPDATE_BY_USER_ID]                INT      NOT NULL,
    CONSTRAINT [PK_PSC_EXCEPTION_REQUIRED_MATRIX] PRIMARY KEY CLUSTERED ([PSC_EXCEPTION_REQUIRED_MATRIX_ID] ASC)
);

