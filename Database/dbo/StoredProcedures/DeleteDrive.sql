CREATE PROCEDURE [dbo].[DeleteDrive]
	@DriveId uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.DriveCosts where Drive = @DriveId
	DELETE FROM dbo.Drive where Id = @DriveId
END