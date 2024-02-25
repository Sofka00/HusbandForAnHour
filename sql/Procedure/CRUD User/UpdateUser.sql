GO
CREATE PROCEDURE UpdateUser
@Id INT,
@RoleId INT,
@FirstName NVARCHAR(255),
@SecondName NVARCHAR(255),
@Phone BIGINT,
@SpecializationId INT
AS
BEGIN 
UPDATE [User] 
SET  RoleId = @RoleId , FirstName =@FirstName,SecondName=@SecondName,Phone = @Phone,SpecializationId= @SpecializationId, IsDeleted=0
WHERE Id=@Id
END




