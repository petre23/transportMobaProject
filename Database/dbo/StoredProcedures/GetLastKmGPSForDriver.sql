CREATE PROCEDURE [dbo].[GetLastKmGPSForDriver]
	@WorkerId uniqueidentifier
AS
BEGIN
	SELECT TOP 1 f.DistanceGPS as LastKmGPSForDriver
	FROM dbo.Fuel f
	WHERE f.Worker = @WorkerId
	ORDER BY f.CreationDate DESC
END
