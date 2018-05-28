CREATE PROCEDURE [dbo].[DeleteUser]
	@UserId uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.Users where Id = @UserId
END
