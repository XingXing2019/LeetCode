WITH res AS (
	SELECT e.employee_id FROM Employees e LEFT JOIN Salaries s ON e.employee_id = s.employee_id WHERE s.salary IS NULL
	UNION ALL
	SELECT s.employee_id FROM Employees e RIGHT JOIN Salaries s ON e.employee_id = s.employee_id WHERE e.name IS NULL
)
SELECT * FROM res 
ORDER BY employee_id