﻿CREATE TABLE [dbo].[Bank]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[BankId] VARCHAR(20) NULL,
	[WebBrowserId] INT NULL,
	[FullName] VARCHAR(100) NULL,
	[TimeOut] INT NULL DEFAULT 120,
	[BankGroupId] INT NULL,
	[UserAgent] VARCHAR(100) NULL,
	[Active] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL DEFAULT GETDATE(),
	[CreatedByUserID] INT NOT NULL,
	[LastUpdatedByUserID] INT NOT NULL,
	CONSTRAINT FK_Bank_User FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT FK_Bank_User_1 FOREIGN KEY([LastUpdatedByUserID]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT FK_Bank_BankGroup FOREIGN KEY([BankGroupId]) REFERENCES BankGroup([Id]),
	CONSTRAINT FK_Bank_WebBrowser FOREIGN KEY([WebBrowserId]) REFERENCES WebBrowser([Id]),
)
