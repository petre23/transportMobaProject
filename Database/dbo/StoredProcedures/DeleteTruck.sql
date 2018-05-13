CREATE PROCEDURE [dbo].[DeleteTruck]
	@TruckId Uniqueidentifier
AS
BEGIN
	IF EXISTS(SELECT TOP 1 * FROM dbo.Trucks WHERE Id = @TruckId)
	BEGIN
		DELETE FROM dbo.Trucks WHERE Id = @TruckId
	END
END
