CREATE PROCEDURE CreateUser
	@RoleId int,
	@FirstName nvarchar(255),
	@SecondName nvarchar(255),
	@Phone BIGINT,
	@SpecializationId int
AS
BEGIN
	INSERT INTO [User] (RoleId, FirstName, SecondName, Phone, SpecializationId, IsDeleted)
	VALUES (@RoleId, @FirstName, @SecondName, @Phone, @SpecializationId, 0)
END
GO

CREATE PROCEDURE GetUser
	@Id BIGINT
AS
BEGIN
	SELECT * FROM [User] WHERE Id = @Id
END
GO

CREATE PROCEDURE UpdateUser
	@Id BIGINT,
	@RoleId int,
	@FirstName nvarchar(255),
	@SecondName nvarchar(255),
	@Phone BIGINT,
	@SpecializationId int
AS
BEGIN
	UPDATE [User]
	SET RoleId = @RoleId, FirstName = @FirstName, SecondName = @SecondName, Phone = @Phone, SpecializationId = @SpecializationId
	WHERE Id = @Id AND IsDeleted = 0
END
GO

CREATE PROCEDURE DeleteUser
	@Id BIGINT
AS
BEGIN
	UPDATE [User]
	SET IsDeleted = 1
	WHERE Id = @Id
END
GO

CREATE PROCEDURE RestoreUser
	@Id BIGINT
AS
BEGIN
	UPDATE [User]
	SET IsDeleted = 0
	WHERE Id = @Id
END
GO
