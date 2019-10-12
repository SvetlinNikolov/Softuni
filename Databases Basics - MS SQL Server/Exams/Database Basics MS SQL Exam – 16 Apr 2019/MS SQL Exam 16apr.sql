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


--Full Info
SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name], pl.Name AS [Plane Name], CONCAT(f.Origin, ' - ', f.Destination) AS [Trip], lt.Type AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON f.Id = t.FlightId
JOIN Planes AS pl ON f.PlaneId = pl.Id
LEFT JOIN Luggages AS l ON l.Id = t.LuggageId
full JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name] ASC, pl.Name ASC, f.Origin ASC, f.Destination ASC, lt.Type ASC


--PSP
SELECT p.Name, p.Seats AS [Seats], COUNT(pa.Id) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
LEFT JOIN Passengers AS pa ON pa.Id = t.PassengerId
GROUP BY p.Name, p.Seats
ORDER BY [Passengers Count] DESC, p.Name ASC, [Seats] ASC

--Vacation
REATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT) 
RETURNS VARCHAR(50)
AS 
BEGIN
	IF (@peopleCount <= 0)
BEGIN
	RETURN 'Invalid people count!'
END
	DECLARE @flightId INT = 
	(SELECT  f.Id
	FROM Flights AS f
	WHERE f.Origin = @origin AND f.Destination = @destination)

	IF (@flightId IS NULL)
BEGIN
	RETURN 'Invalid flight!'
END
DECLARE @pricePerPerson DECIMAL (18, 2) = (SELECT t.Price
						  FROM Tickets AS t
						  WHERE t.FlightId = @flightId)

DECLARE @totalPrice DECIMAL (24, 2) = @pricePerPerson * @peopleCount

RETURN CONCAT('Total price', ' ', @totalPrice)
END

--Wrong Data

CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
	UPDATE Flights 
	SET
	DepartureTime = NULL, ArrivalTime = NULL
	WHERE DATEDIFF(SECOND, DepartureTime, ArrivalTime) >=0
END