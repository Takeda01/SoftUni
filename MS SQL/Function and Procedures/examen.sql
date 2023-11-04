CREATE DATABASE Accounting

	CREATE TABLE Countries(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL


	)


	CREATE TABLE Addresses(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL


	)

	CREATE TABLE Vendors(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL


	)

	CREATE TABLE Clients(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL


	)

	CREATE TABLE Categories(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(10) NOT NULL,
	
	)

	CREATE TABLE Products(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL

	)

	CREATE TABLE Invoices(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Number INT UNIQUE NOT NULL,
	IssueDate DATETIME2 NOT NULL,
	DueDate DATETIME2 NOT NULL,
	Amount DECIMAL(18,2) NOT NULL,
	Currency VARCHAR(5) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL



	)

	CREATE TABLE ProductsClients(
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id)
	CONSTRAINT PK_ProductsClients PRIMARY KEY (ProductId,ClientId)
	)

	INSERT INTO Products([Name],Price,CategoryId,VendorId)
	 VALUES
	 ('SCANIA Oil Filter XD01',	78.69,	1,	1),
	 ('MAN Air Filter XD01',97.38,	1,	5),
	 ('DAF Light Bulb 05FG87',55.00,2,13),
	 ('ADR Shoes 47-47.5',49.85,3,5),
	 ('Anti-slip pads S',5.87,5,7)


	 INSERT INTO Invoices(Number, IssueDate, DueDate,Amount,Currency,ClientId)
	  VALUES
	  (1219992181,	'2023-03-01',	'2023-04-30'	,180.96	,'BGN',	3),
	  (1729252340,	'2022-11-06',	'2023-01-04'	,158.18	,'EUR',	13),
	  (1950101013,	'2023-02-17',	'2023-04-18'	,615.15	,'USD',	19)


	  UPDATE Invoices
	  SET DueDate = '2023-04-01'
	  WHERE IssueDate BETWEEN '2022-11-01' AND '2022-11-30'
	
	  UPDATE Clients
	  SET AddressId = 3 
	  WHERE [Name] LIKE '%CO%'
	 

	   DELETE FROM Invoices WHERE ClientId = 11
	   DELETE FROM ProductsClients WHERE ClientId = 11
	   DELETE FROM Clients WHERE NumberVAT LIKE 'IT%'
	   

	   SELECT Number, Currency FROM Invoices
	   ORDER BY Amount DESC , DueDate ASC

	   SELECT 	p.Id,	p.Name,	Price,	c.Name FROM Products AS p JOIN Categories AS c on CategoryId = c.Id
	   WHERE c.Name = 'Others' OR c.Name = 'ADR'
	   ORDER BY Price DESC


	   SELECT c.Id,c.[Name] AS Client, CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode,', ', cu.[Name]  ) AS [Address]
	   FROM Clients AS c 
	   JOIN Addresses AS a ON a.Id = c.AddressId
	   JOIN Countries AS cu ON cu.Id =CountryId
	   LEFT JOIN ProductsClients AS pc ON pc.ClientId = c.Id
	   WHERE pc.ProductId IS NULL
	   ORDER BY c.[Name] ASC

	