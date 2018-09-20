CREATE PROCEDURE [dbo].[SaveDriveCosts]
	@DriveCostsType DriveCostsType READONLY
AS
BEGIN
	MERGE dbo.DriveCosts AS dc
	USING @DriveCostsType AS dcs
	ON (dc.Id = dcs.Id AND dc.Drive = dcs.Drive)
	WHEN MATCHED 
		THEN
			UPDATE SET dc.CostEuro = dcs.CostEuro,
					   dc.CostPounds = dcs.CostPounds
	WHEN NOT MATCHED BY TARGET
		THEN
			INSERT(Id,CostEuro,CostPounds,Drive)
			VALUES(NEWID(),dcs.CostEuro,dcs.CostPounds,dcs.Drive)
	WHEN NOT MATCHED BY SOURCE
		THEN
			DELETE;
END