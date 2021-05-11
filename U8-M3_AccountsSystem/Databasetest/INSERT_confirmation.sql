CREATE PROCEDURE [dbo].[INSERT_confirmation]
	 @tk NVARCHAR(100),
	 @uid NVARCHAR(100),
	 @em NVARCHAR(200)
AS
 INSERT INTO emailconfirmation
 (token,userid,email)
 values
 (@tk,@uid,@em)
