GO
CREATE PROCEDURE UpdateSpecialization
@Id INT,
@Name NVARCHAR(255)

AS
BEGIN 
UPDATE Specialization
SET Name = @Name, IsDeleted=0
WHERE Id=@Id
END