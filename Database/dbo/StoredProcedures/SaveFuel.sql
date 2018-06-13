CREATE PROCEDURE [dbo].[SaveFuel]
	@IsNew bit = 1,
	@Id UNIQUEIDENTIFIER,
	@Worker UNIQUEIDENTIFIER,
	@AdblueLiters decimal(12,2) = null,
	@AdblueValue decimal(12,2) = null,
	@DieselValue decimal(12,3) = null,
	@EstimatedConsumption decimal(12,2),
	@FueledDieseKMLiters decimal(12,2) = null,
	@GPSConsumption decimal(12,2) = null,
	@GPSFinalConsumption decimal(12,2) = null,
	@GPSInitialConsumption decimal(12,2),
	@RealConsumption decimal(12,2) = null,
	@FueledKM decimal(12,2) = null,
	@Date datetime
AS
BEGIN
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Fuel(
			Id,
			Worker,
			AdblueLiters,
			AdblueValue,
			DieselValue,
			EstimatedConsumption,
			FueledDieseKMLiters,
			FueledKM,
			GPSConsumption,
			GPSFinalConsumption,
			GPSInitialConsumption,
			RealConsumption,
			Date)
		VALUES(
			@Id,
			@Worker,
			@AdblueLiters,
			@AdblueValue,
			@DieselValue,
			@EstimatedConsumption,
			@FueledDieseKMLiters,
			@FueledKM,
			@GPSConsumption,
			@GPSFinalConsumption,
			@GPSInitialConsumption,
			@RealConsumption,
			@Date)
	END
	ELSE
	BEGIN
		UPDATE dbo.Fuel SET
			Worker = @Worker,
			AdblueLiters = @AdblueLiters,
		    AdblueValue =@AdblueValue,
			DieselValue = @DieselValue,
			EstimatedConsumption = @EstimatedConsumption,
			FueledDieseKMLiters = @FueledDieseKMLiters,
			FueledKM = @FueledKM,
			GPSFinalConsumption = @GPSFinalConsumption,
			GPSConsumption = @GPSConsumption,
			GPSInitialConsumption = @GPSInitialConsumption,
			RealConsumption = @RealConsumption,
			Date = @Date
			WHERE Id = @Id
	END
END