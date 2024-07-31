WITH Hierarchy AS (
	SELECT e.*, 0 AS hierarchy_level 
	FROM Employees e
	WHERE manager_id IS NULL
	UNION ALL
	SELECT e.*, hierarchy_level + 1 
	FROM Hierarchy h
	JOIN Employees e ON h.employee_id = e.manager_id
)

SELECT 
	h1.employee_id AS subordinate_id,
	h1.employee_name AS subordinate_name,
	h1.hierarchy_level,
	(h1.salary - h2.salary) AS salary_difference 
FROM Hierarchy h1
LEFT JOIN Hierarchy h2 ON h2.manager_id IS NULL
WHERE h1.manager_id IS NOT NULL
ORDER BY h1.hierarchy_level, h1.employee_id