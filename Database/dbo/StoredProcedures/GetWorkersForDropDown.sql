CREATE PROCEDURE [dbo].[GetWorkersForDropDown]
AS
BEGIN
	SELECT w.Id,w.FirstName,w.Surname,w.Truck
	FROM dbo.Worker w
END