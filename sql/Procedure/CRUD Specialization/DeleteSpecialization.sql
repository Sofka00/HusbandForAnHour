GO
CREATE PROCEDURE DeleteSpecialization
@Id INT
AS
BEGIN 
UPDATE Specialization
SET  IsDeleted=1
WHERE Id=@Id
END