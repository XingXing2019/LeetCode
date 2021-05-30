WITH Salary AS (SELECT salary, 1 AS Dummy FROM Employees GROUP BY salary HAVING COUNT(*) > 1),
Teams AS (SELECT salary, ROW_NUMBER() OVER (PARTITION BY Dummy ORDER BY salary) AS team_id FROM Salary)

SELECT employee_id, name, t.salary, team_id
FROM Teams t JOIN Employees e ON t.salary = e.salary
ORDER BY team_id, employee_id