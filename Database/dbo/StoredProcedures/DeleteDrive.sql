CREATE PROCEDURE [dbo].[DeleteDrive]
	@DriveId uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.Drive where Id = @DriveId
END
