CREATE TABLE [dbo].[Fuel]
(
	[Id] Uniqueidentifier NOT NULL PRIMARY KEY,
	[Worker] Uniqueidentifier NOT NULL,
	[Truck] UNIQUEIDENTIFIER NULL,
	[GPSInitialConsumption] decimal(12,2) NULL,
	[GPSFinalConsumption] decimal(12,2) NULL,
	[GPSConsumption] decimal(12,2) NULL,
	[EstimatedConsumption] decimal(12,2) NULL,
	[FueledKM] decimal(12,2) NULL,
	[FueledDieseKMLiters] decimal(12,2) NULL,
	[DieselValue] decimal(12,3) NULL,
	[RealConsumption] decimal(12,2) NULL,
	[AdblueLiters] decimal(12,2) NULL,
	[AdblueValue] decimal(12,2) NULL,
	[Date] Datetime NOT NULL,
	[DistanceGPS] decimal(12,2) NULL,
	CONSTRAINT FK_FUEL_WORKER FOREIGN KEY (Worker) REFERENCES dbo.Worker (Id),
	CONSTRAINT FK_FUEL_Truck FOREIGN KEY (Truck) REFERENCES dbo.Trucks (Id)
)
