CREATE PROCEDURE [dbo].[GetDrives]
	@PageSize int = 50,
	@PageNumber int = 0,
	@FilterDriver nvarchar(50) = null,
	@FilterTruck nvarchar(50) = null,
	@FilterTrail nvarchar(50) = null,
	@FilterVlaplan nvarchar(50) = null,
	@FilterVlarref nvarchar(50) = null
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
		   (u.FirstName + ' ' + u.SurName) LastUpdateByUserName,
		   d.EstimatedConsumption,
		   d.CreationDate,
		   dt.TypeName AS DriveTypeName
	FROM dbo.Drive d
	LEFT JOIN dbo.Worker w ON d.Worker = w.Id
	LEFT JOIN dbo.Trucks t ON d.Truck = t.Id
	LEFT JOIN dbo.DriveStatus ds ON ds.Id = d.DriveStatus
	INNER JOIN dbo.Users u ON u.Id = d.LastUpdateByUser
	LEFT JOIN dbo.DriveType dt ON dt.Id = d.DriveTypeId
	WHERE  
	(w.FirstName + '' + w.Surname) like '%'+ (CASE WHEN @FilterDriver IS NOT NULL THEN @FilterDriver ELSE '' END ) +'%'
	AND t.RegistrationNumber like '%'+ (CASE WHEN @FilterTruck IS NOT NULL THEN @FilterTruck ELSE '' END ) +'%'
	AND d.Trailer like '%'+ (CASE WHEN @FilterTrail IS NOT NULL THEN @FilterTrail ELSE '' END ) +'%'
	AND d.Vlaplan like '%'+ (CASE WHEN @FilterVlaplan IS NOT NULL THEN @FilterVlaplan ELSE '' END ) +'%'
	AND d.Vlaref like '%'+ (CASE WHEN @FilterVlarref IS NOT NULL THEN @FilterVlarref ELSE '' END ) +'%'
	ORDER BY d.CreationDate DESC, d.InitialGPSKM ASC, ds.[Order], d.Date  DESC
	OFFSET (@PageSize*@PageNumber) ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
