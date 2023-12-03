CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown @Town NVARCHAR(60) AS
  SELECT  FirstName, LastName FROM Employees AS e JOIN Addresses AS a ON e.AddressID = a.AddressID JOIN
  Towns AS t ON a.TownID = t.TownID
  WHERE t.Name = @Town
   EXEC dbo.usp_GetEmployeesFromTown 'sofia'

 