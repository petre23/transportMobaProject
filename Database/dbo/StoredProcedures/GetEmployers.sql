CREATE PROCEDURE [dbo].[GetEmployers]
AS
BEGIN
	SELECT e.Id,e.[Name],e.[Value] FROM dbo.Employers e
END