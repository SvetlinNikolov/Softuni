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

--8
SELECT e.EmployeeID, e.FirstName, IIF(p.StartDate >= '2005.01.01', NULL, p.name) AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS em
ON e.EmployeeID = em.EmployeeID
JOIN Projects as p
ON em.ProjectID = p.ProjectID
WHERE e.EmployeeID  IN (24)

--9
SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName AS [ManagerName]
FROM Employees AS e
JOIN Employees AS em
ON e.ManagerID = em.EmployeeID
WHERE em.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID ASC

--10
SELECT TOP (50) e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName], CONCAT(em.FirstName, ' ', eM.LastName) AS [ManagerName], d.Name AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS em
ON e.ManagerID = em.EmployeeID
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID ASC

--11
SELECT TOP (1) AVG(Salary) AS [MinAverageSalary]
FROM Departments AS d
JOIN Employees AS e
ON d.DepartmentID = e.DepartmentID
GROUP BY e.DepartmentID
ORDER BY AVG(Salary)ASC


--12
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM MountainsCountries AS mc
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON m.Id = p.MountainId
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13
SELECT mc.CountryCode, COUNT(m.MountainRange) AS [MountainRanges]
FROM MountainsCountries AS mc
JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE mc.CountryCode IN ('BG', 'US', 'RU')
GROUP BY (mc.CountryCode)

--14
SELECT TOP (5) c.CountryName, r.RiverName
FROM CountriesRivers AS cr
JOIN Rivers AS r
ON cr.RiverId = r.Id
RIGHT JOIN Countries AS c
ON cr.CountryCode = c.CountryCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC 

--15
SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage FROM
(SELECT c.ContinentCode,
c.CurrencyCode,
COUNT(c.CurrencyCode) AS CurrencyUsage,
DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(c.CurrencyCode) > 1) AS k
WHERE k.[Rank] = 1
ORDER BY k.ContinentCode
