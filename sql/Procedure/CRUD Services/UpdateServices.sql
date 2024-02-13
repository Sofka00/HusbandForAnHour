GO
CREATE PROCEDURE UpdateServices
@Id INT,
@Name NVARCHAR(255),
@SpecializationId INT

AS
BEGIN 
UPDATE Services
SET Name = @Name, SpecializationId= @SpecializationId, IsDeleted=0
WHERE Id=@Id
END