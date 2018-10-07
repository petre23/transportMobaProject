CREATE PROCEDURE [dbo].[GetDriveCostsByDriveId]
	@DriveId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT dc.Id,
		   dc.CostEuro,
		   dc.CostPounds,
		   dc.Drive,
		   Specifications
	FROM dbo.DriveCosts dc
	WHERE dc.Drive = @DriveId
END
