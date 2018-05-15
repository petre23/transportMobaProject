CREATE TABLE [dbo].[Worker]
(
	[Id] Uniqueidentifier NOT NULL,
	[FirstName] nvarchar(255) NOT NULL,
	[Surname] nvarchar(255) NOT NULL,
	[BirthDay] DATETIME NOT NULL,
	[Employer] Uniqueidentifier NOT NULL,
	[Truck] Uniqueidentifier NOT NULL,
	[EmploymentDate] DATETIME NOT NULL,
	[IdentityDocument] nvarchar(255) NOT NULL,
	[DrivingLicenseExpirationDate] DATETIME NOT NULL,
	[TachographCardExpirationDate] DATETIME NOT NULL,
	[CertificateExpirationDate] DATETIME NOT NULL,
	[MedicalTestsExpirationDate] DATETIME NOT NULL,
	[CNP] nvarchar(255) NOT NULL,
	PRIMARY KEY([Id]),
	CONSTRAINT FK_WORKER_EMPLOYERS FOREIGN KEY ([Employer]) REFERENCES dbo.[Employers] (Id)
)
