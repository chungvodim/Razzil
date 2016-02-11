﻿CREATE TABLE [dbo].[UserRole]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(100) NULL,
	[Active] BIT NOT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL,
	[CreatedByUserID] INT NOT NULL DEFAULT 1,
	[LastUpdatedByUserID] INT NOT NULL DEFAULT 1,
	--CONSTRAINT FK_Role_User FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[User]([Id]),
	--CONSTRAINT FK_Role_User_1 FOREIGN KEY([LastUpdatedByUserID]) REFERENCES [dbo].[User]([Id]),
)
