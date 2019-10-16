--Databases MSSQL Server Exam - 29 Aug 2018

--1
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
Price DECIMAL (15, 2) NOT NULL,

CategoryId INT NOT NULL
FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL,
Salary DECIMAL (15, 2) NOT NULL
)

CREATE TABLE Orders(
Id INT PRIMARY KEY IDENTITY,
DateTime DATETIME NOT NULL,

EmployeeId INT NOT NULL
FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
)

CREATE TABLE OrderItems(
OrderId INT NOT NULL
FOREIGN KEY (OrderId) REFERENCES Orders(Id),

ItemId  INT NOT NULL
FOREIGN KEY (ItemId) REFERENCES Items(Id),

Quantity INT NOT NULL
CHECK (Quantity>=1),

CONSTRAINT CKOrderIdItemId PRIMARY KEY (OrderId, ItemId)
)

CREATE TABLE Shifts(
Id INT NOT NULL IDENTITY,
EmployeeId INT NOT NULL,  --MAYBE COMPOSITE KEY NEEDED
CheckIn DATETIME NOT NULL,
CheckOut DATETIME NOT NULL

CONSTRAINT PK_CompositeIdEmployeeId PRIMARY KEY (Id, EmployeeId),
CONSTRAINT FK_EmployeeIdWithEmployeesId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
CONSTRAINT CK_CheckOutAfterCheckIn CHECK(DATEDIFF(DAY, CheckOut, CheckIn) <= 0)
)

--2
INSERT INTO Employees(FirstName, LastName, Phone, Salary)VALUES
('Stoyan', 'Petrov', '888-785-8573', 500.25),
('Stamat', 'Nikolov', '789-613-1122', 999995.25),
('Evgeni', 'Petkov', '645-369-9517', 1234.51),
('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items(Name, Price, CategoryId)VALUES
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice', 5.32, 1),
('Glasses', 10, 8),
('Bottle of water', 1, 1)

--3
UPDATE Items
SET Price = Price +(Price*0.27)
WHERE CategoryId IN (1, 2, 3)

--4
DELETE FROM OrderItems
WHERE OrderId = 48

--5
SELECT Id, FirstName
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id

--6
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name], Phone
FROM Employees
WHERE LEFT(Phone, 1) =3
ORDER BY FirstName, Phone

--7
SELECT e.FirstName, e.LastName, COUNT(o.Id) AS [Count]
FROM Employees AS e
JOIN Orders AS o ON e.Id = o.EmployeeId
GROUP BY e.FirstName, e.LastName
ORDER BY [COUNT] DESC, e.FirstName

--8
SELECT e.FirstName, e.LastName, AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work hours]
FROM Employees AS e
JOIN Shifts AS s ON e.Id = s.EmployeeId
GROUP BY e.FirstName, e.LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7 
ORDER BY [Work hours] DESC, e.Id

--9
SELECT TOP(1) oi.OrderId, SUM(oi.Quantity * i.Price) as [TotalPrice]
FROM Items AS i
JOIN OrderItems AS oi ON i.Id = oi.ItemId
GROUP BY oi.OrderId
ORDER BY [TotalPrice] DESC

--10
SELECT TOP (10) oi.OrderId, MAX(i.Price) AS [ExpensivePrice], MIN(i.Price) AS [CheapPrice]
FROM Items AS i
JOIN OrderItems AS oi ON i.Id = oi.ItemId
GROUP BY oi.OrderId
ORDER BY [ExpensivePrice] desc, oi.OrderId ASC

--11
SELECT DISTINCT e.Id, e.FirstName, e.LastName
FROM Employees AS e
JOIN Orders AS o ON e.Id = o.EmployeeId
ORDER BY e.Id

--12
SELECT DISTINCT e.Id, CONCAT(FirstName, ' ', e.LastName) AS [Full Name]
FROM Employees AS e
JOIN Shifts AS s ON e.Id = s.EmployeeId
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4 
ORDER BY e.Id

--13
SELECT TOP (10) CONCAT(FirstName, ' ', e.LastName) AS [Full Name],
SUM(i.Price * oi.Quantity) AS [Total Price],
SUM(oi.Quantity) AS [Items]
		FROM Employees AS e
		JOIN Orders AS o ON o.EmployeeId = e.Id
		JOIN OrderItems AS oi ON oi.OrderId = o.Id
		JOIN Items AS i ON i.Id = oi.ItemId
WHERE o.DateTime <= Convert(DATETIME, '2018-06-15' )
GROUP BY e.FirstName, e.LastName
ORDER BY [Total Price] DESC, [Items] DESC

--14
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name], DATENAME(weekday, s.CheckIn) AS [Day of week]
FROM Employees AS e
LEFT JOIN Orders AS o ON e.Id = o.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.EmployeeId IS NULL AND  DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id

--15
-- NEEDS WORK

SELECT  CONCAT(e.FirstName, ' ', e.LastName) AS [FullName],  DATEDIFF(HOUR, s.CheckIn, s.CheckOut)	AS [WorkHours],
SUM(i.Price*oi.Quantity) AS [TotalPrice]
FROM Employees AS e
full JOIN Orders AS o ON e.Id = o.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.Id
 JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = o.Id 
GROUP BY e.FirstName, e.LastName, DATEDIFF(HOUR, s.CheckIn, s.CheckOut)
ORDER BY [FullName] ASC, [WorkHours] DESC, [TotalPrice] DESC

