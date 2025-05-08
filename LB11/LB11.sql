-- Вибір бази даних Barbershop для виконання всіх команд
USE Barbershop;
GO

-- Видалення таблиці Barbers, якщо вона існує
DROP TABLE IF EXISTS Barbers;
GO
-- Створення таблиці для зберігання інформації про барберів
CREATE TABLE Barbers (
    BarberID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
	Surname NVARCHAR(100) NOT NULL,
	Patronymic NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    BirthDate DATE NOT NULL,
    HireDate DATE NOT NULL,
    Position NVARCHAR(50) NOT NULL CHECK (Position IN ('Chief Barber', 'Senior Barber', 'Junior Barber')), -- Треба додати перевірку через тригер
);
GO

-- Видалення таблиці Services, якщо вона існує
DROP TABLE IF EXISTS Services;
GO
-- Створення таблиці для зберігання інформації про послуги
CREATE TABLE Services (
    ServiceID INT PRIMARY KEY IDENTITY,
    ServiceName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Duration INT NOT NULL
);
GO

-- Видалення таблиці BarberServices, якщо вона існує
DROP TABLE IF EXISTS BarberServices;
GO
-- Створення таблиці для зв’язку барберів із послугами
CREATE TABLE BarberServices (
    BarberID INT NOT NULL,
    ServiceID INT NOT NULL,
    PRIMARY KEY (BarberID, ServiceID),
    FOREIGN KEY (BarberID) REFERENCES Barbers(BarberID),
    FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
);
GO

-- Видалення таблиці Customers, якщо вона існує
DROP TABLE IF EXISTS Customers;
GO
-- Створення таблиці для зберігання інформації про клієнтів
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Patronymic NVARCHAR(50) NULL,
    Phone NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL
);
GO

