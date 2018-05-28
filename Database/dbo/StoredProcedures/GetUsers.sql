CREATE PROCEDURE [dbo].[GetUsers]
AS
BEGIN
	SELECT  u.Id,
			u.Username,
			u.Password,
			u.HasAdminRole,
			u.FirstName,
			u.SurName
			FROM dbo.Users u 
END
