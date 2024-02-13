GO
CREATE PROCEDURE CreateStatus
@Id INT,
@Name NVARCHAR

AS
BEGIN 
INSERT INTO STATUS (Id, Name, IsDeleted)
VALUES(@Id, @Name, 0)
END
