CREATE PROCEDURE [dbo].[GET_hash]
	@uid NVARCHAR(100)
AS
SELECT hash FROM usercredentials WHERE Id = @uid