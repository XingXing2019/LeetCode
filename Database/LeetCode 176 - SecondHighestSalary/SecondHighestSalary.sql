SELECT MAX(Salary) AS SecondHighestSalary 
FROM Employee 
WHERE salary < (
	SELECT MAX(salary) FROM Employee
);