GO
CREATE PROCEDURE CreateRequest
@Id INT,
@WorkerId INT,
@ClientId INT,
@ServicesId INT,
@Date  DATE,
@Address NVARCHAR,
@StatusId INT,
@Comment NVARCHAR 
AS
BEGIN 
INSERT INTO Request(Id, WorkerId, ClientId, ServicesId, Date, Address, StatusId, Comment)
VALUES(@Id,@WorkerId , @ClientId, @ServicesId, @Date, @Address, @StatusId, @Comment)
END