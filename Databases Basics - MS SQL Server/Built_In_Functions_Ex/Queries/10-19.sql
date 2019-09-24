--10,11
USE SoftUni
SELECT * FROM(SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK()  OVER (PARTITION BY Salary 
ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000) AS temp
WHERE temp.[Rank] = 2
ORDER BY temp.[Salary] DESC


--12
USE Geography
SELECT CountryName, IsoCode
 FROM Countries
 WHERE UPPER(CountryName) LIKE ('%A%A%A%')
 ORDER BY IsoCode ASC

 --13
 USE Geography
 SELECT p.PeakName, r.RiverName, LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) -1), r.RiverName)) AS [Mix]
 FROM Peaks AS p, Rivers AS r
 WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName,1)
 ORDER BY [Mix]

 --14
 USE Diablo
 SELECT TOP (50) [Name], FORMAT ( [Start], 'yyyy-MM-dd' ) AS [Start]
 FROM Games
 WHERE DATEPART(YEAR,[Start]) BETWEEN 2011 AND 2012
 ORDER BY [Start], [Name]

 --15
 SELECT Username, 
 SUBSTRING(Email, CHARINDEX('@', Email) +1,  ABS(CHARINDEX('@', Email) - LEN (Email))) AS [Email Provider]
 FROM Users
 ORDER BY [Email Provider] ASC, UserName ASC

 --16
 USE Diablo

 SELECT Username,IpAddress
 FROM Users
 WHERE IpAddress LIKE ('___.1_%._%.___')
 ORDER BY Username ASC

 --17
 SELECT  [Name] AS Game,
 CASE
	WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
END AS [Part of the Day],
CASE 
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
	END AS [Duration]
 FROM Games
 ORDER BY Game ASC, [Duration] ASC, [Part of the Day] ASC

 --18
 USE Orders
 
 SELECT ProductName, OrderDate,
 DATEADD(DAY, 3, OrderDate) AS [Pay Due],
 DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
 FROM Orders

 --19
 CREATE TABLE People(
 Id INT NOT NULL IDENTITY ,
 Name VARCHAR (50),
 BirthDate DATETIME2

CONSTRAINT PK_Id PRIMARY KEY (Id)
 )

 INSERT INTO People([Name], BirthDate) VALUES
 ('Victor', '2000-12-07 00:00:00.000'),
 ('Steven', '1992-09-10 00:00:00.000'),
 ('Stephen', '1910-09-19 00:00:00.000'),
 ('John', '2010-01-06 00:00:00.000')

 SELECT [Name],
ABS(DATEDIFF(YEAR, GETDATE(),  BirthDate)) AS [Age in Years],
ABS(DATEDIFF(MONTH, GETDATE(),  BirthDate)) AS [Age in Months],
ABS(DATEDIFF(DAY, GETDATE(),  BirthDate)) AS [Age in Days],
ABS(DATEDIFF(MINUTE, GETDATE(),  BirthDate)) AS [Age in Minutes]
FROM People