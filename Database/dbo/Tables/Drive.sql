﻿CREATE TABLE [dbo].[Drive]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Worker] UNIQUEIDENTIFIER NULL,
	[Truck] UNIQUEIDENTIFIER NULL,
	[Date] DATETIME NULL,
	[Vlaplan] nvarchar(255) NULL,
	[Vlaref] nvarchar(255) NULL,
	[LoadingPlace] nvarchar(255) NULL,
	[Destination] nvarchar(255) NULL,
	[InitialGPSKM] decimal(12,2) NULL,
	[FinalGPSKM] decimal(12,2) NULL,
	[DistanceGPS] decimal(12,2) NULL,
	[DistanceGpl] decimal(12,2) NULL,
	[DistanceDFDS] decimal(12,2) NULL,
	[Difference] decimal(12,2) NULL,
	[Reason] nvarchar(MAX) NULL,
	[WeightInTons] decimal(12,2) NULL,
	[WorkerCosts] decimal(18,3) NULL,
	[WorkerCostsPounds] decimal(18,3) NULL,
	[CostsSpecification] nvarchar(MAX) NULL,
	[PayedCosts] decimal(18,3) NULL,
	[PayedCostsPounds] decimal(18,3) NULL,
	[SettlementCosts] decimal(18,3) NULL,
	[SettlementCostsPounds] decimal(18,3) NULL,
	[TotalPayments] decimal(18,3) NULL,
	[TotalPaymentsPounds] decimal(18,3) NULL,
	[LastUpdateByUser] UNIQUEIDENTIFIER NOT NULL,
	[Trailer] NVARCHAR(255) NULL,
	[DriveStatus] UNIQUEIDENTIFIER NULL,
	[EstimatedConsumption] decimal(12,2) NULL,
	CONSTRAINT FK_DRIVE_WORKER FOREIGN KEY (Worker) REFERENCES dbo.Worker (Id),
	CONSTRAINT FK_DRIVE_Truck FOREIGN KEY (Truck) REFERENCES dbo.Trucks (Id),
	CONSTRAINT FK_DRIVE_User FOREIGN KEY (LastUpdateByUser) REFERENCES dbo.Users (Id),
	CONSTRAINT FK_DRIVE_DriveStatus FOREIGN KEY (DriveStatus) REFERENCES dbo.DriveStatus (Id)
)
