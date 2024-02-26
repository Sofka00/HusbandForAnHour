
CREATE PROCEDURE CreateRequest
@ClientId BIGINT,
@Date  DATE,
@Address NVARCHAR(255),
@StatusId INT,
@Comment NVARCHAR(255) 
AS
BEGIN 
INSERT INTO Request(ClientId, Date, Address, StatusId, Comment, IsDeleted)
VALUES(@ClientId, @Date, @Address, @StatusId, @Comment, 0)
END

GO
CREATE PROCEDURE DeleteRequest
@Id INT
AS
BEGIN
UPDATE Request
SET IsDeleted=1 
WHERE Id=@Id
END

GO
CREATE PROCEDURE RestoreRequest
@Id INT
AS
BEGIN
UPDATE Request
SET IsDeleted=0 
WHERE Id=@Id
END

GO
CREATE PROCEDURE GetRequest
@Id int 
AS
BEGIN
SELECT *
FROM [Request]
WHERE [Request].Id=@Id
END

GOCREATE PROCEDURE GetAllRequestByStatus
@StatusId int 
AS
BEGIN
SELECT *
FROM [Request]
WHERE [Request].StatusId=@StatusId
END

GO
CREATE PROCEDURE GetRequestByClient 
@Id BIGINT 
AS
BEGIN
SELECT *
FROM [Request]
WHERE [Request].ClientId=@Id
END

GO
CREATE PROCEDURE UpdateRequest
@Id INT,
@ClientId BIGINT,
@Date DATE,
@Address NVARCHAR(255),
@StatusId INT,
@Comment NVARCHAR(255)

AS
BEGIN 
UPDATE Request
SET ClientId=@ClientId, Date=@Date, Address=@Address, StatusId=@StatusId, Comment=@Comment 
WHERE Id=@Id AND IsDeleted = 0
END