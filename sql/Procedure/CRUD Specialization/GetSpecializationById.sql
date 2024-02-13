GO
CREATE PROCEDURE GetSpecializationById 
@Id int 
AS
BEGIN
SELECT [Specialization].Id, [Specialization].Name, [Specialization].IsDeleted
FROM [Specialization]
WHERE [Specialization].Id=@Id
END