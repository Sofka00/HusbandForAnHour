GO
CREATE PROCEDURE UpdateStatus
@Id INT,
@Name NVARCHAR(255)

AS
BEGIN 
UPDATE Status
SET Name = @Name, IsDeleted=0
WHERE Id=@Id
END