GO
CREATE PROCEDURE UpdateUserRole
@Id INT,
@Name NVARCHAR(255)

AS
BEGIN 
UPDATE UserRole
SET Name = @Name 
WHERE Id=@Id
END