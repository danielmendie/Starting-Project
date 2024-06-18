CREATE TABLE [dbo].[QuestionType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Type]          NVARCHAR (50)   NOT NULL,
    [Data]          NVARCHAR (MAX)  NULL,

	[Status]        INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]     DATETIME        DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     NVARCHAR (255)  DEFAULT ('SYSTEM') NOT NULL,
    [ModifiedOn]    DATETIME        DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]    NVARCHAR (255)  DEFAULT ('SYSTEM') NOT NULL,
)
