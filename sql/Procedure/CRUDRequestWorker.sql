CREATE PROCEDURE CreateRequestWorker
	@IdRequest int,
	@IdWorker BIGINT
AS
BEGIN
	INSERT INTO RequsetWorker (IdRequest, IdWorker)
	VALUES (@IdRequest, @IdWorker)
END
GO


CREATE PROCEDURE DeleteRequestWorker
	@IdRequest int
AS
BEGIN
	DELETE FROM RequestWorker WHERE IdRequest = @IdRequest
END
GO

