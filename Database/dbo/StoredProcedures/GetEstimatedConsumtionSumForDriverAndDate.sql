CREATE PROCEDURE [dbo].[GetEstimatedConsumtionSumForDriverAndDate]
	@DriverId UNIQUEIDENTIFIER = NULL,
	@Date DATETIME = NULL
AS
BEGIN
	SELECT SUM(d.EstimatedConsumption) TotalEstimatedConsumption FROM dbo.Drive d WHERE Worker = @DriverId AND [Date] = @Date
END