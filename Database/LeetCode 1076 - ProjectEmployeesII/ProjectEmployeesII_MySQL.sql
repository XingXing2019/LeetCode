SELECT p1.project_id
FROM project p1 LEFT JOIN employee e1 
ON p1.employee_id = e1.employee_id
GROUP BY p1.project_id
HAVING COUNT(*) = (
	SELECT COUNT(*)
	FROM project p2 LEFT JOIN employee e2
	ON p2.employee_id = e2.employee_id
	GROUP BY p2.project_id 
	ORDER BY COUNT(*) DESC 
	LIMIT 1
);
