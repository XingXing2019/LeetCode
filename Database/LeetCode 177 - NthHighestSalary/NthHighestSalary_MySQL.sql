CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  RETURN (
	with salaryRank as (select *, dense_rank() over(order by salary desc) as salaryRank from employee)
	select distinct salary from salaryRank where salaryRank = N      
  );
END