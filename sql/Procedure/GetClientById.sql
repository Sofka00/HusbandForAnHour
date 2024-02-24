CREATE PROCEDURE GetClientById
@Id int 
AS
BEGIN
select [User].Id, [User].FirstName, [User].SecondName, [User].Phone, Request.Address
from [User], Request
where [User].RoleId= 2 and [User].Id=@Id and [User].Id=Request.ClientId
END
 
 exec GetClientById 10

