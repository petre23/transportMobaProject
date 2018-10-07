CREATE PROCEDURE [dbo].[SaveDrive]
	@IsNew bit = 1,
	@Id UNIQUEIDENTIFIER,
	@Date DATETIME = null,
	@Destination nvarchar(255) = null,
	@CostsSpecification nvarchar(MAX) = null,
	@Difference decimal(12,2) = null,
	@DistanceDFDS decimal(12,2) = null,
	@DistanceGpl decimal(12,2) = null,
	@DistanceGPS decimal(12,2) = null,
	@FinalGPSKM decimal(12,2) = null,
	@InitialGPSKM decimal(12,2) = null,
	@LoadingPlace nvarchar(255) = null,
	@PayedCosts decimal(18,3) = null,
	@Reason nvarchar(MAX) = null,
	@SettlementCosts  decimal(18,3) = null,
	@TotalPayments  decimal(18,3) = null,
	@Vlaplan nvarchar(255) = null,
	@Vlaref nvarchar(255) = null,
	@WeightInTons decimal(12,2) = null,
	@WorkerCosts decimal(18,3) = null,
	@Worker UNIQUEIDENTIFIER = null,
	@Truck UNIQUEIDENTIFIER = null,
	@LastUpdateByUser UNIQUEIDENTIFIER,
	@PayedCostsPounds decimal(12,2) = null,
	@SettlementCostsPounds decimal(12,2) = null,
	@WorkerCostsPounds decimal(12,2) = null,
	@TotalPaymentsPounds decimal(12,2) = null,
	@DriveStatus UNIQUEIDENTIFIER = null,
	@Trailer NVARCHAR(255) = null,
	@EstimatedConsumption decimal(12,2) = null,
	@DriveType int = null,
	@DriveTypeEnd int = null
AS
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Drive(Id,Date,Destination,CostsSpecification,
							Difference,DistanceDFDS,DistanceGpl,DistanceGPS,
							FinalGPSKM,InitialGPSKM,LoadingPlace,PayedCosts,Reason,SettlementCosts,TotalPayments,Truck,Vlaplan,
							Vlaref,WeightInTons,Worker,WorkerCosts,LastUpdateByUser,WorkerCostsPounds,PayedCostsPounds,
							SettlementCostsPounds,TotalPaymentsPounds,Trailer,DriveStatus,EstimatedConsumption,CreationDate,DriveTypeId,DriveTypeEndId)
		VALUES
		(@Id,@Date,@Destination,@CostsSpecification,
		@Difference,@DistanceDFDS,@DistanceGpl,@DistanceGPS,
		@FinalGPSKM,@InitialGPSKM,@LoadingPlace,@PayedCosts,@Reason,@SettlementCosts,@TotalPayments,@Truck,@Vlaplan,
		@Vlaref,@WeightInTons,@Worker,@WorkerCosts,@LastUpdateByUser,@WorkerCostsPounds,@PayedCostsPounds
		,@SettlementCostsPounds,@TotalPaymentsPounds,@Trailer,@DriveStatus,@EstimatedConsumption,GetDate(),@DriveType,@DriveTypeEnd)
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
			DriveStatus = @DriveStatus,
			EstimatedConsumption = @EstimatedConsumption,
			DriveTypeId = @DriveType,
			DriveTypeEndId = @DriveTypeEnd
			WHERE Id = @Id
	END