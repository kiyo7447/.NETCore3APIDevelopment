﻿CREATE TABLE [dbo].[salttable2]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[userid] NVARCHAR(100) NOT NULL,
	[salt] VARBINARY(MAX) NOT NULL
)
