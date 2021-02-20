CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        SELECT DISTINCT salary FROM (SELECT *, DENSE_RANK() OVER(ORDER BY salary DESC) AS salaryRank FROM employee) AS t 
		WHERE salaryRank = @N      
    );
END