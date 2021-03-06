WITH teamSize AS (SELECT COUNT(*) AS team_size, team_id FROM employee GROUP BY team_id)
SELECT e.employee_id, team_size FROM employee e LEFT JOIN teamSize t ON e.team_id = t.team_id