﻿CREATE TABLE [dbo].[Bank]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BankId] VARCHAR(20) NULL,
	[Name] VARCHAR(100) NOT NULL,
	[FullName] VARCHAR(100) NULL,
	[TimeOut] INT NULL DEFAULT 120,
	[BankGroupId] INT NULL,
	[Active] BIT NOT NULL DEFAULT 1,
	[CreatedTime] DATETIME NOT NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL,
	CONSTRAINT FK_Bank_BankGroup FOREIGN KEY([BankGroupId]) REFERENCES Bank([Id]),
)
