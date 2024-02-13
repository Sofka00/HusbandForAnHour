GO
CREATE PROCEDURE GetAllRequest AS
BEGIN
SELECT Request.Id, [User].FirstName, Request.Date, Request.StatusId, Request.Address, [User].Phone
FROM Request, [User]
END

