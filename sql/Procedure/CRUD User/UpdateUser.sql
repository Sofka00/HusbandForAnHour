GO
CREATE PROCEDURE UpdateUser
@Id INT,
@RoleId INT,
@FirstName NVARCHAR(255),
@SecondName NVARCHAR(255),
@Phone INT,
@SpecializationId INT
AS
BEGIN 
UPDATE [User] 
SET  RoleId = @RoleId , FirstName =@FirstName,SecondName=@SecondName,Phone = @Phone,SpecializationId= @SpecializationId, IsDeleted=0
WHERE Id=@Id
END

exec UpdateUser 1,
@RoleId =2,
@FirstName= aaa,
@SecondName=eee,
@Phone=234,
@SpecializationId=3


