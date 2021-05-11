CREATE TABLE [dbo].[emailconfirmation]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [userid] NVARCHAR(200) NOT NULL, 
    [token] NVARCHAR(100) NOT NULL, 
    [email] NVARCHAR(200) NOT NULL
)
