CREATE PROCEDURE [dbo].[GetDrives]
	@PageSize int = 50,
	@PageNumber int = 0,
	@SearchText nvarchar(50) = null
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
		   d.Trailer,
		   (u.FirstName + ' ' + u.SurName) LastUpdateByUserName
	FROM dbo.Drive d
	INNER JOIN dbo.Worker w ON d.Worker = w.Id
	INNER JOIN dbo.Trucks t ON d.Truck = t.Id
	LEFT JOIN dbo.DriveStatus ds ON ds.Id = d.DriveStatus
	INNER JOIN dbo.Users u ON u.Id = d.LastUpdateByUser
	WHERE @SearchText IS NULL 
	OR (t.RegistrationNumber like '%'+@SearchText+'%' OR d.Vlaref like '%'+@SearchText+'%' OR d.Trailer like '%'+@SearchText+'%')
	ORDER BY d.Date 
	OFFSET (@PageSize*@PageNumber) ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
