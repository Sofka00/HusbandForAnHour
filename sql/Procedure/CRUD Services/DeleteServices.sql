GO
CREATE PROCEDURE DeleteServices
@Id INT
AS
BEGIN 
UPDATE Services
SET  IsDeleted=1
WHERE Id=@Id
END