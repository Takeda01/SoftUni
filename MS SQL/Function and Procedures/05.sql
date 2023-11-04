CREATE  FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
  RETURNS NVARCHAR(20)
   BEGIN
   IF @salary < 30000
   RETURN 'Low'

   IF @salary >= 30000 AND @salary <=  50000 
   RETURN 'Average'

  
   RETURN 'High'

   END