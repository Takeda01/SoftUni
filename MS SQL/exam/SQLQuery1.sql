CREATE DATABASE TouristAgency
USE TouristAgency

CREATE TABLE Countries (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL

)

CREATE TABLE Destinations(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL

)


CREATE TABLE Rooms(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(40) NOT NULL,
Price DECIMAL(18,2) NOT NULL,
BedCount INT NOT NULL
CHECK (BedCount >= 1 AND BedCount <= 10)


)

CREATE TABLE Hotels(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL

)
CREATE TABLE Tourists(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(80) NOT NULL,
PhoneNumber VARCHAR(20) NOT NULL,
Email VARCHAR(80),
CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL,

)


CREATE TABLE Bookings(
Id INT PRIMARY KEY IDENTITY,
ArrivalDate DATETIME2 NOT NULL,
DepartureDate DATETIME2 NOT NULL,
AdultsCount INT NOT NULL
CHECK (AdultsCount >= 1 AND AdultsCount <= 10),
ChildrenCount INT NOT NULL
CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9),
TouristId INT FOREIGN KEY REFERENCES Tourists(Id),
HotelId INT FOREIGN KEY REFERENCES Hotels(Id),
RoomId INT FOREIGN KEY REFERENCES Rooms(Id)
)
 
 CREATE TABLE HotelsRooms(
 HotelId INT FOREIGN KEY REFERENCES Hotels(Id),
 RoomId INT FOREIGN KEY REFERENCES Rooms(Id)
 CONSTRAINT PK_HotelsRooms PRIMARY KEY (HotelId,RoomId)
 
 )



 INSERT INTO Tourists([Name], PhoneNumber, Email, CountryId)
 VALUES
 ('John Rivers',	'653-551-1555',	'john.rivers@example.com',	6),
 ('Adeline Aglaé',	'122-654-8726',	'adeline.aglae@example.com', 2),
 ('Sergio Ramirez',	'233-465-2876',	's.ramirez@example.com',	3),
  ('Johan Müller',	'322-876-9826',	'j.muller@example.com', 7),
  ('Eden Smith',	'551-874-2234',	'eden.smith@example.com',6)

  

INSERT INTO Bookings(ArrivalDate,DepartureDate,AdultsCount,ChildrenCount,TouristId,HotelId,RoomId)
VALUES
('2024-03-01',	'2024-03-11',	1,	0,	21,	3	,5),
('2023-12-28',	'2024-01-06',	2,	1,	22,	13	,3),
('2023-11-15',	'2023-11-20',	1,	2,	23,	19	,7),
('2023-12-05',	'2023-12-09',	4,	0,	24,	6	,4),
('2024-05-01',	'2024-05-07',	6,	0,	25,	14	,6)

UPDATE Bookings
SET DepartureDate = DATEADD(day, 1, DepartureDate)
WHERE YEAR(ArrivalDate) = 2023 AND MONTH(ArrivalDate) = 12;

UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE '%MA%'

DELETE FROM Bookings
WHERE TouristId IN (
    SELECT TouristId
    FROM Tourists
    WHERE Name LIKE '%Smith%'
)


DELETE FROM Tourists
WHERE Name LIKE '%Smith%'

SELECT FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate, AdultsCount, ChildrenCount FROM Bookings AS b JOIN Rooms as r ON RoomId = r.Id
ORDER BY r.Price DESC, ArrivalDate ASC

--SELECT h.Id, [Name] FROM Hotels AS h JOIN Bookings AS b
--ORDER BY 

SELECT T.Id, T.Name, T.PhoneNumber
FROM Tourists AS T
LEFT JOIN Bookings AS B ON T.Id = B.TouristId
WHERE B.Id IS NULL
ORDER BY T.[Name] ASC

SELECT TOP (10) h.[Name] AS HotelName,d.[Name] AS DestinationName,c.[Name] AS CountryName
FROM Bookings AS b JOIN Hotels AS h ON h.Id = b.HotelId JOIN Destinations AS d ON h.DestinationId = d.Id  JOIN Countries AS c ON d.CountryId = c.Id
WHERE b.ArrivalDate < '2023-12-31' AND (h.Id % 2) =1
ORDER BY c.[Name] ASC, b.ArrivalDate ASC


SELECT h.[Name] AS HotelName, r.Price AS RoomPrice FROM Tourists AS t JOIN Bookings as b ON b.TouristId = t.Id JOIN Hotels AS h ON h.Id = b.HotelId JOIN Rooms AS r ON r.Id = b.RoomId
WHERE T.[Name] NOT LIKE '%EZ'
ORDER BY r.Price DESC

SELECT
    h.[Name] AS HotelName,
    SUM(r.Price * DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate)) AS TotalRevenue
FROM
    Hotels AS h
JOIN
    Destinations AS d ON h.DestinationId = d.Id
JOIN
    Bookings AS b ON h.Id = b.HotelId
JOIN
    Rooms AS r ON b.RoomId = r.Id
GROUP BY
    h.[Name]
ORDER BY
    TotalRevenue DESC;


	CREATE FUNCTION udf_RoomsWithTourists (@name VARCHAR(40))
RETURNS INT
AS
BEGIN
    DECLARE @TotalTourists INT;

    SELECT @TotalTourists = SUM(b.AdultsCount + b.ChildrenCount)
    FROM Rooms AS r
    LEFT JOIN Bookings AS b ON r.Id = b.RoomId
    WHERE r.[Type] = @name;

    RETURN @TotalTourists;
END;

CREATE PROCEDURE usp_SearchByCountry
    @country NVARCHAR(50)
AS
BEGIN
    SELECT
        t.Name,
        t.PhoneNumber,
        t.Email,
        COUNT(b.Id) AS CountOfBookings
    FROM
        Tourists AS t
    INNER JOIN
        Countries AS c ON t.CountryId = c.Id
    LEFT JOIN
        Bookings AS b ON t.Id = b.TouristId
    WHERE
        c.[Name] = @country
    GROUP BY
        t.Name, t.PhoneNumber, t.Email
    ORDER BY
        t.Name ASC, CountOfBookings DESC;
END;

SELECT h.Id, h.[Name]
FROM Hotels AS h
LEFT JOIN Bookings AS b ON h.Id = b.HotelId
LEFT JOIN Rooms AS r ON b.RoomId = r.Id
WHERE r.[Type] = 'VIP Apartment'
GROUP BY h.Id, h.[Name]
ORDER BY COUNT(b.Id) DESC;