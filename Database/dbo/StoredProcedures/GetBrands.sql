CREATE PROCEDURE [dbo].[GetBrands]
AS
BEGIN
	SELECT b.Id,b.Name,b.Value FROM dbo.Brands b
END