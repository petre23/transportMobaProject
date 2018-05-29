CREATE PROCEDURE [dbo].[GetDrives]
	@PageSize int = 50,
	@PageNumber int = 0
AS
BEGIN
	SELECT d.Id,
		   d.Date,
		   d.Destination,
		   d.AdblueLiters,
		   d.AdblueValue,
		   d.CostsSpecification,
		   d.DieselValue,
		   d.Difference,
		   d.DistanceDFDS,
		   d.DistanceGpl,
		   d.DistanceGPS,
		   d.EstimatedConsumption,
		   d.FueledDieseKMLiters,
		   d.FinalGPSKM,
		   d.FueledKM,
		   d.GPSConsumption,
		   d.GPSFinalConsumption,
		   d.GPSInitialConsumption,
		   d.InitialGPSKM,
		   d.LoadingPlace,
		   d.PayedCosts,
		   d.RealConsumption,
		   d.Reason,
		   d.SettlementCosts,
		   d.TotalPayments,
		   d.Vlaplan,
		   d.Vlaref,
		   d.WeightInTons,
		   d.WorkerCosts,
		   w.Id AS Worker,
		   w.FirstName,
		   w.Surname,
		   t.Id AS Truck,
		   t.RegistrationNumber,
		   (u.FirstName + ' ' + u.SurName) LastUpdateByUserName
	FROM dbo.Drive d
	INNER JOIN dbo.Worker w ON d.Worker = w.Id
	INNER JOIN dbo.Trucks t ON d.Truck = t.Id
	INNER JOIN dbo.Users u ON u.Id = d.LastUpdateByUser
	ORDER BY d.Date 
	OFFSET (@PageSize*@PageNumber) ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
