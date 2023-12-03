CREATE PROCEDURE usp_GetTownsStartingWith @String NVARCHAR(10) AS
  SELECT [Name]  FROM Towns
  WHERE [Name] LIKE (@String + '%')

  EXEC dbo.usp_GetTownsStartingWith 'b'