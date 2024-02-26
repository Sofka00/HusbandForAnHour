CREATE PROCEDURE CreateUserRole
	@Name nvarchar(255)
AS
BEGIN
	INSERT INTO UserRole (Name, IsDeleted)
	VALUES (@Name, 0)
END
GO

CREATE PROCEDURE GetUserRole
	@Id int
AS
BEGIN
	SELECT * FROM UserRole WHERE Id = @Id
END
GO

CREATE PROCEDURE UpdateUserRole
	@Id int,
	@Name nvarchar(255)
AS
BEGIN
	UPDATE UserRole
	SET Name = @Name
	WHERE Id = @Id
END
GO

CREATE PROCEDURE DeleteUserRole
	@Id int
AS
BEGIN
	UPDATE UserRole
	SET IsDeleted = 1
	WHERE Id = @Id
END
GO

CREATE PROCEDURE RestoreUserRole
	@Id int
AS
BEGIN
	UPDATE UserRole
	SET IsDeleted = 0
	WHERE Id = @Id
END
GO

CREATE PROCEDURE GetAllUserRole
AS
BEGIN
	SELECT * FROM UserRole WHERE IsDeleted = 0
END
GO
