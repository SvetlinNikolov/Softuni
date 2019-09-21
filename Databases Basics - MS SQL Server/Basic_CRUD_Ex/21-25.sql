USE Softuni

--20
UPDATE Employees
SET Salary = Salary +(Salary*0.12)
WHERE DepartmentId IN (1,2,4,11)

SELECT Salary 
FROM Employees

--21
USE Geography

SELECT PeakName
FROM Peaks
ORDER BY PeakName ASC

--22
SELECT TOP (30) CountryName, [Population]
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC

--23
SELECT CountryName, CountryCode, 
CASE 
	WHEN CurrencyCode = 'EUR' THEN 'Euro' 
	ELSE 'Not Euro'
	END	AS Currency
	FROM Countries 
	ORDER BY CountryName ASC
	
	--24
	USE Diablo
	SELECT [Name] 
	FROM Characters 
	ORDER BY [Name] ASC