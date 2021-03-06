﻿CREATE TABLE [dbo].[OTP]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Content] NVARCHAR(1000) NOT NULL, 
    [From] VARCHAR(50) NULL,
    [To] VARCHAR(50) NULL,
    [Ref] VARCHAR(20) NULL,
    [Result] VARCHAR(20) NULL,
	[Passed] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[CreatedByUserID] INT NOT NULL,
	CONSTRAINT FK_OTP_User FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[User]([Id]),
)
