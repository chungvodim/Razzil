CREATE TABLE [dbo].[Account]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Bank] VARCHAR(100) NULL, 
    [AccountGroupId] int NULL, 
    [AccountName] VARCHAR(50) NULL, 
    [AccountNumber] VARCHAR(50) NULL, 
    [Password] VARCHAR(50) NULL, 
    [Phone] VARCHAR(50) NULL, 
    [Balance] DECIMAL NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
	CONSTRAINT FK_Account_AccountGroup FOREIGN KEY ([AccountGroupId]) REFERENCES AccountGroup(Id)
)
