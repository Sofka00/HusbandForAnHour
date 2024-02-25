GO
CREATE PROCEDURE GetAllSpecialization AS
BEGIN
SELECT [Id]
      ,[Name]
      ,[IsDeleted]
  FROM Specialization
  END