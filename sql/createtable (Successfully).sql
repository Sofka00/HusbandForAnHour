CREATE TABLE [UserRole] (
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL

)
GO
CREATE TABLE [Specialization] (
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL


)
GO
CREATE TABLE [Status] (
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL

)
GO
CREATE TABLE [Service] (
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(255) NOT NULL,
	SpecializationId int REFERENCES Specialization (Id),
	IsDeleted bit NOT NULL

)
GO
CREATE TABLE [User] (
	Id BIGINT PRIMARY KEY NOT NULL,
	RoleId int REFERENCES UserRole (Id) NOT NULL,
	FirstName nvarchar(255) NOT NULL,
	SecondName nvarchar(255) NOT NULL,
	Phone BIGINT NOT NULL,
	IsDeleted bit NOT NULL

)
GO
CREATE TABLE [Request] (
	Id int PRIMARY KEY IDENTITY(1,1),
	ClientId BIGINT REFERENCES dbo.[User] (Id) NOT NULL,
	Date date NOT NULL,
	Address nvarchar(255) NOT NULL,
	StatusId int REFERENCES dbo.[Status] (Id)  NOT NULL,
	Comment nvarchar(255),
	IsDeleted BIT NOT NULL
)
GO
CREATE TABLE RequestWorker (
	IdRequest int REFERENCES dbo.[Request] (Id) NOT NULL,
	IdWorker BIGINT REFERENCES dbo.[User] (Id) NOT NULL,
)

GO
CREATE TABLE RequestService (
	IdRequest int REFERENCES dbo.[Request] (Id) NOT NULL,
	IdService int REFERENCES dbo.Service (Id) NOT NULL,
)
GO

CREATE TABLE UserSpecialization (
	IdUser BIGINT REFERENCES dbo.[User] (Id) NOT NULL,
	IdSpecialization int REFERENCES Specialization (Id) NOT NULL,
)
GO