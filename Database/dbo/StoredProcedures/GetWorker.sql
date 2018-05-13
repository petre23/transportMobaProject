CREATE PROCEDURE [dbo].[GetWorker]
	@WorkerId uniqueidentifier
AS
BEGIN
	SELECT w.[Id]
		  ,w.FirstName
		  ,w.Surname
		  ,w.BirthDay
		  ,w.CertificateExpirationDate
		  ,w.DrivingLicenseExpirationDate
		  ,w.EmploymentDate
		  ,w.IdentityDocument
		  ,w.MedicalTestsExpirationDate
		  ,w.TachographCardExpirationDate
		  ,e.Id AS Employer
		  ,e.[Name] AS EmployerName
		  ,e.[Value] AS EmployerDropDownValue
		  ,t.Id AS TruckId
		FROM dbo.Worker w
		INNER JOIN dbo.Employers e on e.Id = w.Employer
		INNER JOIN dbo.Trucks t on t.Id = w.Truck
		WHERE w.Id = @WorkerId
END
