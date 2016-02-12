﻿CREATE TABLE [dbo].[BankGroup]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[Active] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL,
	[CreatedByUserID] INT NOT NULL,
	[LastUpdatedByUserID] INT NOT NULL,
	CONSTRAINT FK_BankGroup_User FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT FK_BankGroup_User_1 FOREIGN KEY([LastUpdatedByUserID]) REFERENCES [dbo].[User]([Id]),
)
