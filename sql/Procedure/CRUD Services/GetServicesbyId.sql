GO
CREATE PROCEDURE GetServicesById 
@Id int 
AS
BEGIN
SELECT [Services].Id, [Services].Name, [Services].SpecializationId, [Services].IsDeleted
FROM [Services]
WHERE [Services].Id=@Id
END