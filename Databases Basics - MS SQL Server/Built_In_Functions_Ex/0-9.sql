USE Softuni

--1
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--2
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3,10) AND HireDate BETWEEN '1995-01-01' AND '2005-12-31'

--4
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name] ASC

--6
SELECT *
FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC

--7
SELECT *
FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC

--8
GO
CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT FirstName, LastName
FROM Employees
WHERE HireDate > '2000-12-31'

--9
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5


