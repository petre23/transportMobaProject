CREATE PROCEDURE [dbo].[GetDriveTypes]
AS
BEGIN
	SELECT dt.Id,
		dt.TypeName
	FROM dbo.DriveType dt
END