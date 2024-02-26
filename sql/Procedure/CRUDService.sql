
CREATE PROCEDURE CreateService
@Name NVARCHAR(255),
@SpecializationId INT
AS
BEGIN 
INSERT INTO Service ( Name, SpecializationId, IsDeleted)
VALUES( @Name, @SpecializationId, 0)
END
GO

CREATE PROCEDURE DeleteService
@Id INT
AS
BEGIN 
UPDATE Service
SET  IsDeleted=1
WHERE Id=@Id
END
GO

CREATE PROCEDURE RestoreService
@Id INT
AS
BEGIN
UPDATE Service
SET IsDeleted=0 
WHERE Id=@Id
END

GO
CREATE PROCEDURE GetService 
@Id INT 
AS
BEGIN
SELECT *
FROM [Service]
WHERE [Service].Id=@Id
END

GOCREATE PROCEDURE GetAllServices 
AS
BEGIN
SELECT *
FROM [Service]
END

GO
CREATE PROCEDURE GetServiceBySpecialization
@Id INT 
AS
BEGIN
SELECT *
FROM [Service]
WHERE [Service].SpecializationId=@Id
END

GO
CREATE PROCEDURE UpdateService
@Id INT,
@Name NVARCHAR(255),
@SpecializationId INT

AS
BEGIN 
UPDATE Services
SET Name = @Name, SpecializationId= @SpecializationId, IsDeleted=0
WHERE Id=@Id
END
GO