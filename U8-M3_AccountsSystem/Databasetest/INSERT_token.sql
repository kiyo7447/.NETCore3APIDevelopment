CREATE PROCEDURE [dbo].[INSERT_token]
	@uid NVARCHAR(100),
	@tk NVARCHAR(100)
AS
INSERT INTO authtokentable 

(userid,token)
values
(@uid,@tk)