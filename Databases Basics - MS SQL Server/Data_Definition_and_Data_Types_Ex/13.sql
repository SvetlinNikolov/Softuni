CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT  PRIMARY KEY,
DirectorName NVARCHAR (30) NOT NULL,
Notes TEXT
)

CREATE TABLE Genres(
Id INT  PRIMARY KEY,
GenreName NVARCHAR (30) NOT NULL,
Notes TEXT
)

CREATE TABLE Categories(
Id INT PRIMARY KEY,
CategoryName NVARCHAR (30) NOT NULL,
Notes TEXT
)

CREATE TABLE Movies(
Id INT  PRIMARY KEY,
Title NVARCHAR (30) NOT NULL,
DirectorId NVARCHAR(30) NOT NULL,
CopyrightYear DATETIME2 NOT NULL,
[Length] DECIMAL (15,2) NOT NULL,
GenreId NVARCHAR(30) NOT NULL,
CategoryId NVARCHAR(30) NOT NULL,
Rating SMALLINT,
Notes TEXT
)

INSERT INTO Directors(Id, DirectorName, Notes) VALUES
(1, 'ASD', NULL),
(2, 'ASSD', NULL),
(3, 'ASSAD', NULL),
(4, 'ASASDD', NULL),
(5, 'ADASDSD', NULL)

INSERT INTO Genres(Id, GenreName, Notes) VALUES
(1, 'ASD', NULL),
(2, 'ASSD', NULL),
(3, 'ASSAD', NULL),
(4, 'ASASDD', NULL),
(5, 'ADASDSD', NULL)

INSERT INTO Categories(Id, CategoryName, Notes) VALUES
(1, 'ASD', NULL),
(2, 'ASSD', NULL),
(3, 'ASSAD', NULL),
(4, 'ASASDD', NULL),
(5, 'ADASDSD', NULL)

INSERT INTO Movies(Id, Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
(1, 'ASD', 'ASD', '10-10-2017', 12, 'asd', 'asd', 1, 'asd'),
(2, 'ASasdD', 'AasdSD', '10-10-2017', 12, 'asd', 'asd', 1, 'asd'),
(3, 'asdasd', 'AsssSD', '11-10-2017', 12, 'asd', 'asd', 1, 'asd'),
(4, 'AasdasdSD', 'AaAASD', '12-10-2017', 12, 'asd', 'asd', 1, 'asd'),
(5, 'AAAASD', 'ASSSSAD', '11-10-2014', 12, 'asd', 'asd', 1, 'asd')