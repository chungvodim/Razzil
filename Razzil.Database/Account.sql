﻿CREATE TABLE [dbo].[Account]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [BankId] int NOT NULL, 
    [AccountGroupId] int NULL, 
    [AccountName] VARCHAR(50) NULL, 
    [AccountNumber] VARCHAR(50) NULL, 
    [Password] VARCHAR(50) NULL, 
    [Phone] VARCHAR(20) NULL, 
    [Balance] DECIMAL NULL, 
    [Active] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL, 
	[CreatedByUserID] INT NOT NULL,
	[LastUpdatedByUserID] INT NOT NULL,
	CONSTRAINT FK_Account_User FOREIGN KEY([CreatedByUserID]) REFERENCES UserRole([Id]),
	CONSTRAINT FK_Account_User_1 FOREIGN KEY([LastUpdatedByUserID]) REFERENCES UserRole([Id]),
	CONSTRAINT FK_Account_AccountGroup FOREIGN KEY ([AccountGroupId]) REFERENCES AccountGroup(Id),
	CONSTRAINT FK_Account_Bank FOREIGN KEY ([BankId]) REFERENCES Bank(Id),
)
