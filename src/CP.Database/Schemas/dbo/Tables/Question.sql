CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL  IDENTITY,
    [Question]      NVARCHAR (MAX)   NOT NULL,
    [Data]          NVARCHAR (MAX)   NOT NULL,
    [ProgramId]     INT             NOT NULL,
	[Status]        INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]     DATETIME        DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     NVARCHAR (255)  DEFAULT ('SYSTEM') NOT NULL,
    [ModifiedOn]    DATETIME        DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]    NVARCHAR (255)  DEFAULT ('SYSTEM') NOT NULL, 
    CONSTRAINT [PK_Question] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Question_Program] FOREIGN KEY ([ProgramId]) REFERENCES [Program]([Id]),
)
