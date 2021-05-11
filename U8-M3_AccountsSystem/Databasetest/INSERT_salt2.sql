CREATE PROCEDURE [dbo].[INSERT_salt2]
	@id NVARCHAR(100),
	@slt VARBINARY(100)
AS
INSERT INTO salttable2
(userid,salt)
values
(@id,@slt)