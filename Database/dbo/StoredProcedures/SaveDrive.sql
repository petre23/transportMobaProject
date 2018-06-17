CREATE PROCEDURE [dbo].[SaveDrive]
	@IsNew bit = 1,
	@Id UNIQUEIDENTIFIER,
	@Date DATETIME,
	@Destination nvarchar(255),
	@CostsSpecification nvarchar(MAX) = null,
	@Difference decimal(12,2) = null,
	@DistanceDFDS decimal(12,2) = null,
	@DistanceGpl decimal(12,2) = null,
	@DistanceGPS decimal(12,2) = null,
	@FinalGPSKM decimal(12,2) = null,
	@InitialGPSKM decimal(12,2),
	@LoadingPlace nvarchar(255),
	@PayedCosts decimal(18,3) = null,
	@Reason nvarchar(MAX) = null,
	@SettlementCosts  decimal(18,3) = null,
	@TotalPayments  decimal(18,3) = null,
	@Vlaplan nvarchar(255),
	@Vlaref nvarchar(255),
	@WeightInTons decimal(12,2),
	@WorkerCosts decimal(18,3) = null,
	@Worker UNIQUEIDENTIFIER,
	@Truck UNIQUEIDENTIFIER,
	@LastUpdateByUser UNIQUEIDENTIFIER,
	@PayedCostsPounds decimal(12,2) = null,
	@SettlementCostsPounds decimal(12,2) = null,
	@WorkerCostsPounds decimal(12,2) = null,
	@TotalPaymentsPounds decimal(12,2) = null,
	@DriveStatus UNIQUEIDENTIFIER = null,
	@Trailer NVARCHAR(255)
AS
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Drive(Id,Date,Destination,CostsSpecification,
							Difference,DistanceDFDS,DistanceGpl,DistanceGPS,
							FinalGPSKM,InitialGPSKM,LoadingPlace,PayedCosts,Reason,SettlementCosts,TotalPayments,Truck,Vlaplan,
							Vlaref,WeightInTons,Worker,WorkerCosts,LastUpdateByUser,WorkerCostsPounds,PayedCostsPounds,
							SettlementCostsPounds,TotalPaymentsPounds,Trailer,DriveStatus)
		VALUES
		(@Id,@Date,@Destination,@CostsSpecification,
		@Difference,@DistanceDFDS,@DistanceGpl,@DistanceGPS,
		@FinalGPSKM,@InitialGPSKM,@LoadingPlace,@PayedCosts,@Reason,@SettlementCosts,@TotalPayments,@Truck,@Vlaplan,
		@Vlaref,@WeightInTons,@Worker,@WorkerCosts,@LastUpdateByUser,@WorkerCostsPounds,@PayedCostsPounds
		,@SettlementCostsPounds,@TotalPaymentsPounds,@Trailer,@DriveStatus)
	END
	ELSE
	BEGIN
		UPDATE dbo.Drive SET
			Date = @Date,
			Destination = @Destination,
			CostsSpecification = @CostsSpecification,
			Difference = @Difference,
			DistanceDFDS = @DistanceDFDS,
			DistanceGpl = @DistanceGpl,
			DistanceGPS = @DistanceGPS,
			FinalGPSKM = @FinalGPSKM,
			InitialGPSKM = @InitialGPSKM,
			LoadingPlace = @LoadingPlace,
			PayedCosts = @PayedCosts,
			Reason = @Reason,
			SettlementCosts = @SettlementCosts,
			TotalPayments = @TotalPayments,
			Truck = @Truck,
			Vlaplan = @Vlaplan,
			Vlaref = @Vlaref,
			WeightInTons = @WeightInTons,
			WorkerCosts = @WorkerCosts,
			Worker = @Worker,
			LastUpdateByUser = @LastUpdateByUser,
			PayedCostsPounds = @PayedCostsPounds,
			WorkerCostsPounds = @WorkerCostsPounds,
			SettlementCostsPounds = @SettlementCostsPounds,
			TotalPaymentsPounds = @TotalPaymentsPounds,
			Trailer = @Trailer,
			DriveStatus = @DriveStatus
			WHERE Id = @Id
	END