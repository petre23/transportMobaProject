CREATE PROCEDURE [dbo].[GetDrivesForWorkerByDateInterval]
	@WorkerId UNIQUEIDENTIFIER,
	@StartDate DATETIME,
	@EndDate DATETIME
AS
BEGIN
	SELECT d.Id,
		   d.Date,
		   d.Destination,
		   d.CostsSpecification,
		   d.Difference,
		   d.DistanceDFDS,
		   d.DistanceGpl,
		   d.DistanceGPS,
		   d.FinalGPSKM,
		   d.InitialGPSKM,
		   d.LoadingPlace,
		   d.PayedCosts,
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
		   d.PayedCostsPounds,
		   d.SettlementCostsPounds,
		   d.TotalPaymentsPounds,
		   d.WorkerCostsPounds,
		   d.DriveStatus,
		   ds.Status AS DriveStatusName,
		   d.Trailer
	FROM dbo.Drive d
	INNER JOIN dbo.Worker w ON d.Worker = w.Id
	INNER JOIN dbo.Trucks t ON d.Truck = t.Id
	LEFT JOIN dbo.DriveStatus ds ON ds.Id = d.DriveStatus
	WHERE d.Worker = @WorkerId
	AND d.Date BETWEEN @StartDate AND @EndDate
END