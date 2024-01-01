WITH EmployeeCount AS (
	SELECT dep_id, COUNT(emp_id) AS emp_count
	FROM Employees GROUP BY dep_id
)

SELECT emp_name AS manager_name, e.dep_id
FROM EmployeeCount ec
JOIN Employees e ON ec.dep_id = e.dep_id
WHERE emp_count = (
	SELECT MAX(emp_count) FROM EmployeeCount
)
AND position = 'Manager'
ORDER BY dep_id