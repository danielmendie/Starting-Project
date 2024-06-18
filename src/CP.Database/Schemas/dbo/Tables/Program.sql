CREATE TABLE [dbo].[Program]
(
	[Id]            INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title]         NVARCHAR(500) NOT NULL, 
    [Description]   NVARCHAR(2000) NOT NULL,
    [Status]        INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]     DATETIME        DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     NVARCHAR (255)  DEFAULT ('SYSTEM') NOT NULL,
    [ModifiedOn]    DATETIME        DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]    NVARCHAR (255)  DEFAULT ('SYSTEM') NOT NULL,
)
