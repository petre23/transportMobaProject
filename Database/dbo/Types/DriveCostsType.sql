CREATE TYPE dbo.DriveCostsType AS TABLE
(
	Id UNIQUEIDENTIFIER,
	CostEuro decimal(12,2),
	CostPounds decimal(12,2),
	Drive UNIQUEIDENTIFIER
)