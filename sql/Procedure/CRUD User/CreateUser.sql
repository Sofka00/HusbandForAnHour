GO
CREATE PROCEDURE CreateSeUser
@Id INT,
@RoleId INT,
@FirstName NVARCHAR,
@SecondName NVARCHAR,
@Phone INT,
@SpecializationId INT
AS
BEGIN 
INSERT INTO [User] (Id, RoleId, FirstName, SecondName, Phone, SpecializationId, IsDeleted)
VALUES(@Id,@RoleId , @FirstName, @SecondName, @Phone, @SpecializationId, 0)
END