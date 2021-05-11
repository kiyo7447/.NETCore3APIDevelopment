CREATE PROCEDURE [dbo].[GET_salt2]
	@uid NVARCHAR(100)
AS
SELECT salt FROM salttable2  WHERE userid = @uid
