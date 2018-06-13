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
	[LastUpdateByUser] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT FK_DRIVE_WORKER FOREIGN KEY (Worker) REFERENCES dbo.Worker (Id),
	CONSTRAINT FK_DRIVE_Truck FOREIGN KEY (Truck) REFERENCES dbo.Trucks (Id),
	CONSTRAINT FK_DRIVE_User FOREIGN KEY (LastUpdateByUser) REFERENCES dbo.Users (Id)
)
