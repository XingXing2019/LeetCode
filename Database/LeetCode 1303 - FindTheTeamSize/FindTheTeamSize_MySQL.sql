SELECT e.employee_id, team_size
FROM employee e LEFT JOIN (
	SELECT COUNT(*) team_size, team_id
	FROM employee 
	GROUP BY team_id
) AS t
ON e.team_id = t.team_id;
