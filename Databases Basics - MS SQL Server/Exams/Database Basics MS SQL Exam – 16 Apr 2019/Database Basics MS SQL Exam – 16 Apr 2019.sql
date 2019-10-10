--Database Basics MS SQL Exam – 16 Apr 2019
CREATE DATABASE Airport

USE Airport

--1
CREATE TABLE Planes(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)

CREATE TABLE Flights(
Id INT PRIMARY KEY IDENTITY,
DepartureTime DATETIME,
ArrivalTime DATETIME,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT NOT NULL 
FOREIGN KEY (PlaneId) REFERENCES Planes(Id)

)

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId CHAR(11)
)

CREATE TABLE LuggageTypes(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
Id INT PRIMARY KEY IDENTITY,
LuggageTypeId INT NOT NULL 
FOREIGN KEY (LuggageTypeId) REFERENCES LuggageTypes(Id),
PassengerId INT NOT NULL
FOREIGN KEY (PassengerId) REFERENCES Passengers(Id),

)


CREATE TABLE Tickets(
Id INT PRIMARY KEY IDENTITY,
PassengerId INT NOT NULL
FOREIGN KEY (PassengerId) REFERENCES Passengers(Id),

FlightId INT NOT NULL 
FOREIGN KEY (FlightId) REFERENCES Flights(Id),

LuggageId INT NOT NULL 
FOREIGN KEY (LuggageId) REFERENCES Luggages(Id),

Price DECIMAL(15, 2) NOT NULL
)

--2
INSERT INTO Planes(Name, Seats, Range)VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type])VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--3
UPDATE t 
SET Price = PRICE +(PRICE *0.13)
FROM Tickets AS t
JOIN Flights AS f
ON t.FlightId = f.Id
WHERE f.Destination = 'Carlsbad'

--4
DELETE FROM Tickets
WHERE Id = 30;

DELETE FROM Flights
WHERE ID = 19;

--5
SELECT f.Origin, f.Destination 
FROM Flights AS f
ORDER BY f.Origin ASC, f.Destination DESC

--6
SELECT * 
FROM Planes AS p
WHERE p.Name LIKE '%tr%'
ORDER BY p.Id ASC, p.Name ASC, p.Seats ASC, p.Range ASC

--7
SELECT f.Id, SUM(t.Price) AS [Price]
FROM Flights AS f
JOIN Tickets AS t
ON f.Id = t.FlightId
GROUP BY f.Id
ORDER BY SUM(t.Price) DESC, f.Id ASC

--8
SELECT TOP (10) p.FirstName, p.LastName, t.Price
FROM Passengers AS p
JOIN Tickets AS t
ON p.Id = t.PassengerId
ORDER BY t.Price DESC, p.FirstName ASC, p.LastName ASC

--9
SELECT lt.Type, COUNT(lt.Id) AS [MostUsedLuggage]
FROM LuggageTypes AS lt
JOIN Luggages AS l
ON l.LuggageTypeId = lt.Id
GROUP BY lt.Type
ORDER BY COUNT(lt.Id) DESC, lt.Type ASC

--10
SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name], f.Origin, f.Destination
FROM Tickets AS t
JOIN Flights AS f
ON t.FlightId = f.Id
JOIN Passengers AS p
ON p.Id = t.PassengerId
ORDER BY [Full Name] ASC, f.Origin ASC, f.Destination ASC

--11
--SELECT p.FirstName, p.LastName, p.Age
--FROM Tickets AS t
--JOIN Flights AS f
--ON t.FlightId = f.Id
--LEFT JOIN Passengers AS p
--ON p.Id = t.PassengerId
--WHERE p.Id NOT IN (f.PlaneId)
--ORDER BY p.Age DESC, p.FirstName ASC, p.LastName ASC
---------NOOOOOOOOOOOOOOOOOOOOOOOOO
