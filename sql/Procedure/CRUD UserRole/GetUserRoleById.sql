GO
CREATE PROCEDURE GetUserRoleById 
@Id int 
AS
BEGIN
SELECT [UserRole].Id, [UserRole].Name
FROM [UserRole]
WHERE [UserRole].Id=@Id
END