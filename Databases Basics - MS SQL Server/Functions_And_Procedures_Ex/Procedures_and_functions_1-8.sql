-- Database Programmability and Transactions

--1
	GO
	CREATE PROC usp_GetEmployeesSalaryAbove35000
	AS 
	BEGIN 
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary > 35000
	END

	--2
	GO
	CREATE PROC usp_GetEmployeesSalaryAboveNumber(@salary DECIMAL(18, 4))
	AS 
	BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE @salary <= e.Salary
	END

	--3
	CREATE PROC usp_GetTownsStartingWith (@townName VARCHAR(MAX))
	AS
	BEGIN
	SELECT t.Name
	FROM Towns AS t
	WHERE Left(t.Name, LEN(@townName)) = @townName
	END

	--4
	CREATE PROC usp_GetEmployeesFromTown (@townName VARCHAR(MAX))
	AS 
BEGIN
	SELECT FirstName, LastName
	FROM Employees AS e
	JOIN Addresses AS a
	ON  a.AddressID = e.AddressID
	JOIN Towns AS t
	ON t.TownID = a.TownID
	WHERE t.Name = @townName
END

	--5
	CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL (18, 4))
	RETURNS VARCHAR(10)
	AS
	BEGIN
	DECLARE @salaryLevel VARCHAR(10) 
	
	   IF( @salary <30000) 
	   BEGIN
	   SET @salaryLevel = 'Low'
	   END
	   IF( @salary BETWEEN 30000 AND 50000)
	   BEGIN
	   SET @salaryLevel = 'Average'
	   END
	   ELSE
	   BEGIN 
	   SET @salaryLevel = 'High'
	   END 
	   RETURN @salaryLevel;
	 END

	 --6
	CREATE PROCEDURE usp_EmployeesBySalaryLevel @SalaryLevel CHAR(7) AS
BEGIN
    SELECT FirstName, LastName
    FROM Employees
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
  END

	--7
	GO
	CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
	RETURNS BIT
	AS
BEGIN
	DECLARE @counter INT = 1;
	DECLARE @currentLetter CHAR;

	WHILE(@counter < LEN (@word))

BEGIN
	SET @currentLetter = SUBSTRING(@word, @counter, 1)
	DECLARE @charIndex INT = CHARINDEX(@currentLetter, @setOfLetters)

	IF (@charIndex<=0)
	BEGIN
		RETURN 0
	END
	SET @counter +=1;
END
	RETURN 1;
END

--8
GO
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
	SELECT EmployeeID FROM Employees
	WHERE DepartmentID = @departmentId
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId
	)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT
	
	update Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentID

	DELETE FROM Employees
	WHERE DepartmentID = @departmentID

	DELETE FROM Departments
	WHERE DepartmentID = @departmentID

	SELECT COUNT (*) FROM Employees
	WHERE DepartmentID = @departmentID
END
