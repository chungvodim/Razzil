﻿CREATE TABLE [dbo].[Step]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PreviousStepId] int NULL, 
	[CurrentStepId] int NOT NULL, 
	[NextStepId1] int NULL, 
	[NextStepId0] int NULL, 
	[StepTypeId] int NULL, 
    [BankId] INT NULL, 
    [Name] VARCHAR(100) NULL, 
	[Url] NVARCHAR(500) NULL, 
    [Params] NVARCHAR(500) NULL, 
    [Encoding] VARCHAR(50) NULL, 
    [Sign] VARCHAR(500) NULL,
	[Pattern] VARCHAR(500) NULL,
	[XPath] VARCHAR(500) NULL, 
	CONSTRAINT FK_Step_StepType FOREIGN KEY([StepTypeId]) REFERENCES StepType([Id]),
	CONSTRAINT FK_Step_Bank FOREIGN KEY([BankId]) REFERENCES Bank([Id]),
)
