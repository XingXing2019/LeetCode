SELECT emp_id, dept
FROM (
	SELECT *, DENSE_RANK() OVER(PARTITION BY dept ORDER BY salary DESC) AS salary_rank
	FROM Employees
) AS t
WHERE salary_rank = 2
ORDER BY emp_id
