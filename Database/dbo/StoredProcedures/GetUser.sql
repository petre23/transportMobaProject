CREATE PROCEDURE [dbo].[GetUser]
	@UserId uniqueidentifier
AS
BEGIN
		SELECT  u.Id,
			u.Username,
			u.Password,
			u.HasAdminRole,
			u.FirstName,
			u.SurName
			FROM dbo.Users u
			WHERE u.Id = @UserId
END
