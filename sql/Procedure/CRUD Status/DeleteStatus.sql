GO
CREATE PROCEDURE DeleteStatus
@Id INT
AS
BEGIN 
UPDATE Status
SET  IsDeleted=1
WHERE Id=@Id
END

