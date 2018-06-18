CREATE PROCEDURE [dbo].[GetDriveStatuses]
AS
BEGIN
	SELECT ds.Id,ds.Status FROM dbo.DriveStatus ds
END
