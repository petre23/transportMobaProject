CREATE PROCEDURE [dbo].[GetFuelInfoById]
	@FuelId UNIQUEIDENTIFIER
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
		   f.WorkerSelfFueled,
		   f.WorkerSelfFueledPounds,
		   f.WorkerTKFuel,
		   f.WorkerTKFuelPounds,
		   f.CompanyTKFuel,
		   f.CompanyTKFuelPounds,
		   w.FirstName,
		   w.Surname,
		   f.Date,
		   f.DistanceGPS,
		   f.Truck,
		   t.RegistrationNumber AS TruckRegistrationNumber
		FROM dbo.Fuel f
		LEFT JOIN dbo.Worker w ON w.Id = f.Worker
		LEFT JOIN dbo.Trucks t ON t.Id = f.Truck
		WHERE f.Id = @FuelId
END