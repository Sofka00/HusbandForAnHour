GO
CREATE PROCEDURE UpdateSRequest
@Id INT,
@WorkerId INT,
@ClientId INT,
@ServicesId INT,
@Date DATE,
@Address NVARCHAR(255),
@StatusId INT,
@Comment NVARCHAR(255)

AS
BEGIN 
UPDATE Request
SET WorkerId=@WorkerId, ClientId=@ClientId, ServicesId=@ServicesId, Date=@Date, Address=@Address, StatusId=@StatusId, Comment=@Comment 
WHERE Id=@Id
END