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

CREATE PROCEDURE SelectRequestWorkerByRequest
	@IdRequest int

AS
BEGIN
    SELECT * FROM RequestWorker Where RequestWorker.IdRequest=@IdRequest;
END;
GO

CREATE PROCEDURE SelectRequestWorkerByWorker
	@IdWorker int

AS
BEGIN
    SELECT * FROM RequestWorker Where RequestWorker.IdWorker=@IdWorker;
END;
GO
