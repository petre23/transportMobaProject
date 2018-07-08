CREATE TABLE [dbo].[Worker]
(
	[Id] Uniqueidentifier NOT NULL,
	[FirstName] nvarchar(255) NOT NULL,
	[Surname] nvarchar(255) NOT NULL,
	[BirthDay] DATETIME NULL,
	[Employer] Uniqueidentifier NOT NULL,
	[Truck] Uniqueidentifier NULL,
	[EmploymentDate] DATETIME NULL,
	[IdentityDocument] nvarchar(255) NULL,
	[DrivingLicenseExpirationDate] DATETIME NULL,
	[TachographCardExpirationDate] DATETIME NULL,
	[CertificateExpirationDate] DATETIME NULL,
	[MedicalTestsExpirationDate] DATETIME NULL,
	[CNP] nvarchar(255) NULL,
	PRIMARY KEY([Id]),
	CONSTRAINT FK_WORKER_EMPLOYERS FOREIGN KEY ([Employer]) REFERENCES dbo.[Employers] (Id)
)
