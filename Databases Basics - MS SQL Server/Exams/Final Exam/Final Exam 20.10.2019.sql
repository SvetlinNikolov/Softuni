CREATE DATABASE Service

USE Service

--1
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL, -- NEVER TYPED UNIQUE BEFORE
Password VARCHAR(50) NOT NULL,
Name VARCHAR(50),
Birthdate DATETIME,
Age INT 
CHECK (Age BETWEEN 14 AND 110),  
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
BirthDate DATETIME,
Age INT 
CHECK (Age BETWEEN 18 AND 110),

DepartmentId INT 
FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL,

DepartmentId INT NOT NULL
FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE Status(
Id INT PRIMARY KEY IDENTITY,
Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,

CategoryId INT NOT NULL
FOREIGN KEY (CategoryId) REFERENCES Categories(Id),

StatusId INT FOREIGN KEY (StatusId) REFERENCES Status(Id),

OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
Description VARCHAR(200) NOT NULL,

UserId INT NOT NULL
FOREIGN KEY (UserId) REFERENCES Users(Id),

EmployeeId INT 
FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
)

--2
INSERT INTO Employees(FirstName, LastName, BirthDate, DepartmentId)VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna',	'Amati',	'1959-07-20',	5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId)VALUES
(1,	1,	'2017-04-13', NULL,  'Stuck Road on Str.133', 6, 2),
(6,	3,	'2015-09-05', '2015-12-06',  'Charity trail running', 3, 5),
(14, 2,	'2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3,	'2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)


--3
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--4
DELETE FROM Reports
WHERE StatusId = 4

--5
SELECT Description,  FORMAT (OpenDate, 'dd-MM-yyyy') 
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, Description ASC

--6
SELECT Description, Name
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
ORDER BY r.Description, c.Name

--7
SELECT  TOP (5)c.Name AS [CategoryName], COUNT(r.Id) AS [ReportsNumber]
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY r.CategoryId, c.Name
ORDER BY ReportsNumber DESC, c.Name ASC

--8
SELECT U.Username, C.Name
FROM Users AS u
JOIN Reports AS r ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
	AND  DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate)
ORDER BY u.Username, c.Name

--9
SELECT CONCAT(e.FirstName,' ', e.LastName) AS [FullName], COUNT(u.id) AS [UsersCount]
FROM Users AS u
JOIN Reports AS r ON u.Id = r.UserId
RIGHT JOIN Employees AS e ON e.Id = r.EmployeeId
GROUP BY e.FirstName, e.LastName
ORDER BY [UsersCount] desc, FullName ASC

--10
SELECT IIF(e.firstName IS NULL,
'None',  CONCAT(e.firstName, ' ', e.LastName)) AS [Employee],
ISNULL(d.Name, 'None') AS [Department], ISNULL(c.Name, 'None'), ISNULL(r.Description, 'None'),
ISNULL(FORMAT (r.OpenDate, 'dd.MM.yyyy'), 'None') AS [OpenDate], ISNULL(s.Label, 'None'),
ISNULL(u.Name, 'None') AS [User]
FROM Reports AS r

LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
RIGHT JOIN Categories AS c ON c.Id = r.CategoryId
JOIN Users AS u ON u.Id = r.UserId
JOIN Status AS s ON s.Id = r.StatusId
ORDER BY e.FirstName DESC, e.LastName DESC,
d.Name ASC, c.Name ASC, r.Description ASC,
r.OpenDate ASC, s.Label ASC, u.Name ASC


--11
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN

		IF (@StartDate IS NULL)
BEGIN
		RETURN 0;
END
		DECLARE @startDateToLook DATETIME = 
		(SELECT OpenDate
		FROM Reports
		WHERE OpenDate = @StartDate)

		IF (@startDateToLook IS NULL)
BEGIN

		RETURN 0;
END
			DECLARE @endDateToLook DATETIME = 
		(SELECT CloseDate
		FROM Reports
		WHERE CloseDate = @EndDate)

			IF (@endDateToLook IS NULL)
BEGIN

		RETURN 0;
END

		DECLARE @time INT = DATEDIFF(HOUR, @startDateToLook, @endDateToLook)
		return @time
END



--12
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS 
BEGIN

DECLARE @reportDepartment INT= (SELECT d.Id
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	JOIN Departments AS d On c.DepartmentId = d.Id
	WHERE r.Id =@ReportId)

	DECLARE @employeeDepartment INT = (SELECT d.Id
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentId = d.Id
WHERE e.Id = @EmployeeId)

	IF (@employeeDepartment= @reportDepartment)
BEGIN
         UPDATE Reports
		 SET EmployeeId = @EmployeeId
		 WHERE Id = @ReportId
END
	ELSE
BEGIN
	RAISERROR ('Employee doesn''t belong to the appropriate department!', 16, 1)
END
END



