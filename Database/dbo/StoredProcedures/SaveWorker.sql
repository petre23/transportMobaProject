CREATE PROCEDURE [dbo].[SaveWorker]
	@IsNew bit = 1,
	@Id Uniqueidentifier,
	@FirstName nvarchar(255),
	@Surname nvarchar(255),
	@BirthDay DATETIME NULL,
	@IdentityDocument nvarchar(255) NULL,
	@CertificateExpirationDate DATETIME NULL,
	@DrivingLicenseExpirationDate DATETIME NULL,
	@EmploymentDate DATETIME NULL,
	@MedicalTestsExpirationDate DATETIME NULL,
	@TachographCardExpirationDate DATETIME NULL,
	@Employer Uniqueidentifier,
	@Truck Uniqueidentifier NULL,
	@CNP nvarchar(255) NULL
AS
BEGIN
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Worker(Id,FirstName,Surname,BirthDay,IdentityDocument,CertificateExpirationDate,DrivingLicenseExpirationDate,EmploymentDate,MedicalTestsExpirationDate,TachographCardExpirationDate,Employer,Truck,CNP) VALUES
		(
			@Id,
			@FirstName,
			@Surname,
			@BirthDay,
			@IdentityDocument,
			@CertificateExpirationDate,
			@DrivingLicenseExpirationDate,
			@EmploymentDate,
			@MedicalTestsExpirationDate,
			@TachographCardExpirationDate,
			@Employer,
			@Truck,
			@CNP
		)
	END
	ELSE
	BEGIN
		UPDATE dbo.Worker SET
			FirstName = @FirstName,
			Surname = @Surname,
			BirthDay = @BirthDay,
			IdentityDocument = @IdentityDocument,
			CertificateExpirationDate = @CertificateExpirationDate,
			DrivingLicenseExpirationDate = @DrivingLicenseExpirationDate,
			EmploymentDate = @EmploymentDate,
			MedicalTestsExpirationDate = @MedicalTestsExpirationDate,
			TachographCardExpirationDate = @TachographCardExpirationDate,
			Employer = @Employer,
			Truck = @Truck,
			CNP = @CNP
			WHERE Id = @Id
	END
END

