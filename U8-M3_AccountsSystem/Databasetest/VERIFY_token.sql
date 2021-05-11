CREATE PROCEDURE [dbo].[VERIFY_token]
	@tk NVARCHAR(100)
AS
IF EXISTS (SELECT token FROM authtokentable WHERE token = @tk)
SELECT Id FROM authtokentable WHERE token = @tk
ELSE
SELECT ''
