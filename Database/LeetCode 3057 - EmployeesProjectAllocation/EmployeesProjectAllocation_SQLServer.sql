WITH TeamWorkload AS (
	SELECT team, CONVERT(FLOAT, SUM(workload)) / COUNT(p.employee_id) AS team_workload
	FROM Project p
	JOIN Employees e ON p.employee_id = e.employee_id
	GROUP BY team
),

EmployeeWorkload AS (
	SELECT team, e.employee_id, name, project_id, workload
	FROM Employees e
	JOIN Project p ON e.employee_id = p.employee_id
)

SELECT employee_id, project_id, name AS employee_name, workload AS project_workload
FROM TeamWorkload t
JOIN EmployeeWorkload e ON t.team = e.team
WHERE e.workload > team_workload
ORDER BY employee_id, project_id