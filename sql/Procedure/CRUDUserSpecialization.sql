CREATE PROCEDURE CreateUserSpecialization
	@IdUser BIGINT,
	@IdService int
AS
BEGIN
	INSERT INTO RequsetService(IdRequest, IdService)
	VALUES (@IdRequest, @IdService)
END
GO

CREATE PROCEDURE DeleteUserSpecialization
	@IdUser BIGINT
AS
BEGIN
	DELETE FROM UserSpecialization WHERE UserSpecialization.IdUser = @IdUser
END
GO

CREATE PROCEDURE SelectUserSpecializationByUser
	@IdUser BIGINT

AS
BEGIN
    SELECT * FROM UserSpecialization Where UserSpecialization.IdUser=@IdUser;
END;
GO

CREATE PROCEDURE SelectUserSpecializationBySpecialization
	@IdSpecialization int

AS
BEGIN
    SELECT * FROM UserSpecialization Where UserSpecialization.IdSpecialization=@IdSpecialization;
END;
GO