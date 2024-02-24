USE [HusbandOfAnHour]
GO
CREATE PROCEDURE GetAllServices AS
BEGIN
SELECT [Id]
      ,[Name]
      ,[SpecializationId]
      ,[IsDeleted]
  FROM Services
END;



