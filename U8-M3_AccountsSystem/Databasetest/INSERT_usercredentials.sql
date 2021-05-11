CREATE PROCEDURE [dbo].[INSERT_usercredentials]
	@em NVARCHAR(200),
	@hs VARBINARY(MAX)
AS
INSERT INTO usercredentials
(Id,email,hash)
OUTPUT inserted.Id
values
(NEWID(),@em,@hs)