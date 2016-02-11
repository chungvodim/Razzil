﻿CREATE TABLE [dbo].[BankTransaction]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [TransactionId] VARCHAR(50) NULL, 
	[TypeId] INT NULL,
    [FromAccountNumber] VARCHAR(20) NULL, 
	[FromBankId] INT NULL, 
    [ToAccountNumber] VARCHAR(20) NULL, 
	[ToBankId] INT NULL, 
    [Amount] DECIMAL NULL, 
	[BankCharge] DECIMAL(8) NULL, 
    [CurrentBalance] DECIMAL NULL, 
	[Captcha] VARCHAR(20) NULL, 
    [Otp] VARCHAR(20) NULL, 
    [OtpRef] VARCHAR(20) NULL, 
	[LastPage] NVARCHAR(MAX) NULL,
    [Active] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL, 
	[CreatedByUserID] INT NOT NULL,
	[LastUpdatedByUserID] INT NOT NULL,
	CONSTRAINT FK_BankTransaction_User FOREIGN KEY([CreatedByUserID]) REFERENCES UserRole([Id]),
	CONSTRAINT FK_BankTransaction_User_1 FOREIGN KEY([LastUpdatedByUserID]) REFERENCES UserRole([Id]),
    CONSTRAINT FK_BankTransaction_TransactionType FOREIGN KEY ([TypeId]) REFERENCES TransactionType(Id),
    CONSTRAINT FK_BankTransaction_Bank FOREIGN KEY ([FromBankId]) REFERENCES Bank(Id),
    CONSTRAINT FK_BankTransaction_Bank_1 FOREIGN KEY ([ToBankId]) REFERENCES Bank(Id),
)
