﻿CREATE TABLE [dbo].[PSC_IMPORTANT_NOTES_MATRIX] (
    [PSC_IMPORTANT_NOTES_MATRIX_ID] INT          CONSTRAINT [DF__PSC_IMPOR__PSC_I__371C01EE] DEFAULT ((0)) NOT NULL,
    [REF_CODE]                      VARCHAR (50) CONSTRAINT [DF__PSC_IMPOR__REF_C__38102627] DEFAULT ('-') NOT NULL,
    [REF_OBJECT]                    VARCHAR (50) CONSTRAINT [DF__PSC_IMPOR__REF_O__39044A60] DEFAULT ('-') NOT NULL,
    [IS_P1_CHECKED]                 BIT          CONSTRAINT [DF__PSC_IMPOR__IS_P1__39F86E99] DEFAULT ((0)) NOT NULL,
    [IS_P2_CHECKED]                 BIT          CONSTRAINT [DF__PSC_IMPOR__IS_P2__3AEC92D2] DEFAULT ((0)) NOT NULL,
    [IS_P3_CHECKED]                 BIT          CONSTRAINT [DF__PSC_IMPOR__IS_P3__3BE0B70B] DEFAULT ((0)) NOT NULL,
    [IS_P4_CHECKED]                 BIT          CONSTRAINT [DF__PSC_IMPOR__IS_P4__3CD4DB44] DEFAULT ((0)) NOT NULL,
    [IS_P5_CHECKED]                 BIT          CONSTRAINT [DF__PSC_IMPOR__IS_P5__3DC8FF7D] DEFAULT ((0)) NOT NULL,
    [IS_MISMATCH_CHECKED]           BIT          CONSTRAINT [DF__PSC_IMPOR__IS_MI__3EBD23B6] DEFAULT ((0)) NOT NULL,
    [CREATE_DATE]                   DATETIME     CONSTRAINT [DF__PSC_IMPOR__CREAT__3FB147EF] DEFAULT ('1900-01-01') NOT NULL,
    [CREATE_BY_USER_ID]             INT          CONSTRAINT [DF__PSC_IMPOR__CREAT__40A56C28] DEFAULT ((0)) NOT NULL,
    [UPDATE_DATE]                   DATETIME     CONSTRAINT [DF__PSC_IMPOR__UPDAT__41999061] DEFAULT ('1900-01-01') NOT NULL,
    [UPDATE_BY_USER_ID]             INT          CONSTRAINT [DF__PSC_IMPOR__UPDAT__428DB49A] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__PSC_IMPO__9A564B153533B97C] PRIMARY KEY CLUSTERED ([PSC_IMPORTANT_NOTES_MATRIX_ID] ASC)
);

