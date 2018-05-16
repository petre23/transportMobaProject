CREATE TABLE [dbo].[Trucks]
(
	[Id] Uniqueidentifier NOT NULL,
	[RegistrationNumber] nvarchar(255) NOT NULL,
	[Brand] Uniqueidentifier NOT NULL,
	[ManufacturingYear] DATETIME NULL,
	[ITPExpirationDate] DATETIME NULL,
	[InsuranceExpirationDate] DATETIME NULL,
	[TachographExpirationDate] DATETIME NULL,
	[VignetteExpirationDateUK] DATETIME NULL,
	[VignetteExpirationDateNL] DATETIME NULL,
	[ConformCopyExpirationDate] DATETIME NULL,
	PRIMARY KEY([Id]),
	CONSTRAINT FK_TRUCKS_BRANDS FOREIGN KEY (Brand) REFERENCES dbo.Brands (Id)
)
