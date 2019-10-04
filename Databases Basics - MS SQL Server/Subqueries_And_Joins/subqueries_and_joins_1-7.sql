--Joins, Subqueries, CTE and Indices

--1
SELECT TOP (5) EmployeeID, JobTitle, e.AddressID, AddressText
FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC


--2
SELECT  TOP (50)FirstName, LastName, t.[Name], a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY FirstName ASC, LastName ASC

--3
SELECT e.EmployeeID, FirstName, LastName, d.Name
FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID ASC

--4
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.name AS [DepartmentName]
FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary>15000
ORDER BY d.DepartmentID ASC	

--5
SELECT TOP (3)e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

--6
SELECT FirstName, LastName, HireDate, d.Name
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales' OR d.[Name] = 'Finance' AND e.HireDate > '1999/01/01'
ORDER BY e.HireDate ASC

--7
SELECT TOP (5) e.EmployeeID, e.FirstName, p.name AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002/08/13' AND p.EndDate IS  NULL
ORDER BY e.EmployeeID ASC
