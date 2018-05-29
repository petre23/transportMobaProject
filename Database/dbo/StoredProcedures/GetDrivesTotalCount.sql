CREATE PROCEDURE [dbo].[GetDrivesTotalCount]
AS
BEGIN
	SELECT COUNT(Id) as TotalDrivesCount FROM dbo.Drive
END