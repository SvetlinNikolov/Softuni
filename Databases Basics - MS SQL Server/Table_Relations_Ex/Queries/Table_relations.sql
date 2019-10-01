CREATE DATABASE TableRelations

USE TableRelations

--1
CREATE Table Persons(
PersonID INT NOT NULL IDENTITY,
FirstName NVARCHAR (50),
Salary DECIMAL (15,2),
PassportID INT

)

CREATE TABLE Passports(
PassportID INT,
PassportNumber NVARCHAR (50)
)

INSERT INTO Passports (PassportNumber) VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')
 
INSERT INTO Persons (FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 2),
('Tom', 56100.00, 3),
('Yana', 60200.00, 1)

ALTER TABLE Persons
ADD CONSTRAINT PK_PersonID PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD CONSTRAINT FK_PassportID FOREIGN KEY (PassportID) REFERENCES Persons(PersonID)


--2
CREATE TABLE Manufacturers(
 ManufacturerID INT PRIMARY KEY,
 [Name] NVARCHAR (50),
 EstablishedOn DATETIME
 )


CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR (50) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)


INSERT INTO Models( Name) VALUES
('X1' ),
('I6'),
('Model S'),
('Model X'),
('Model 3'),
('Nova')

INSERT INTO Manufacturers([ManufacturerID] , Name,  EstablishedOn) VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')

--3
CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
ExamID INT FOREIGN KEY REFERENCES Exams(ExamID)
CONSTRAINT PK_CompositeSutdentIDExamID 
PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students([Name]) VALUES
('Mila'), ('Toni'), ('Ron')

INSERT INTO Exams(ExamID, [Name]) VALUES
(101, 'SpringMVC'), 
(102, 'Neo4j'), 
(103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID) VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)


--4
CREATE TABLE Teachers(
 TeacherID INT PRIMARY KEY ,
[Name] NVARCHAR (50) NOT NULL,
ManagerID INT
)

--5

CREATE DATABASE University

USE University

CREATE TABLE Majors(
MajorID INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
StudentNumber NVARCHAR (15) NOT NULL,
StudentName NVARCHAR (60) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY,
PaymentDate SMALLDATETIME NOT NULL,
PaymentAmount DECIMAL (15,2) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentsID) NOT NULL
)

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY,
SubjectName NVARCHAR(30) NOT NULL
)

CREATE TABLE Agenda(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
CONSTRAINT CK_StudentIDSubjectID
PRIMARY KEY (StudentID, SubjectID)
)

