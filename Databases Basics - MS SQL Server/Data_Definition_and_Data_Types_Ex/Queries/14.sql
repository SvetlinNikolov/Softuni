
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR (30) NOT NULL,
DailyRate DECIMAL (15,2) NOT NULL,
WeeklyRate Decimal (15,2),
MonthlyRate DECIMAL (15,2),
WeekendRate  DECIMAL (15,2)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate,MonthlyRate, WeekendRate) VALUES
('PESHO', 12, 13, 14, 15),
('PESHO1', 12, 13, 14, 15),
('PESHO2', 12, 13, 14, 15)


CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber NVARCHAR (20) NOT NULL,
Manufacturer NVARCHAR (30) NOT NULL,
Model NVARCHAR (30) NOT NULL,
CarYear DATETIME2 NOT NULL,
CategoryId NVARCHAR (30) NOT NULL,
Doors SMALLINT NOT NULL,
Picture VARBINARY(MAX),
Condition  NVARCHAR(30) NOT NULL,
Available BIT 
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('1312', 'TOYOTA', 'COROLLA AE86 ', '10-10-1986', 'SPORTS CAR', 2, NULL, 'EPIC', 0),
('1212', 'HONDA', 'CIVIC TYPE R ', '10-10-1990', 'SPORTS CAR', 2, NULL, 'EPIC', 0),
('1112', 'NISSAN', 'SKYLINE R32', '10-10-1996', 'SPORTS CAR', 2, NULL, 'EPIC', 0)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR (30) NOT NULL,
LastName NVARCHAR (30) NOT NULL,
Title NVARCHAR (30) NOT NULL,
Notes Text 
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('TAKUMI', 'FUJIWARA', 'STREET RACER', 'KANSEI DORIFTO'),
('Svetlin', 'Nikolov', 'DRAG RACER', 'VROOM VROOM'),
('Rosen', 'Filipov', 'CAFE RACER', 'VERY FAST YES')



CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR (60) NOT NULL,
[Address] NVARCHAR (60) NOT NULL,
City NVARCHAR (30) NOT NULL,
ZIPCode NVARCHAR (30),
Notes Text
)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
(1321, 'KANSEI DORIFTO NANI', 'SOFIA DEJENEIRO', 'AFGANISTAN', '1000', NULL),
(12321, 'KANSEI DORIFTO NANI', 'SOFIA DEJENEIRO', 'AFGANISTAN', '1000', NULL),
(13221, 'KANSEI DORIFTO NANI', 'SOFIA DEJENEIRO', 'AFGANISTAN', '1000', NULL)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL,
CustomerId INT NOT NULL,
CarId INT NOT NULL,
TankLevel DECIMAL (4,2) NOT NULL,
KilometrageStart  DECIMAL (15,2) NOT NULL,
KilometrageEnd  DECIMAL (15,2) NOT NULL,
TotalKilometrage  DECIMAL (15,2) NOT NULL,
StartDate  DATETIME2 NOT NULL,
EndDate  DATETIME2 NOT NULL,
TotalDays INT NOT NULL,
RateApplied DECIMAL (15,2) NOT NULL,
TaxRate DECIMAL (15,2) NOT NULL,
OrderStatus NVARCHAR(30) NOT NULL,
Notes TEXT
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, 
EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1,2,3,4,5,6,7, '10-10-2017', '10-12-2017', 8, 9, 3.14, 'Done', NULL),
(1,2,3,4,5,6,7, '10-10-2017', '10-12-2017', 8, 9, 3.14, 'Done', NULL),
(1,2,3,4,5,6,7, '10-10-2017', '10-12-2017', 8, 9, 3.14, 'Done', NULL)