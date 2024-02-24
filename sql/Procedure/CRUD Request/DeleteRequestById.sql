GO
CREATE PROCEDURE DeleteRequestById
@Id INT
AS
BEGIN
DELETE FROM Request
WHERE Id = @Id
END



