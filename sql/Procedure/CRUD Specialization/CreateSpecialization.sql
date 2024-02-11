GO
CREATE PROCEDURE CreateSpecialization
@Id INT,
@Name NVARCHAR
AS
BEGIN 
INSERT INTO Specialization (Id, Name, IsDeleted)
VALUES(@Id, @Name, 0)
END
