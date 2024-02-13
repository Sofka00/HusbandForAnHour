GO
CREATE PROCEDURE GetUserById 
@Id int 
AS
BEGIN
SELECT [User].Id, [User].FirstName, [User].SecondName, [User].Phone, [User].SpecializationId, [User].RoleId, [User].IsDeleted
FROM [User]
WHERE [User].Id=@Id
END

