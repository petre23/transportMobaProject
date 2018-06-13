CREATE PROCEDURE [dbo].[DeleteFuel]
	@FuelId uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.Fuel where Id = @FuelId
END
