CREATE PROCEDURE [dbo].[SaveWorker]
	@IsNew bit = 1,
	@Id Uniqueidentifier,
	@FirstName nvarchar(255),
	@Surname nvarchar(255),
	@BirthDay DATETIME,
	@IdentityDocument nvarchar(255),
	@CertificateExpirationDate DATETIME,
	@DrivingLicenseExpirationDate DATETIME,
	@EmploymentDate DATETIME,
	@MedicalTestsExpirationDate DATETIME,
	@TachographCardExpirationDate DATETIME,
	@Employer Uniqueidentifier,
	@Truck Uniqueidentifier
AS
BEGIN
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Worker(Id,FirstName,Surname,BirthDay,IdentityDocument,CertificateExpirationDate,DrivingLicenseExpirationDate,EmploymentDate,MedicalTestsExpirationDate,TachographCardExpirationDate,Employer,Truck) VALUES
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
			@Truck
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
			Truck = @Truck
			WHERE Id = @Id
	END
END

