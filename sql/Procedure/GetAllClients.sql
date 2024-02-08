

GO
CREATE PROCEDURE GetAllProduct AS
BEGIN
select [User].Id, [User].FirstName, [User].SecondName, [User].Phone, Request.Address
from [User], Request
where [User].RoleId= 2
END


