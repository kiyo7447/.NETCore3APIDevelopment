CREATE PROCEDURE [dbo].[GET_idbyemail]
	@em NVARCHAR(200)
AS
SELECT Id FROM usercredentials WHERE email = @em