CREATE TABLE [dbo].[Step]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PreviousStepId] int NULL, 
	[CurrentStepId] int NOT NULL, 
	[NextStepId] int NULL, 
	[StepTypeId] int NULL, 
    [BankId] INT NULL, 
    [Description] VARCHAR(100) NULL, 
	[Url] NVARCHAR(500) NULL, 
    [Params] NVARCHAR(500) NULL, 
    [Encoding] VARCHAR(50) NULL, 
    [Signs] VARCHAR(500) NULL,
	[Patterns] VARCHAR(500) NULL, 
	CONSTRAINT FK_Step_StepType FOREIGN KEY([StepTypeId]) REFERENCES StepType([Id]),
	CONSTRAINT FK_Step_Bank FOREIGN KEY([BankId]) REFERENCES Bank([Id]),
)
