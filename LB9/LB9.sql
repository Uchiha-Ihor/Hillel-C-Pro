-- Створення бази даних University
CREATE DATABASE University;
GO

-- Вибір бази даних University для використання
USE University;
GO

-- Створення таблиці StudentGrades для зберігання інформації про студентів та їхні оцінки
Create Table StudentGrades
(
	Student_ID INT PRIMARY KEY IDENTITY,
	FullName  NVARCHAR(100) Not Null,
	City NVARCHAR(40),
	Country NVARCHAR(40),
	BirthDate DATE,
	Email NVARCHAR(40),
	PhoneNumber NVARCHAR (20),
	GroupName NVARCHAR(40) Not Null,
	AverageGrade FLOAT CHECK (AverageGrade >= 0 AND AverageGrade <= 100),
	MinSubjectName NVARCHAR(40),
	MaxSubjectName NVARCHAR(40)
);
GO

-- Вставка даних про студентів у таблицю StudentGrades
INSERT INTO StudentGrades
Values
('Anna Smith', 'Kyiv', 'Ukraine', '2003-04-15', 'anna.smith@example.com', '+380991234567', '11', 87.5, 'Mathematics', 'Physics'),
('John Doe', 'New York', 'USA', '2002-11-02', 'john.doe@example.com', '+12025550123', '2', 74.2, 'Chemistry', 'History'),
('Maria Petrova', 'Warsaw', 'Poland', '2003-07-22', 'maria.petrova@example.com', '+48501122334', '6', 92.1, 'Literature', 'Computer Science'),
('David Johnson', 'Toronto', 'Canada', '2002-09-12', 'david.johnson@example.com', '+14165551234', '1', 68.9, 'Physics', 'Geography'),
('Olena Kovalchuk', 'Berlin', 'Germany', '2003-01-30', 'olena.k@example.com', '+491512223344', '4', 79.6, 'Biology', 'Mathematics')
GO

-- Вибір усіх даних із таблиці StudentGrades
SELECT * FROM StudentGrades;
GO

-- Вибір лише повних імен студентів із таблиці StudentGrades
SELECT FullName FROM StudentGrades;
GO

-- Вибір середніх балів студентів із таблиці StudentGrades
SELECT AverageGrade FROM StudentGrades;
GO

-- Вибір повних імен студентів, у яких середній бал нижче 80
SELECT FullName FROM StudentGrades
WHERE AverageGrade < 80;
GO

-- Вибір країн проживання студентів із таблиці StudentGrades
SELECT Country FROM StudentGrades;
GO

-- Вибір міст проживання студентів із таблиці StudentGrades
SELECT City FROM StudentGrades;
GO

-- Вибір назв груп студентів із таблиці StudentGrades
SELECT GroupName FROM StudentGrades;
GO