-- Видалення таблиці Schedule, якщо вона існує
DROP TABLE IF EXISTS Schedule;
GO
-- Створення таблиці для зберігання розкладу барберів
CREATE TABLE Schedule (
    ScheduleID INT PRIMARY KEY IDENTITY,
    BarberID INT NOT NULL,
    CustomerID INT NULL,
    Date DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    IsAvailable BIT NOT NULL DEFAULT 1,
	FOREIGN KEY (BarberID) REFERENCES Barbers(BarberID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
GO

-- Видалення таблиці Visits, якщо вона існує
DROP TABLE IF EXISTS Visits;
GO
-- Створення таблиці для зберігання інформації про відвідування
CREATE TABLE Visits (
	VisitID INT PRIMARY KEY IDENTITY,
	CustomerID INT NOT NULL,
	BarberID INT NOT NULL,
	ServiceID INT NOT NULL,
	VisitDate DATE NOT NULL,
	TotalCost DECIMAL(10,2) NOT NULL,
	FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID),
	FOREIGN KEY (BarberID) REFERENCES Barbers(BarberID)
);

-- Видалення таблиці VisitsServices, якщо вона існує
DROP TABLE IF EXISTS VisitsServices;
GO
-- Створення таблиці для зв’язку відвідувань із послугами
CREATE TABLE VisitsServices (
	VisitID INT NOT NULL,
	ServiceID INT NOT NULL,
	PRIMARY KEY (VisitID, ServiceID),
	FOREIGN KEY (VisitID) REFERENCES Visits (VisitID),
	FOREIGN KEY (ServiceID) REFERENCES Services (ServiceID),
);

-- Створення таблиці для зберігання відгуків клієнтів
CREATE TABLE Feedbacks (
    FeedbackID INT PRIMARY KEY IDENTITY,
    CustomerID INT NOT NULL,
    BarberID INT NOT NULL,
    VisitID INT NOT NULL,
    Rating NVARCHAR(20) NOT NULL CHECK (Rating IN ('Very Bad', 'Bad', 'Normal', 'Good', 'Excellent')),
    Comment NVARCHAR(MAX) NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (BarberID) REFERENCES Barbers(BarberID),
    FOREIGN KEY (VisitID) REFERENCES Visits(VisitID)
);

-- Тригер для обмеження кількості Chief Barber до одного
CREATE TRIGGER trg_ChiefBarberLimit
ON Barbers
AFTER INSERT, UPDATE
AS
BEGIN
    IF (SELECT COUNT(*) FROM Barbers WHERE Position = 'Chief Barber') > 1
    BEGIN
        RAISERROR ('Only one Chief Barber is allowed.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Наповнення таблиці Barbers даними (5 барберів)
INSERT INTO Barbers (Name, Surname, Patronymic, Gender, Phone, Email, BirthDate, HireDate, Position)
VALUES 
('Іван', 'Сидоренко', 'Петрович', 'Чоловік', '123456789', 'chief@example.com', '1980-01-01', '2010-01-01', 'Chief Barber'),
('Петро', 'Коваленко', 'Іванович', 'Чоловік', '234567890', 'senior1@example.com', '1985-02-02', '2012-02-02', 'Senior Barber'),
('Марія', 'Литвиненко', 'Василівна', 'Жінка', '345678901', 'senior2@example.com', '1990-03-03', '2015-03-03', 'Senior Barber'),
('Олег', 'Шевченко', 'Михайлович', 'Чоловік', '456789012', 'junior1@example.com', '1995-04-04', '2018-04-04', 'Junior Barber'),
('Анна', 'Бондаренко', 'Сергіївна', 'Жінка', '567890123', 'junior2@example.com', '1998-05-05', '2020-05-05', 'Junior Barber');

-- Наповнення таблиці Services даними (6 послуг)
INSERT INTO Services (ServiceName, Price, Duration)
VALUES 
('Стрижка чоловіча', 200.00, 30),
('Стрижка жіноча', 250.00, 45),
('Гоління бороди', 150.00, 20),
('Укладка', 100.00, 15),
('Фарбування волосся', 300.00, 60),
('Манікюр', 180.00, 40);

-- Наповнення таблиці BarberServices даними (15 зв’язків барберів із послугами)
INSERT INTO BarberServices (BarberID, ServiceID)
VALUES 
(1, 1), (1, 2), (1, 3), (1, 4),
(2, 1), (2, 3), (2, 5),
(3, 2), (3, 4), (3, 6),
(4, 1), (4, 3),
(5, 2), (5, 4), (5, 6);

-- Наповнення таблиці Customers даними (7 клієнтів)
INSERT INTO Customers (Name, Surname, Patronymic, Phone, Email)
VALUES 
('Василь', 'Григоренко', 'Миколайович', '678901234', 'customer1@example.com'),
('Олена', 'Іваненко', 'Петрівна', '789012345', 'customer2@example.com'),
('Сергій', 'Павленко', 'Олександрович', '890123456', 'customer3@example.com'),
('Наталія', 'Кравченко', 'Василівна', '901234567', 'customer4@example.com'),
('Дмитро', 'Литвин', 'Ігорович', '012345678', 'customer5@example.com'),
('Юлія', 'Бондар', 'Сергіївна', '123456789', 'customer6@example.com'),
('Андрій', 'Шевчук', 'Вікторович', '234567890', 'customer7@example.com');

-- Наповнення таблиці Schedule даними (15 записів розкладу)
INSERT INTO Schedule (BarberID, Date, StartTime, EndTime, IsAvailable)
VALUES 
(1, '2023-01-01', '09:00', '10:00', 1),
(1, '2023-01-01', '10:00', '11:00', 1),
(1, '2023-01-01', '11:00', '12:00', 1),
(2, '2023-01-01', '09:00', '10:00', 1),
(2, '2023-01-01', '10:00', '11:00', 1),
(2, '2023-01-01', '11:00', '12:00', 1),
(3, '2023-01-01', '09:00', '10:00', 1),
(3, '2023-01-01', '10:00', '11:00', 1),
(3, '2023-01-01', '11:00', '12:00', 1),
(4, '2023-01-01', '09:00', '10:00', 1),
(4, '2023-01-01', '10:00', '11:00', 1),
(4, '2023-01-01', '11:00', '12:00', 1),
(5, '2023-01-01', '09:00', '10:00', 1),
(5, '2023-01-01', '10:00', '11:00', 1),
(5, '2023-01-01', '11:00', '12:00', 1);

-- Наповнення таблиці Visits даними (5 відвідувань)
INSERT INTO Visits (CustomerID, BarberID, ServiceID, VisitDate, TotalCost)
VALUES 
(1, 1, 1, '2023-01-01', 200.00),
(2, 2, 3, '2023-01-01', 150.00),
(3, 3, 2, '2023-01-01', 250.00),
(4, 4, 1, '2023-01-01', 200.00),
(5, 5, 4, '2023-01-01', 100.00);

-- Наповнення таблиці VisitsServices даними (5 зв’язків відвідувань із послугами)
INSERT INTO VisitsServices (VisitID, ServiceID)
VALUES 
(1, 1),
(2, 3),
(3, 2),
(4, 1),
(5, 4);

-- Наповнення таблиці Feedbacks даними (4 відгуки)
INSERT INTO Feedbacks (CustomerID, BarberID, VisitID, Rating, Comment)
VALUES 
(1, 1, 1, 'Excellent', 'Дуже задоволений!'),
(2, 2, 2, 'Good', 'Добре, але можна краще'),
(3, 3, 3, 'Normal', 'Нормально'),
(4, 4, 4, 'Bad', 'Не сподобалось');

-- TASK 1.1
-- Процедура повертає повні імена всіх барберів
DROP PROCEDURE IF EXISTS GetAllBarbers;
GO
CREATE PROCEDURE GetAllBarbers AS
BEGIN
    SELECT CONCAT(Surname, ' ', Name, ' ', Patronymic) AS FullName
    FROM Barbers;
END;
GO

EXECUTE GetAllBarbers;
GO

-- TASK 1.2
-- Процедура повертає всіх барберів із посадою 'Senior Barber'
DROP PROCEDURE IF EXISTS GetSeniorBarbers;
Go
CREATE PROCEDURE GetSeniorBarbers 
AS
BEGIN
	SELECT * FROM Barbers
	WHERE Barbers.Position = 'Senior Barber';
END;
GO

EXECUTE GetSeniorBarbers;
GO


-- TASK 1.3
-- Процедура повертає барберів, які надають послугу 'Гоління бороди'
DROP PROCEDURE IF EXISTS GetBarbersForTraditionalShaving;
Go
CREATE PROCEDURE GetBarbersForTraditionalShaving 
AS
BEGIN
	SELECT * FROM Barbers
	JOIN BarberServices ON Barbers.BarberID = BarberServices.BarberID
	JOIN Services ON BarberServices.ServiceID = Services.ServiceID
	WHERE Services.ServiceName = 'Гоління бороди'
END;
GO

EXECUTE GetBarbersForTraditionalShaving;
GO

-- TASK 1.4
-- Процедура повертає барберів, які надають задану послугу за її ID
DROP PROCEDURE IF EXISTS GetBarbersForService;
Go
CREATE PROCEDURE GetBarbersForService 
	@Service INT
AS
BEGIN
	SELECT * FROM Barbers
	JOIN BarberServices ON Barbers.BarberID = BarberServices.BarberID
	WHERE BarberServices.ServiceID = @Service
END;
GO

DECLARE @Service INT
SET @Service = 3
EXECUTE GetBarbersForService @Service;
GO

-- TASK 1.5
-- Процедура повертає барберів із досвідом роботи не менше заданого
DROP PROCEDURE IF EXISTS GetBarbersByExperience;
Go
CREATE PROCEDURE GetBarbersByExperience 
	@Experience INT
AS
BEGIN
	SELECT * FROM Barbers
	WHERE DATEDIFF(year, Barbers.HireDate, GETDATE()) >= @Experience
END;
GO

DECLARE @Experience INT
SET @Experience = 7
EXECUTE GetBarbersByExperience @Experience;
GO

-- TASK 1.6
-- Процедура повертає кількість старших і молодших барберів
DROP PROCEDURE IF EXISTS GetBarberCounts;
Go
CREATE PROCEDURE GetBarberCounts 
AS
BEGIN
	SELECT
		SUM(CASE WHEN Barbers.Position = 'Senior Barber' THEN 1 ELSE 0 END) AS [Seniors count],
		SUM(CASE WHEN Barbers.Position = 'Junior Barber' THEN 1 ELSE 0 END)  AS [Junior count]
		FROM Barbers
END;
GO

EXECUTE GetBarberCounts;
GO

-- TASK 1.7
-- Процедура повертає клієнтів із кількістю відвідувань не менше заданої
DROP PROCEDURE IF EXISTS GetLoyalCustomers;
Go
CREATE PROCEDURE GetLoyalCustomers 
	@Visit INT
AS
BEGIN
	SELECT Customers.*, COUNT(Visits.VisitID) AS VisitCount FROM Customers
	JOIN Visits ON  Visits.CustomerID = Customers.CustomerID
	GROUP BY Customers.CustomerID, Customers.Name, Customers.Surname, Customers.Patronymic, Customers.Phone, Customers.Email
	Having COUNT(Visits.VisitID) >= @Visit
END;
GO

DECLARE @Visit INT
SET @Visit = 1
EXECUTE GetLoyalCustomers @Visit;
GO

DECLARE @Visit INT
SET @Visit = 1
EXECUTE GetLoyalCustomers @Visit;
GO

-- TASK 1.8
-- Тригер забороняє видалення єдиного Chief Barber
DROP TRIGGER IF EXISTS PreventChiefBarberDeletion
GO
CREATE TRIGGER PreventChiefBarberDeletion
ON Barbers
INSTEAD OF DELETE
AS
BEGIN
	IF EXISTS (
		SELECT 1 FROM deleted
		WHERE deleted.Position = 'Chief Barber' AND (SELECT COUNT(*) FROM Barbers WHERE Position = 'Chief Barber') <= 1
	)
	BEGIN
        PRINT 'Cannot delete the only Chief Barber. Please add another Chief Barber first'
    END
    ELSE
    BEGIN
        DELETE FROM Barbers WHERE BarberID IN (SELECT BarberID FROM deleted);
    END
END;
GO

-- TASK 1.9
-- Тригер перевіряє, чи барбер старший 21 року
DROP TRIGGER IF EXISTS CheckBarberAge
GO
CREATE TRIGGER CheckBarberAge
ON Barbers
AFTER INSERT, UPDATE
AS
BEGIN
	IF EXISTS (
		SELECT 1 FROM inserted
		WHERE DATEDIFF(YEAR, inserted.BirthDate, GETDATE()) < 21
	)
	BEGIN
        PRINT 'Barber must be at least 21 years old'
    END
END;
GO

-- TASK 2.1
-- Функція повертає привітання у форматі 'Hello, ІМ’Я!'
DROP FUNCTION IF EXISTS GreetUser
GO
CREATE FUNCTION GreetUser (@Name NVARCHAR(100))
RETURNS NVARCHAR(200)
AS
BEGIN
	RETURN 'Hello, ' + @Name + '!';
END;
Go

SELECT dbo.GreetUser('Nick');
GO

-- TASK 2.2
-- Функція повертає поточну кількість хвилин у годині
DROP FUNCTION IF EXISTS GetCurrentMinutes
GO
CREATE FUNCTION GetCurrentMinutes ()
RETURNS INT
AS
BEGIN
	RETURN DATEPART(MINUTE, GETDATE())
END;
Go

SELECT dbo.GetCurrentMinutes();
GO

-- TASK 2.3
-- Функція повертає поточний рік
DROP FUNCTION IF EXISTS GetCurrentYear
GO
CREATE FUNCTION GetCurrentYear ()
RETURNS INT
AS
BEGIN
	RETURN DATEPART(YEAR, GETDATE())
END;
Go

SELECT dbo.GetCurrentYear();
GO

-- TASK 2.4
-- Функція повертає, чи є поточний рік парним ('EVEN') чи непарним ('ODD')
DROP FUNCTION IF EXISTS IsCurrentYearEven
GO
CREATE FUNCTION IsCurrentYearEven ()
RETURNS NVARCHAR(10)
AS
BEGIN
	RETURN CASE WHEN DATEPART(YEAR, GETDATE()) % 2 = 0 THEN 'EVEN' ELSE 'ODD' END;
END;
Go

SELECT dbo.IsCurrentYearEven();
GO

-- TASK 2.5
-- Функція перевіряє, чи є число простим ('Yes' або 'No')
DROP FUNCTION IF EXISTS IsPrime
GO
CREATE FUNCTION IsPrime (@Number INT)
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @IsPrime NVARCHAR(3) = 'Yes';
    DECLARE @Divider INT = 2;

	IF @Number <= 1
        SET @IsPrime = 'No';
    ELSE
	BEGIN
		WHILE @Divider <= SQRT(@Number)
		BEGIN
			IF @Number % @Divider = 0
			BEGIN
				SET @IsPrime = 'No';
				BREAK
			END
			SET @Divider = @Divider + 1;
		END
	END

	RETURN @IsPrime;
END;
Go

SELECT dbo.IsPrime(5);
GO

-- TASK 2.6
-- Функція повертає суму мінімального та максимального значення з п’яти чисел
DROP FUNCTION IF EXISTS SumMinMax
GO
CREATE FUNCTION SumMinMax (@num1 INT, @num2 INT, @num3 INT, @num4 INT, @num5 INT)
RETURNS INT
AS 
BEGIN 
	DECLARE @MaxValue INT = @num1 , @MINValue INT = @num1 

	-- MAX
	IF @MaxValue < @num2 SET @MaxValue = @num2
	IF @MaxValue < @num3 SET @MaxValue = @num3
	IF @MaxValue < @num4 SET @MaxValue = @num4
	IF @MaxValue < @num5 SET @MaxValue = @num5

	-- MIN
	IF @MINValue > @num2 SET @MaxValue = @num2
	IF @MINValue > @num3 SET @MaxValue = @num3
	IF @MINValue > @num4 SET @MaxValue = @num4
	IF @MINValue > @num5 SET @MaxValue = @num5

	RETURN @MaxValue + @MINValue
END;
GO

SELECT dbo.SumMinMax(11, 22, 31, 52, 99);
GO

-- TASK 2.7
-- Функція повертає парні або непарні числа в заданому діапазоні
DROP FUNCTION IF EXISTS GetNumbersInRange
GO
CREATE FUNCTION GetNumbersInRange (@Start INT, @END INT, @IsEven BIT)
RETURNS @Result TABLE (Number INT)
AS 
BEGIN 
	DECLARE @Current INT = @Start
	
	WHILE @Current <= @END
	BEGIN
		IF(@IsEven = 1 AND @Current % 2 = 0) OR (@IsEven = 0 AND @Current % 2 = 1)
			INSERT INTO @Result (Number) VALUES (@Current)
		SET @Current = @Current + 1;
	END

	RETURN
END;
GO

SELECT Number FROM dbo.GetNumbersInRange(11, 22, 0);
GO

-- TASK 3.1
-- Процедура виводить повідомлення 'Hello World!'
DROP PROCEDURE IF EXISTS PrintHelloWorld
GO
CREATE PROCEDURE PrintHelloWorld 
AS 
BEGIN 
	SELECT 'Hello World!' AS Massage;
END;
GO

EXECUTE PrintHelloWorld
GO

-- TASK 3.2
-- Процедура повертає поточний час
DROP PROCEDURE IF EXISTS GetCurrentTime
GO
CREATE PROCEDURE GetCurrentTime 
AS 
BEGIN 
	SELECT CONVERT(time, GETDATE()) AS CurrentDate;
END;
GO

EXECUTE GetCurrentTime
GO

-- TASK 3.3
-- Процедура повертає поточну дату
DROP PROCEDURE IF EXISTS GetCurrentDate
GO
CREATE PROCEDURE GetCurrentDate 
AS 
BEGIN 
	SELECT CONVERT(date, GETDATE()) AS CurrentDate;
END;
GO

EXECUTE GetCurrentDate
GO

-- TASK 3.4
-- Процедура повертає суму трьох чисел
DROP PROCEDURE IF EXISTS SumThreeNumbers
GO
CREATE PROCEDURE SumThreeNumbers (@num1 INT, @num2 INT, @num3 INT)
AS 
BEGIN 
	SELECT @num1 + @num2 + @num3
END;
GO

EXECUTE SumThreeNumbers 11, 55, 234
GO

-- TASK 3.5
-- Процедура повертає середнє арифметичне трьох чисел
DROP PROCEDURE IF EXISTS AverageThreeNumbers
GO
CREATE PROCEDURE AverageThreeNumbers (@num1 INT, @num2 INT, @num3 INT)
AS 
BEGIN 
	SELECT (@num1 + @num2 + @num3) / 3
END;
GO

EXECUTE AverageThreeNumbers 11, 55, 234
GO

-- TASK 3.6
-- Процедура повертає максимальне значення з трьох чисел
DROP PROCEDURE IF EXISTS MaxThreeNumbers
GO
CREATE PROCEDURE MaxThreeNumbers (@num1 INT, @num2 INT, @num3 INT)
AS 
BEGIN 
	DECLARE @MaxValue INT = @num1

	IF @MaxValue < @num2 SET @MaxValue = @num2
	IF @MaxValue < @num3 SET @MaxValue = @num3

	SELECT @MaxValue
END;
GO

EXECUTE MaxThreeNumbers 11, 55, 234
GO

-- TASK 3.7
-- Процедура повертає мінімальне значення з трьох чисел
DROP PROCEDURE IF EXISTS MinThreeNumbers
GO
CREATE PROCEDURE MinThreeNumbers (@num1 INT, @num2 INT, @num3 INT)
AS 
BEGIN 
	DECLARE @MinValue INT = @num1

	IF @MinValue > @num2 SET @MinValue = @num2
	IF @MinValue > @num3 SET @MinValue = @num3

	SELECT @MinValue
END;
GO

EXECUTE MinThreeNumbers 11, 55, 234
GO

-- TASK 3.8
-- Процедура виводить лінію заданої довжини із заданого символу
DROP PROCEDURE IF EXISTS PrintLine
GO
CREATE PROCEDURE PrintLine (@num INT, @LineType NVARCHAR(10))
AS 
BEGIN 
	DECLARE @Result NVARCHAR(100) = '', @Counter INT = 0

	WHILE @Counter < @num
	BEGIN
		SET @Result = @Result + @LineType
		SET @Counter = @Counter + 1
	END

	SELECT @Result AS LINE
END;
GO

EXECUTE PrintLine 10, [-] 
GO

-- TASK 3.9
-- Процедура обчислює факторіал заданого числа
DROP PROCEDURE IF EXISTS CalculateFactorial
GO
CREATE PROCEDURE CalculateFactorial (@num INT)
AS 
BEGIN 
	DECLARE @Result INT = 1, @Counter INT = 1

	WHILE @Counter <= @num
	BEGIN
		SET @Result = @Result * @Counter
		SET @Counter = @Counter + 1
	END

	SELECT @Result AS Factorial
END;
GO

EXECUTE CalculateFactorial 5
GO

-- TASK 3.10
-- Процедура зводить число в заданий ступінь
DROP PROCEDURE IF EXISTS PowerNumber
GO
CREATE PROCEDURE PowerNumber (@num1 INT, @num2 INT)
AS 
BEGIN 
	DECLARE @Result INT = @num1, @Counter INT = 1

	WHILE @Counter < @num2
	BEGIN
		SET @Result = @Result * @num1
		SET @Counter = @Counter + 1
	END

	SELECT @Result AS Factorial
END;
GO

EXECUTE PowerNumber 5, 3
GO