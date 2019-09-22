	--2
	SELECT * FROM Departments

	--3
	SELECT [Name] FROM Departments

	--4
	SELECT FirstName, LastName, Salary FROM Employees

	--5
	SELECT FirstName + '.' + LastName + '@softuni.bg' 
	FROM Employees 

	--6
	SELECT DISTINCT Salary
	 FROM Employees
	 ORDER BY Salary ASC 

	--7
	SELECT * FROM Employees 
	WHERE JobTitle = 'Sales Representative'

	--8
	SELECT FirstName, LastName, JobTitle FROM Employees 
	WHERE Salary BETWEEN 20000 AND 30000

	--9
	SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM Employees
	WHERE Salary IN (25000,14000,12500,23600)

	--10
	SELECT FirstName, LastName
    FROM Employees 
	WHERE ManagerID IS NULL

	--11
	SELECT FirstName, LastName, Salary 
	FROM Employees 
	WHERE Salary > 50000
	ORDER BY Salary DESC

	--12
	SELECT TOP (5) FirstName, LastName
	FROM Employees
	ORDER BY Salary DESC

	--13
	SELECT FirstName, LastName
	FROM Employees
	WHERE DepartmentID !=4

	--14
	SELECT * FROM Employees
	ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC

	--15
	CREATE VIEW V_EmployeesSalaries
	AS
	SELECT FirstName, LastName, Salary
	FROM Employees

	--16
	CREATE VIEW V_EmployeeNameJobTitle
	AS
	SELECT CONCAT (FirstName, ' ', ISNULL(MiddleName, ''), ' ', LastName) AS [FullName], JobTitle
	FROM Employees

	--17
	SELECT DISTINCT JobTitle
	FROM Employees
	
	--18
	SELECT TOP (10) *
	FROM Projects
	ORDER BY StartDate,[Name]

	--19
	SELECT TOP (7) FirstName, LastName, HireDate
	FROM Employees
	ORDER BY HireDate DESC

	--20
	SELECT * FROM Departments