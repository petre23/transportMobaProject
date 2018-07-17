drop table dbo.drive
CREATE TABLE [dbo].[Drive]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Worker] UNIQUEIDENTIFIER NOT NULL,
	[Truck] UNIQUEIDENTIFIER NOT NULL,
	[Date] DATETIME NOT NULL,
	[Vlaplan] nvarchar(255) NOT NULL,
	[Vlaref] nvarchar(255) NOT NULL,
	[LoadingPlace] nvarchar(255) NOT NULL,
	[Destination] nvarchar(255) NOT NULL,
	[InitialGPSKM] decimal(12,2) NOT NULL,
	[FinalGPSKM] decimal(12,2) NULL,
	[DistanceGPS] decimal(12,2) NULL,
	[DistanceGpl] decimal(12,2) NULL,
	[DistanceDFDS] decimal(12,2) NULL,
	[Difference] decimal(12,2) NULL,
	[Reason] nvarchar(MAX) NULL,
	[WeightInTons] decimal(12,2) NOT NULL,
	[WorkerCosts] decimal(18,3) NULL,
	[CostsSpecification] nvarchar(MAX) NULL,
	[PayedCosts] decimal(18,3) NULL,
	[SettlementCosts] decimal(18,3) NULL,
	[TotalPayments] decimal(18,3) NULL,
    [GPSInitialConsumption] decimal(12,2) NOT NULL,
	[GPSFinalConsumption] decimal(12,2) NULL,
	[GPSConsumption] decimal(12,2) NULL,
	[EstimatedConsumption] decimal(12,2) NOT NULL,
	[FueledKM] decimal(12,2) NULL,
	[FueledDieseKMLiters] decimal(12,2) NULL,
	[DieselValue] decimal(12,3) NULL,
	[RealConsumption] decimal(12,2) NULL,
	[AdblueLiters] decimal(12,2) NULL,
	[AdblueValue] decimal(12,2) NULL,
	[LastUpdateByUser] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT FK_DRIVE_WORKER FOREIGN KEY (Worker) REFERENCES dbo.Worker (Id),
	CONSTRAINT FK_DRIVE_Truck FOREIGN KEY (Truck) REFERENCES dbo.Trucks (Id),
	CONSTRAINT FK_DRIVE_User FOREIGN KEY (LastUpdateByUser) REFERENCES dbo.Users (Id)
)
GO
ALTER PROCEDURE [dbo].[SaveDrive]
	@IsNew bit = 1,
	@Id UNIQUEIDENTIFIER,
	@Date DATETIME,
	@Destination nvarchar(255),
	@AdblueLiters decimal(12,2) = null,
	@AdblueValue decimal(12,2) = null,
	@CostsSpecification nvarchar(MAX) = null,
	@DieselValue decimal(12,3) = null,
	@Difference decimal(12,2) = null,
	@DistanceDFDS decimal(12,2) = null,
	@DistanceGpl decimal(12,2) = null,
	@DistanceGPS decimal(12,2) = null,
	@EstimatedConsumption decimal(12,2),
	@FueledDieseKMLiters decimal(12,2) = null,
	@FinalGPSKM decimal(12,2) = null,
	@FueledKM decimal(12,2) = null,
	@GPSConsumption decimal(12,2) = null,
	@GPSFinalConsumption decimal(12,2) = null,
	@GPSInitialConsumption decimal(12,2),
	@InitialGPSKM decimal(12,2),
	@LoadingPlace nvarchar(255),
	@PayedCosts decimal(18,3) = null,
	@RealConsumption decimal(12,2) = null,
	@Reason nvarchar(MAX) = null,
	@SettlementCosts  decimal(18,3) = null,
	@TotalPayments  decimal(18,3) = null,
	@Vlaplan nvarchar(255),
	@Vlaref nvarchar(255),
	@WeightInTons decimal(12,2),
	@WorkerCosts decimal(18,3) = null,
	@Worker UNIQUEIDENTIFIER,
	@Truck UNIQUEIDENTIFIER,
	@LastUpdateByUser UNIQUEIDENTIFIER
AS
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Drive(Id,Date,Destination,AdblueLiters,AdblueValue,CostsSpecification,DieselValue,
							Difference,DistanceDFDS,DistanceGpl,DistanceGPS,EstimatedConsumption,FueledDieseKMLiters,
							FinalGPSKM,FueledKM,GPSFinalConsumption,GPSConsumption,GPSInitialConsumption,InitialGPSKM,
							LoadingPlace,PayedCosts,RealConsumption,Reason,SettlementCosts,TotalPayments,Truck,Vlaplan,
							Vlaref,WeightInTons,Worker,WorkerCosts,LastUpdateByUser)
		VALUES
		(@Id,@Date,@Destination,@AdblueLiters,@AdblueValue,@CostsSpecification,@DieselValue,
		@Difference,@DistanceDFDS,@DistanceGpl,@DistanceGPS,@EstimatedConsumption,@FueledDieseKMLiters,
		@FinalGPSKM,@FueledKM,@GPSFinalConsumption,@GPSConsumption,@GPSInitialConsumption,@InitialGPSKM,
		@LoadingPlace,@PayedCosts,@RealConsumption,@Reason,@SettlementCosts,@TotalPayments,@Truck,@Vlaplan,
		@Vlaref,@WeightInTons,@Worker,@WorkerCosts,@LastUpdateByUser)
	END
	ELSE
	BEGIN
		UPDATE dbo.Drive SET
			Date = @Date,
			Destination = @Destination,
			AdblueLiters = @AdblueLiters,
		    AdblueValue =@AdblueValue,
			CostsSpecification = @CostsSpecification,
			DieselValue = @DieselValue,
			Difference = @Difference,
			DistanceDFDS = @DistanceDFDS,
			DistanceGpl = @DistanceGpl,
			DistanceGPS = @DistanceGPS,
			EstimatedConsumption = @EstimatedConsumption,
			FueledDieseKMLiters = @FueledDieseKMLiters,
			FinalGPSKM = @FinalGPSKM,
			FueledKM = @FueledKM,
			GPSFinalConsumption = @GPSFinalConsumption,
			GPSConsumption = @GPSConsumption,
			GPSInitialConsumption = @GPSInitialConsumption,
			InitialGPSKM = @InitialGPSKM,
			LoadingPlace = @LoadingPlace,
			PayedCosts = @PayedCosts,
			RealConsumption = @RealConsumption,
			Reason = @Reason,
			SettlementCosts = @SettlementCosts,
			TotalPayments = @TotalPayments,
			Truck = @Truck,
			Vlaplan = @Vlaplan,
			Vlaref = @Vlaref,
			WeightInTons = @WeightInTons,
			WorkerCosts = @WorkerCosts,
			Worker = @Worker,
			LastUpdateByUser = @LastUpdateByUser
			WHERE Id = @Id
	END
GO

ALTER PROCEDURE [dbo].[SaveTruck]
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
GO

INSERT INTO dbo.DriveStatus VALUES
(
	NEWID(),
	'Anulat - ajuns'
)

INSERT INTO dbo.DriveStatus VALUES
(
	NEWID(),
	'Anulat - nu a ajuns'
)

INSERT INTO dbo.DriveStatus VALUES
(
	NEWID(),
	'In desfasurare'
)
INSERT INTO dbo.DriveStatus VALUES
(
	NEWID(),
	'Finalizat'
)