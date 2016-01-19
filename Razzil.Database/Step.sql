CREATE TABLE [dbo].[Step]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[StepId] int NOT NULL, 
	[StepTypeId] int NULL, 
    [BankId] INT NULL, 
    [Description] VARCHAR(100) NULL, 
	[Url] NVARCHAR(500) NULL, 
    [Params] NVARCHAR(500) NULL, 
    [Encoding] VARCHAR(50) NULL, 
    [Sign] VARCHAR(500) NULL, 
	CONSTRAINT FK_Step_StepType FOREIGN KEY([StepTypeId]) REFERENCES STepType([Id]),
	CONSTRAINT FK_Step_Bank FOREIGN KEY([BankId]) REFERENCES Bank([Id]),
)
