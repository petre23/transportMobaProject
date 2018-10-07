CREATE PROCEDURE [dbo].[SaveDriveCosts]
	@DriveId UNIQUEIDENTIFIER,
	@DriveCostsType DriveCostsType READONLY
AS
BEGIN
	WITH cte as
	(
		SELECT dc.Id,
				dc.CostEuro,
				dc.CostPounds,
				dc.Drive,
				dc.Specifications
		FROM dbo.DriveCosts dc
		WHERE dc.Drive = @DriveId
	)

	MERGE cte AS dc
	USING @DriveCostsType AS dcs
	ON (dc.Id = dcs.Id AND dc.Drive = dcs.Drive)
	WHEN MATCHED 
		THEN
			UPDATE SET dc.CostEuro = dcs.CostEuro,
					   dc.CostPounds = dcs.CostPounds,
					   dc.Specifications = dcs.Specifications
	WHEN NOT MATCHED BY TARGET
		THEN
			INSERT(Id,CostEuro,CostPounds,Drive,Specifications)
			VALUES(NEWID(),dcs.CostEuro,dcs.CostPounds,dcs.Drive,dcs.Specifications)
	WHEN NOT MATCHED BY SOURCE
		THEN
			DELETE;
END
GO

