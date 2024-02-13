GO
CREATE PROCEDURE GetStatusById 
@Id int 
AS
BEGIN
SELECT [Status].Id, [Status].Name, [Status].IsDeleted
FROM [Status]
WHERE [Status].Id=@Id
END