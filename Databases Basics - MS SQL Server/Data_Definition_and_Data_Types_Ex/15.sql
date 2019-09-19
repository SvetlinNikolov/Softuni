CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Employees( FirstName,LastName,Title,Notes) VALUES
('PESHO', 'PESHEV', 'HEAD CHEF', NULL),
('GOSHO', 'PESHEV', ' CHEF', NULL),
('TIHOMIR', 'PESHEV', 'HEAD ', NULL)

CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
PhoneNumber INT NOT NULL,
EmergencyName NVARCHAR(30) NOT NULL,
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(30)
)

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('GOSHO', 'GOSHOV', 0888888, 'YES', 099999999, NULL),
('PESHO', 'GOSHOV', 08888888, 'NO', 099999999, NULL),
('PEPE', 'GOSHOV', 088888688, 'MAYBE', 099999999, NULL)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR (15) PRIMARY KEY,
Notes NVARCHAR (MAX)
)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('Available', NULL),
('Unavailable', NULL),
('VACANT', NULL)

CREATE TABLE RoomTypes(
RoomType NVARCHAR (30) PRIMARY KEY,
Notes NVARCHAR (MAX)
)

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('BEDROOM', NULL),
('KEKROOM', NULL),
('STEKROOM', NULL)


CREATE TABLE BedTypes(
BedType NVARCHAR(30) PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(BedType, Notes) VALUES
('BIG', NULL),
('SMALL', NULL),
('VERY SMALL', NULL)

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY,
RoomType NVARCHAR(30) NOT NULL,
BedType NVARCHAR(30),
Rate DECIMAL (15,2) NOT NULL,
RoomStatus NVARCHAR (30) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(123, 'ASD', 'LARGE', 15, 'AVAILABLE', NULL),
(1234, 'NOCAP', 'SMALL', 15, 'AVAILABLE', NULL),
(1235, 'YES', 'LARGE', 15, 'AVAILABLE', NULL)

CREATE TABLE Payments (
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL,
PaymentDate DATETIME2 NOT NULL,
AccountNumber INT NOT NULL,
FirstDateOccupied DATETIME2 NOT NULL,
LastDateOccupied DATETIME2 NOT NULL,
TotalDays INT NOT NULL,
AmountCharged DECIMAL (15,2) NOT NULL,
TaxRate DECIMAL (15,2) NOT NULL,
TaxAmount DECIMAL (15,2) NOT NULL,
PaymentTotal DECIMAL (15,2) NOT NULL,
Notes NVARCHAR (MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate,
TaxAmount, PaymentTotal, Notes) VALUES
(123, '11-12-2017', 123, '12-12-2017', '11-12-2017', 1, 555, 20, 25, 2500, NULL),
(456, '12-12-2017', 123, '11-12-2009', '12-12-2017', 1, 555, 20, 25, 2500, NULL),
(789, '10-12-2017', 123, '10-12-2012', '10-12-2017', 1, 555, 20, 25, 2500, NULL)

CREATE TABLE Occupancies (
Id INT PRIMARY KEY,
EmployeeId INT NOT NULL,
DateOccupied DATETIME2 NOT NULL,
AccountNumber INT NOT NULL,
RoomNumber INT NOT NULL,
RateApplied DECIMAL (15,2) NOT NULL,
PhoneCharge DECIMAL (15,2) NOT NULL,
Notes NVARCHAR (MAX)
)

INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, 123, '10-12-2019', 123, 321, 200, 0, NULL),
(2, 123, '10-12-2019', 123, 321, 200, 0, NULL),
(3, 123, '10-12-2019', 123, 321, 200, 0, NULL)




