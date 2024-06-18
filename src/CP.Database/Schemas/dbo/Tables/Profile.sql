CREATE TABLE [dbo].[Profile]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [FirstName]     NVARCHAR (50)   NOT NULL,
    [LastName]      NVARCHAR (50)   NOT NULL,
    [Email]         NVARCHAR (100)  NOT NULL,
    [Phone]         NVARCHAR (100)  NULL,
    [Nationality]   NVARCHAR (100)  NULL,
    [Address]       NVARCHAR (500)  NULL,
    [Gender]        NVARCHAR (10)  NULL,
    [DateOfBirth]   DATETIME  NULL,
    [Data]          NVARCHAR (MAX)  NULL,

	[Status]        INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]     DATETIME        DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     NVARCHAR (255)  DEFAULT ('SYSTEM') NOT NULL,
    [ModifiedOn]    DATETIME        DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]    NVARCHAR (255)  DEFAULT ('SYSTEM') NOT NULL,
)
