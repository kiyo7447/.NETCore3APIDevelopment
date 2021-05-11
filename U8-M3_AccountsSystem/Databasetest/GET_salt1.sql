CREATE PROCEDURE [dbo].[GET_salt1]
	@uid NVARCHAR(100)
AS
SELECT salt FROM salttable1  WHERE userid = @uid
