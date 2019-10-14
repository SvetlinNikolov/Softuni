CREATE DATABASE School

Use School

--1
CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age SMALLINT
CHECK (Age BETWEEN 5 AND 100),
Address NVARCHAR(30),
Phone NCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL
CHECK (Lessons > 0)
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,

StudentId INT NOT NULL 
FOREIGN KEY (StudentId) REFERENCES Students(Id),

SubjectId INT NOT NULL
FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),

Grade DECIMAL (15, 2) NOT NULL
CHECK (Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
Date DATETIME,

SubjectId INT NOT NULL
FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams(
StudentId INT NOT NULL
FOREIGN KEY (StudentId) REFERENCES Students(Id),

ExamId INT NOT NULL
FOREIGN KEY (ExamId) REFERENCES Exams(Id),

Grade DECIMAL (15, 2) NOT NULL
CHECK (Grade BETWEEN 2 AND 6)

CONSTRAINT PK_CompositeStudentIdExamId PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Address NVARCHAR(20) NOT NULL,
Phone CHAR(10),

SubjectId INT NOT NULL
FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers(
StudentId INT NOT NULL
FOREIGN KEY (StudentId) REFERENCES Students(Id),

TeacherId INT NOT NULL
FOREIGN KEY (TeacherId) REFERENCES Teachers(Id),

CONSTRAINT PK_CompositeStudentIdTeacherId PRIMARY KEY (StudentId, TeacherId)
)



--2
INSERT INTO Teachers(FirstName, LastName, Address, Phone, SubjectId) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146, 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', 3324874824, 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', 4373065154, 5),
('Bert', 'Ivie', '2 Gateway Circle', 4409584510, 4)

INSERT INTO Subjects (Name, Lessons) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)


--3
UPDATE StudentsSubjects
SET Grade = 6
WHERE SubjectId IN (1, 2) AND Grade >= 5.50

--4 
DELETE FROM StudentsTeachers
WHERE TeacherId IN
		(SELECT Id
		FROM Teachers
		WHERE Phone LIKE ('%72%'))

	  DELETE FROM Teachers
WHERE Phone LIKE ('%72%')

--5
SELECT s.FirstName, s.LastName, s.Age
FROM Students AS s
WHERE s.Age >= 12
ORDER BY s.FirstName, s.LastName

--6
SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS [TeachersCount]
FROM StudentsTeachers AS st
JOIN Students AS s ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

--7
SELECT  CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name]
FROM Students AS s
 LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE se.StudentId IS NULL
ORDER BY [Full Name] ASC

--8
SELECT TOP (10) s.FirstName, s.LastName, CONVERT(DECIMAL(10,2), AVG(se.Grade)) AS [Grade]
FROM Students AS s
JOIN StudentsExams AS se ON s.Id = se.StudentId
GROUP BY s.FirstName, s.LastName
ORDER BY [Grade] DESC, s.FirstName, s.LastName

--9
SELECT IIF(s.MiddleName IS NULL,
CONCAT(s.FirstName, ' ', s.LastName),
CONCAT(s.FirstName, ' ', s.MiddleName, ' ', s.LastName)) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS se ON s.Id = se.StudentId
WHERE se.StudentId IS NULL
ORDER BY [Full Name] ASC

--10
SELECT su.Name, AVG(ss.Grade) AS [AverageGrade]
FROM StudentsSubjects AS ss
JOIN Subjects AS su ON su.Id = ss.SubjectId
GROUP BY  su.Name, su.Id
ORDER BY su.Id

--11
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15, 2))
RETURNS VARCHAR(70)
AS 
BEGIN
     DECLARE @studentToSearchFor INT = (SELECT Id FROM Students
								 WHERE Id = @studentId)

	 DECLARE @studentName NVARCHAR(70)= ( SELECT FirstName
									      FROM Students
										  WHERE Id = @studentToSearchFor)

	 IF (@studentToSearchFor IS NULL)
BEGIN
	 RETURN 'The student with provided id does not exist in the school!'
END
	 IF (@grade > 6.00)
BEGIN
	 RETURN 'Grade cannot be above 6.00!'
END

	DECLARE @result INT =
	(SELECT COUNT(*)
	FROM StudentsExams AS ss
	WHERE ss.StudentId = @studentId AND ss.Grade BETWEEN @grade AND @grade + 0.50)

	RETURN CONCAT ('You have to update ', @result, ' grades for the student ', @studentName)
END


--12
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS 
BEGIN
 DECLARE @studentToSearchFor INT = (SELECT Id FROM Students
								 WHERE Id = @studentId)

	 IF (@studentToSearchFor IS NULL)
BEGIN
	 RAISERROR('This school has no student with the provided id!', 16, 1)
END
	ELSE
BEGIN

ALTER TABLE dbo.StudentsExams
DROP CONSTRAINT FK_StudentsExams_Students;

ALTER TABLE dbo.StudentsTeachers
DROP CONSTRAINT FK_StudentsTeachers_Students;

	DELETE 
	FROM StudentsSubjects
	WHERE StudentId IN(

	 SELECT Id
	 FROM Students
	 WHERE Id = @studentToSearchFor)
	
	DELETE FROM Students
	WHERE Id = @studentToSearchFor
	
	DELETE FROM StudentsExams	
	WHERE  StudentId = @studentToSearchFor

	DELETE FROM StudentsTeachers
	WHERE StudentId = @studentToSearchFor

END

END

