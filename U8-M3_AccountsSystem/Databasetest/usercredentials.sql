﻿CREATE TABLE [dbo].[usercredentials]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [email] NVARCHAR(200) NOT NULL, 
    [hash] VARBINARY(MAX) NOT NULL
)
