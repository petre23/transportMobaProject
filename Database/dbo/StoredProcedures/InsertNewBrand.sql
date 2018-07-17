CREATE PROCEDURE [dbo].[InsertNewBrand]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(255)
AS
BEGIN
	DECLARE @lastValue INT = (SELECT MAX(Value) FROM dbo.Brands);
	INSERT INTO dbo.Brands VALUES
	(
		@Id,
		@Name,
		(@lastValue + 1)
	)
END
