﻿CREATE TABLE [dbo].[WebBrowser]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NULL,
	[Version] VARCHAR(50) NULL,
	[Description] VARCHAR(100) NULL,
	[Active] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL DEFAULT GETDATE(),
	[CreatedByUserID] INT NOT NULL,
	[LastUpdatedByUserID] INT NOT NULL,
	CONSTRAINT FK_WebBrowser_User FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT FK_WebBrowser_User_1 FOREIGN KEY([LastUpdatedByUserID]) REFERENCES [dbo].[User]([Id]),
)
