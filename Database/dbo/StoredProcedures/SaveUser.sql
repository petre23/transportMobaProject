CREATE PROCEDURE [dbo].[SaveUser]
	@IsNew bit = 1,
	@Id uniqueidentifier,
	@UserName nvarchar(255),
	@FirstName nvarchar(255),
	@SurName nvarchar(255),
	@Password nvarchar(255),
	@HasAdminRole bit
AS
BEGIN
	IF(@IsNew = 1)
	BEGIN
		INSERT INTO dbo.Users VALUES
		(
			@Id,
			@UserName,
			@Password,
			@FirstName,
			@SurName,
			@HasAdminRole
		)
	END
	ELSE
	BEGIN
		UPDATE dbo.Users SET
				Username = @UserName,
				Password = @Password,
				FirstName = @FirstName,
				SurName = @SurName,
				HasAdminRole = @HasAdminRole
			WHERE Id = @Id
	END
END
