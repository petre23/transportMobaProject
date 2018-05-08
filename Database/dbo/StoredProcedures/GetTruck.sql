CREATE PROCEDURE [dbo].[GetTruck]
	@TruckId Uniqueidentifier
AS
BEGIN
	SELECT t.[Id]
		  ,t.[RegistrationNumber]
		  ,b.[Name] AS BrandName
		  ,b.Id AS BrandId
		  ,b.[Value] AS BrandDropDownValue
		  ,t.[ManufacturingYear]
		  ,t.[ITPExpirationDate]
		  ,t.[InsuranceExpirationDate]
		  ,t.[TachographExpirationDate]
		  ,t.[VignetteExpirationDate]
		  ,t.[ConformCopyExpirationDate]
		FROM dbo.Trucks t
		INNER JOIN dbo.Brands b ON t.Brand = b.Id
		WHERE t.Id = @TruckId
END