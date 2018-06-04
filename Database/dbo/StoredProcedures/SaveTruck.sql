CREATE PROCEDURE [dbo].[SaveTruck]
	@IsNew bit = 1,
	@Id Uniqueidentifier,
	@RegistrationNumber nvarchar(255),
	@Brand UNIQUEIDENTIFIER,
	@ManufacturingYear DATETIME = null,
	@ITPExpirationDate DATETIME = null,
	@InsuranceExpirationDate DATETIME = null,
	@TachographExpirationDate DATETIME = null,
	@VignetteExpirationDateUK DATETIME = null,
	@VignetteExpirationDateNL DATETIME = null,
	@ConformCopyExpirationDate DATETIME = null
AS
BEGIN
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Trucks(Id,RegistrationNumber,Brand,ManufacturingYear,ITPExpirationDate,InsuranceExpirationDate,TachographExpirationDate,VignetteExpirationDateUK,VignetteExpirationDateNL,ConformCopyExpirationDate) VALUES
		(
			@Id,
			@RegistrationNumber,
			@Brand,
			@ManufacturingYear,
			@ITPExpirationDate,
			@InsuranceExpirationDate,
			@TachographExpirationDate,
			@VignetteExpirationDateUK,
			@VignetteExpirationDateNL,
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
			VignetteExpirationDateUK = @VignetteExpirationDateUK,
			VignetteExpirationDateNL = @VignetteExpirationDateNL,
			ConformCopyExpirationDate = @ConformCopyExpirationDate
			WHERE Id = @Id
	END
END
