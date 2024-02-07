CREATE TABLE [UserRole] (
	Id int NOT NULL,
	Name nvarchar(255) NOT NULL,
  CONSTRAINT [PK_USERROLE] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Specialization] (
	Id int NOT NULL,
	Name nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_SPECIALIZATION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Status] (
	Id int NOT NULL,
	Name nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_STATUS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Services] (
	Id int NOT NULL,
	Name nvarchar(255) NOT NULL,
	SpecializationId int REFERENCES Specialization (Id),
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_SERVICES] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [User] (
	Id int NOT NULL,
	RoleId int REFERENCES UserRole (Id) NOT NULL,
	FirstName nvarchar(255) NOT NULL,
	SecondName nvarchar(255) NOT NULL,
	Phone int,
	SpecializationId int REFERENCES Specialization (Id),
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Request] (
	Id int NOT NULL,
	WorkerId int REFERENCES dbo.[User] (Id) NOT NULL,
	ClientId int REFERENCES dbo.[User] (Id) NOT NULL,
	ServicesId int NOT NULL,
	Date date NOT NULL,
	Address nvarchar(255) NOT NULL,
	StatusId int NOT NULL,
	Comment nvarchar(255),
  CONSTRAINT [PK_REQUEST] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO