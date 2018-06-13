CREATE PROCEDURE [dbo].[GetFuelInfo]
AS
BEGIN
	SELECT f.Id,
		   f.Worker,
		   f.AdblueLiters,
		   f.AdblueValue,
		   f.DieselValue,
		   f.EstimatedConsumption,
		   f.FueledDieseKMLiters,
		   f.FueledKM,
		   f.GPSConsumption,
		   f.GPSFinalConsumption,
		   f.GPSInitialConsumption,
		   f.RealConsumption,
		   w.FirstName,
		   w.Surname,
		   f.Date
		FROM dbo.Fuel f
		INNER JOIN dbo.Worker w ON w.Id = f.Worker
END
