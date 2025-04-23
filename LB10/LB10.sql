-- Створення бази даних Hospital
CREATE DATABASE Hospital;
GO

-- Використання бази даних Hospital
USE Hospital;
GO

-- Створення таблиці Departments (Відділення)
CREATE TABLE Departments(
	Id INT IDENTITY PRIMARY KEY,
	Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
	Financing MONEY NOT NULL CHECK (Financing >= 0) DEFAULT 0,
	Name NVARCHAR(100) NOT NULL CHECK (Name <> '') UNIQUE
);
GO

-- Створення таблиці Diseases (Захворювання)
CREATE TABLE Diseases(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL CHECK (Name <> '') UNIQUE,
	Severity INT NOT NULL CHECK (Severity >= 1) DEFAULT 1
);
GO

-- Створення таблиці Doctors (Лікарі)
CREATE TABLE Doctors(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL CHECK (Name <> ''),
	Phone CHAR(10),
	Salary MONEY NOT NULL CHECK (Salary > 0),
	Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> '')
);
GO

-- Створення таблиці Examinations (Обстеження)
CREATE TABLE Examinations(
	Id INT IDENTITY PRIMARY KEY,
	DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 1 AND 7),
	Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
	StartTime TIME NOT NULL CHECK (StartTime >= '08:00' AND StartTime <= '18:00'),
    EndTime TIME NOT NULL,
	CONSTRAINT CHK_EndTime_After_StartTime CHECK (EndTime > StartTime)
);
GO

-- Створення таблиці Wards (Палати)
CREATE TABLE Wards (
    Id INT IDENTITY PRIMARY KEY,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Floor INT NOT NULL CHECK (Floor >= 1),
    Name NVARCHAR(20) NOT NULL UNIQUE CHECK (Name <> '')
);

DELETE FROM Departments;
DELETE FROM Diseases;
DELETE FROM Doctors;
DELETE FROM Examinations;
DELETE FROM Wards;

-- Заповнення таблиці Departments (Відділення)
INSERT INTO Departments VALUES
(1, 25000, 'Cardiology'),
(2, 15000, 'Neurology'),
(3, 30000, 'Pediatrics'),
(4, 20000, 'Oncology'),
(5, 10000, 'Orthopedics');
GO

-- Заповнення таблиці Diseases (Захворювання)
INSERT INTO Diseases VALUES
('Hypertension', 3),
('Diabetes', 4),
('Asthma', 2),
('Pneumonia', 5),
('Migraine', 1),
('Arthritis', 3);
GO

-- Заповнення таблиці Doctors (Лікарі)
INSERT INTO Doctors VALUES
('John', '1234567890', 2000, 'Smith'),
('Anna', '0987654321', 2500, 'Johnson'),
('Michael', NULL, 1800, 'Brown'),
('Emma', '5551234567', 3000, 'Davis'),
('Sarah', '4449876543', 2200, 'Wilson'),
('David', NULL, 2700, 'Taylor');
GO

-- Заповнення таблиці Examinations (Обстеження)
INSERT INTO Examinations VALUES
(1, 'Blood Test', '09:00', '10:00'),
(2, 'MRI Scan', '10:30', '11:30'),
(3, 'Ultrasound', '14:00', '15:00'),
(4, 'X-Ray', '08:30', '09:30'),
(5, 'ECG', '11:00', '12:00'),
(6, 'CT Scan', '13:00', '14:30');
GO

-- Заповнення таблиці Wards (Палати)
INSERT INTO Wards VALUES
(1, 1, 'Ward A'),
(2, 2, 'Ward B'),
(3, 1, 'Ward C'),
(4, 3, 'Ward D'),
(5, 2, 'Ward E'),
(1, 4, 'Ward F'),
(2, 1, 'Ward G');
GO

-- 1. Вивести вміст таблиці палат
SELECT * FROM Departments;
GO

-- 2. Вивести прізвища та телефони усіх лікарів
SELECT Surname, Phone FROM Doctors;
GO

-- 3. Вивести усі поверхи без повторень, де розміщуються палати
SELECT DISTINCT FLOOR FROM Wards;
GO

-- 4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease»
SELECT Name [Name of Disease], Severity [Severity of Disease] FROM Diseases;
GO

-- 5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми
SELECT dep.Name AS [Departmen Name], doc.Surname AS [Doctor Surname], w.Name AS [Ward Name]
FROM  Departments AS dep, Doctors AS doc, Wards AS w;
GO

-- 6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 30000
SELECT Name FROM Departments WHERE (Building = 5 AND Financing < 30000);
GO

-- 7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 12000 до 15000
SELECT Name FROM Departments WHERE (Building = 3 AND Financing BETWEEN 12000 AND 15000);
GO

-- 8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі
SELECT Name FROM Wards WHERE (Building IN (4,5) AND FLOOR = 1);
GO


-- 9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 3 або 6 та мають фонд фінансування менший, ніж 11000 або більший за 25000
SELECT Name, Building, Financing
FROM Departments
WHERE (Building IN (3,6) AND (Financing < 11000 OR Financing > 25000));
GO

-- 10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 1500
SELECT Surname FROM  Doctors WHERE (Salary > 1500);
GO

-- 11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавк
SELECT Surname FROM Doctors WHERE (Salary / 2) > (1500 * 3);
GO

-- 12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00
SELECT DISTINCT Name FROM Examinations
WHERE DayOfWeek <= 3 AND StartTime >= '12:00' AND EndTime <= '15:00';
GO

-- 13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 8 або 10
SELECT Name, Building FROM Departments
WHERE Building IN (1,3,8,10);
GO

-- 14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го
SELECT Name FROM Diseases WHERE Severity NOT IN (1,2);

-- 15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі
SELECT Name FROM Departments WHERE Building NOT IN (1,2);

-- 16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі
SELECT Name FROM Departments WHERE Building IN (1, 3);

-- 17. Вивести прізвища лікарів, що починаються з літери «N»
SELECT Surname FROM Doctors WHERE Surname LIKE 'N%'