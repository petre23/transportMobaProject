CREATE PROCEDURE [dbo].[SaveTruck]
	@IsNew bit = 1,
	@Id Uniqueidentifier,
	@RegistrationNumber nvarchar(255),
	@Brand UNIQUEIDENTIFIER,
	@ManufacturingYear DATETIME,
	@ITPExpirationDate DATETIME,
	@InsuranceExpirationDate DATETIME,
	@TachographExpirationDate DATETIME,
	@VignetteExpirationDate DATETIME,
	@ConformCopyExpirationDate DATETIME
AS
BEGIN
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Trucks(Id,RegistrationNumber,Brand,ManufacturingYear,ITPExpirationDate,InsuranceExpirationDate,TachographExpirationDate,VignetteExpirationDate,ConformCopyExpirationDate) VALUES
		(
			@Id,
			@RegistrationNumber,
			@Brand,
			@ManufacturingYear,
			@ITPExpirationDate,
			@InsuranceExpirationDate,
			@TachographExpirationDate,
			@VignetteExpirationDate,
			@ConformCopyExpirationDate
		)
	END
	ELSE
	BEGIN
		UPDATE dbo.Trucks SET
			RegistrationNumber = @RegistrationNumber,
			Brand = @Brand,
			ManufacturingYear = @ManufacturingYear,
			ITPExpirationDate = @ITPExpirationDate,
			InsuranceExpirationDate = @InsuranceExpirationDate,
			TachographExpirationDate = @TachographExpirationDate,
			VignetteExpirationDate = @VignetteExpirationDate,
			ConformCopyExpirationDate = @ConformCopyExpirationDate
			WHERE Id = @Id
	END
END
