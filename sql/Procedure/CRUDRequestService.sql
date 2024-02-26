CREATE PROCEDURE CreateRequsetService
	@IdRequest int,
	@IdService int
AS
BEGIN
	INSERT INTO RequsetService(IdRequest, IdService)
	VALUES (@IdRequest, @IdService)
END
GO

CREATE PROCEDURE DeleteRequsetService
	@IdRequest int
AS
BEGIN
	DELETE FROM RequsetService WHERE IdRequest = @IdRequest
END
GO