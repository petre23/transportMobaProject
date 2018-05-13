CREATE PROCEDURE [dbo].[GetTrucksForDropDown]
AS
BEGIN
	SELECT t.Id,t.RegistrationNumber FROM dbo.Trucks t
END