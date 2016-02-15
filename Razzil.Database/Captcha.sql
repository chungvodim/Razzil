CREATE TABLE [dbo].[Captcha]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Image] IMAGE NOT NULL, 
    [Result] NVARCHAR(20) NULL,
	[Passed] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[CreatedByUserID] INT NOT NULL,
	CONSTRAINT FK_Captcha_User FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[User]([Id]),
)
