GO
CREATE PROCEDURE CreateServices
@Id INT,
@Name NVARCHAR,
@SpecializationId INT
AS
BEGIN 
INSERT INTO Services (Id, Name, SpecializationId, IsDeleted)
VALUES(@Id, @Name, @SpecializationId, 0)
END
