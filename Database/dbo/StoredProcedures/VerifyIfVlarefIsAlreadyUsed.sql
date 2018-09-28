CREATE PROCEDURE [dbo].[VerifyIfVlarefIsAlreadyUsed]
	@Vlaref nvarchar(255)
AS
BEGIN
	DECLARE @VlarefExists BIT = CASE WHEN (SELECT COUNT(1) FROM dbo.Drive where Vlaref = @Vlaref) > 0 THEN 1 ELSE 0 END
	SELECT @VlarefExists as VlarefExists;
END