CREATE PROCEDURE CreateStatus
	@Name nvarchar(255)
AS
BEGIN
	INSERT INTO Status (Name, IsDeleted)
	VALUES (@Name, 0)
END
GO

CREATE PROCEDURE GetStatus
	@Id int
AS
BEGIN
	SELECT * FROM Status WHERE Id = @Id AND IsDeleted = 0
END
GO

CREATE PROCEDURE UpdateStatus
	@Id int,
	@Name nvarchar(255)
AS
BEGIN
	UPDATE Status
	SET Name = @Name
	WHERE Id = @Id AND IsDeleted = 0
END
GO

CREATE PROCEDURE DeleteStatus
	@Id int
AS
BEGIN
	UPDATE Status
	SET IsDeleted = 1
	WHERE Id = @Id
END
GO

CREATE PROCEDURE RestoreStatus
	@Id int
AS
BEGIN
	UPDATE Status
	SET IsDeleted = 0
	WHERE Id = @Id
END
GO
