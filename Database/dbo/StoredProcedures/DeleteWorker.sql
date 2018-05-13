CREATE PROCEDURE [dbo].[DeleteWorker]
	@WorkerId Uniqueidentifier
AS
BEGIN
	IF EXISTS(SELECT TOP 1 * FROM dbo.Worker WHERE Id = @WorkerId)
	BEGIN
		DELETE FROM dbo.Worker WHERE Id = @WorkerId
	END
END
