CREATE PROCEDURE GetClientsById
@Id int 
AS
BEGIN
select [User].Id, [User].FirstName, [User].SecondName, [User].Phone, Request.Address
from [User], Request
where [User].RoleId= 2 and [User].Id=@Id
END
 exec GetClientsById 12