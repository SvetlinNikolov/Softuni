CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
Password VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT NOT NULL 
FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id),

ContributorId INT NOT NULL 
FOREIGN KEY (ContributorId) REFERENCES Users(Id)

 CONSTRAINT pk_myConstraint PRIMARY KEY (RepositoryId,ContributorId)
)

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(255) NOT NULL, --I DO NOT KNOW ABOUT 255
IssueStatus CHAR(6) NOT NULL,

RepositoryId INT NOT NULL
FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id),

AssigneeId INT NOT NULL
FOREIGN KEY (AssigneeId) REFERENCES Users(Id) --COULD BE WRONG :(
)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY,
[Message] VARCHAR(255) NOT NULL,

IssueId INT 
FOREIGN KEY (IssueId) REFERENCES Issues(Id),

RepositoryId INT NOT NULL
FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id),

ContributorId INT  NOT NULL 
FOREIGN KEY (ContributorId) REFERENCES Users(Id)  --COULD BE WRONG :(
)

CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL (15, 2) NOT NULL,

ParentId INT 
FOREIGN KEY (ParentId) REFERENCES Files(Id),

CommitId INT NOT NULL 
FOREIGN KEY (CommitId) REFERENCES Commits(Id)
)

--2
INSERT INTO Files(Name, Size, ParentId, CommitId) VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

--3
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--4
DELETE 
FROM RepositoriesContributors
WHERE RepositoryId IN (
			SELECT Id FROM Repositories
			WHERE [Name] = 'Softuni-Teamwork'
			)
		
		DELETE FROM ISSUES
		WHERE RepositoryId =3

		--5
SELECT Id, Message, RepositoryId, ContributorId
FROM Commits
ORDER BY Id, Message, RepositoryId, ContributorId

--6
SELECT f.Id, f.Name, f.Size
FROM Files AS f
WHERE f.Size >1000 AND f.Name LIKE ('%html%')
ORDER BY f.Size DESC, f.Id ASC, f.Name ASC

--7
SELECT i.Id, CONCAT(u.Username, ' : ', i.Title)
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.id
ORDER BY i.Id DESC, u.Username ASC

--8
 SELECT p.Id,
       p.[Name],
       CONCAT(p.Size, 'KB') AS Size
FROM Files AS p
LEFT JOIN Files AS f ON f.ParentId = p.Id
WHERE f.Id IS NULL
ORDER BY p.Id, p.[Name], p.Size

 --9
 SELECT   TOP (5) r.Id, r.Name, COUNT(r.name) AS [Commits]
FROM Commits AS c
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = c.RepositoryId
JOIN Repositories AS r ON r.Id = rc.RepositoryId
GROUP BY r.Id, r.Name
ORDER BY [Commits] DESC, r.Id ASC, r.Name ASC

--10
SELECT u.Username, AVG(f.Size) AS [Size]
FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY [Size] DESC, u.Username ASC

--11
CREATE  FUNCTION udf_UserTotalCommits(@username VARCHAR(30))
RETURNS INT
AS 
BEGIN
	DECLARE @commits INT =
	(SELECT TOP(1) COUNT(*)
	FROM Commits AS c
	JOIN Users AS u ON c.ContributorId = u.Id
	WHERE u.Username = @username )

RETURN @commits
END

--12
CREATE OR ALTER PROC usp_FindByExtension(@extension VARCHAR(30))
AS 
BEGIN
SELECT f.Id, f.Name, CONCAT(f.Size, 'KB') AS [Size]
FROM Files AS f
WHERE RIGHT(f.Name, LEN(@extension)) = @extension
ORDER BY f.id, f.Name, f.Size DESC
END

EXEC usp_FindByExtension 'txt'