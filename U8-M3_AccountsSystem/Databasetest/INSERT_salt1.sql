CREATE PROCEDURE [dbo].[INSERT_salt1]
	@id NVARCHAR(100),
	@slt VARBINARY(100)
AS
INSERT INTO salttable1
(userid,salt)
values
(@id,@slt)

