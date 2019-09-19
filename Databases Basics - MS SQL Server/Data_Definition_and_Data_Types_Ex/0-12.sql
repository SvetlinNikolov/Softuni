CREATE DATABASE Minions

CREATE TABLE Minions(
Id INT PRIMARY KEY,
Name NVARCHAR(30),
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
Name NVARCHAR(30),
)

ALTER TABLE Minions
Add TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionTownID
FOREIGN KEY (TownId) REFERENCES Towns(Id)

INSERT INTO Towns (Id, [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, [Name], Age, TownId) VALUES
(1,'Kevin',22, 1),
(2,'Bob',15, 3),
(3,'Steward',NULL, 2)

TRUNCATE TABLE Minions

DROP TABLE Minions

DROP TABLE Towns

CREATE TABLE People (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
Picture VARBINARY (MAX),
CHECK(DATALENGTH(Picture)<=2097152),
Height DECIMAL(3, 2),
[Weight] DECIMAL(3, 2),
Gender CHAR(1) NOT NULL CHECK(Gender='m' OR Gender='f'),
Birthdate DATE NOT NULL,
Biography TEXT NOT NULL
)

INSERT INTO People ([Name],Picture,Height,[Weight],Gender,Birthdate,Biography) VALUES
('WHY', 12, 1.00, 2.00, 'm', '1998-10-05', 'ARE YOU LIKE THIS')

CREATE TABLE Users (
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
CHECK(DATALENGTH(ProfilePicture)<=921600),
LastLoginTime DATETIME2,
IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('PEkkk', 'KAKMOJA321', 999, '1998-10-05', 0)

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07D4FACBA0;

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUserName
PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CHECK (Len([Password])>=5)

ALTER TABLE Users
ADD CONSTRAINT df_LastLoginTime
DEFAULT  GETDATE() FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUserName

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CHECK (Len(Username)>=3)


