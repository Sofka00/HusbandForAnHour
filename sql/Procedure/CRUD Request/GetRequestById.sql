GO
CREATE PROCEDURE GetRequestById 
@Id int 
AS
BEGIN
SELECT [Request].Id, [Request].WorkerId, [Request].ClientId, [Request].ServicesId, [Request].Date, [Request].Address, [Request].StatusId, [Request].Comment
FROM [Request]
WHERE [Request].Id=@Id
END