--DATA AGGREGATION EXERCISE

--1
USE Gringotts

SELECT COUNT(*) 
FROM WizzardDeposits AS [Count]

--2
SELECT MAX(MagicWandSize)
AS LongestMagicWand
FROM WizzardDeposits 

--3
SELECT DepositGroup, 
MAX(MagicWandSize)
AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--4
--TODO

--5
SELECT DepositGroup, SUM(e.DepositAmount) AS TotalSum
FROM WizzardDeposits AS e
GROUP BY e.DepositGroup
	
--6
SELECT DepositGroup, SUM(e.DepositAmount) AS TotalSum
FROM WizzardDeposits AS e
WHERE LOWER(e.MagicWandCreator) = LOWER('Ollivander family')
GROUP BY DepositGroup

--7
SELECT DepositGroup, SUM(e.DepositAmount) AS TotalSum
FROM WizzardDeposits AS e
WHERE LOWER(MagicWandCreator) = LOWER('Ollivander family') 
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--8
SELECT DepositGroup, MagicWandCreator, 
MIN(e.DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits AS e
GROUP BY MagicWandCreator, DepositGroup
ORDER BY MagicWandCreator ASC, DepositGroup	ASC

	--9
	SELECT 
CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
ELSE  '[61+]'
END AS [AgeGroup],
COUNT(*) AS WizardCount
FROM WizzardDeposits
GROUP BY CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
ELSE '[61+]'
END

--10
SELECT LEFT(FirstName,1) AS FirstLetter
FROM WizzardDeposits AS e
WHERE e.DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName,1)

--11
--SELECT DepositGroup, IsDepositExpired, DepositInterest AS AverageInterest
--FROM WizzardDeposits
--GROUP BY DepositGroup
--HAVING IsDepositExpired 

--12
SELECT SUM([Difference]) AS SumDIfference FROM (SELECT FirstName AS [Host Wizard],
DepositAmount AS [Host Wizard Deposit],
LEAD(FirstName) OVER (ORDER BY Id) as [Guest Wizard],
LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS [Difference]
FROM WizzardDeposits) AS DiffTable

--18
SELECT DepartmentId, Salary AS [ThirdHighestSalary]
FROM (SELECT DepartmentId, Salary, DENSE_RANK () OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Ranking]
FROM Employees GROUP BY DepartmentId, Salary) AS [RankTable]
WHERE [Ranking] = 3

--19
SELECT TOP 10 () FirstName, LastName, DepartmentID, Salary
FROM Employees AS e1
WHERE Salary > (
	SELECT DepartmentID, AVG(Salary)
	FROM Employees AS e2
	WHERE e2.DepartmentID = e1.DepartmentID
	GROUP BY DepartmentID
)
ORDER BY e1.DepartmentID

SELECT DepartmentID, AVG(Salary)
FROM Employees AS e2
GROUP BY DepartmentID