CREATE PROCEDURE CreateSpecialization
	@Name nvarchar(255)
AS
BEGIN
	INSERT INTO Specialization (Name, IsDeleted)
	VALUES (@Name, 0)
END
GO

CREATE PROCEDURE GetSpecialization
	@Id int
AS
BEGIN
	SELECT * FROM Specialization WHERE Id = @Id
END
GO

CREATE PROCEDURE UpdateSpecialization
	@Id int,
	@Name nvarchar(255)
AS
BEGIN
	UPDATE Specialization
	SET Name = @Name
	WHERE Id = @Id
END
GO

CREATE PROCEDURE DeleteSpecialization
	@Id int
AS
BEGIN
	UPDATE Specialization
	SET IsDeleted = 1
	WHERE Id = @Id
END
GO

CREATE PROCEDURE RestoreSpecialization
	@Id int
AS
BEGIN
	UPDATE Specialization
	SET IsDeleted = 0
	WHERE Id = @Id
END
GO

CREATE PROCEDURE GetAllSpecialization
AS
BEGIN
	SELECT * FROM Specialization WHERE IsDeleted = 0
END
GO