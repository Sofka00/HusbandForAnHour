GO
CREATE PROCEDURE GetAllRequest as
BEGIN
SELECT Request.Id, [User].FirstName, [User].SecondName, Request.Date, Request.Address, [User].Phone, Status.Name
FROM Request, [User], Status
WHERE [User].RoleId= 2 and [User].Id=Request.ClientId and Status.Id = Request.StatusId
END