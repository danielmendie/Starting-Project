GO

PRINT(N'Deleting existing question types')
DELETE dbo.QuestionType 
 
PRINT(N'Add rows to [dbo].[QuestionType] ')

INSERT INTO [dbo].[QuestionType] ([Type], [Data], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) 
VALUES (N'Paragraph', N'{"inputType":"Paragraph","inputSetting":{"maximumAllowed":null,"mininumAllowed":"1"}}', 1, '2018-01-01 00:00:00.000', N'SYSTEM', '2018-01-01 00:00:00.000', N'SYSTEM')

INSERT INTO [dbo].[QuestionType] ([Type], [Data], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) 
VALUES (N'YesNo', N'{"inputType":"YesNo","inputOptions":["True","False"]}', 1, '2018-01-01 00:00:00.000', N'SYSTEM', '2018-01-01 00:00:00.000', N'SYSTEM')

INSERT INTO [dbo].[QuestionType] ([Type], [Data], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) 
VALUES (N'DropDown', N'{"inputType":"DropDown","inputOptions":[]}', 1, '2018-01-01 00:00:00.000', N'SYSTEM', '2018-01-01 00:00:00.000', N'SYSTEM')

INSERT INTO [dbo].[QuestionType] ([Type], [Data], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) 
VALUES (N'MultipleChoice', N'{"inputType":"MultipleChoice","inputOptions":[],"inputSetting":{"allowCustomAnswer":true,"maximumAllowed":"1","mininumAllowed":"1"}}', 1, '2018-01-01 00:00:00.000', N'SYSTEM', '2018-01-01 00:00:00.000', N'SYSTEM')

INSERT INTO [dbo].[QuestionType] ([Type], [Data], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) 
VALUES (N'Date', N'{"inputType":"Date","inputSetting":{"maximumAllowed":"1","mininumAllowed":"1"}}', 1, '2018-01-01 00:00:00.000', N'SYSTEM', '2018-01-01 00:00:00.000', N'SYSTEM')

INSERT INTO [dbo].[QuestionType] ([Type], [Data], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) 
VALUES (N'Number', N'{"inputType":"Number","inputSetting":{"maximumAllowed":"1","mininumAllowed":"1"}}', 1, '2018-01-01 00:00:00.000', N'SYSTEM', '2018-01-01 00:00:00.000', N'SYSTEM')

GO
