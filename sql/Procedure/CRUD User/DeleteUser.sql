GO
CREATE PROCEDURE DeleteUser
@Id INT
AS
BEGIN 
UPDATE [User]
SET  IsDeleted=1
WHERE Id=@Id
END