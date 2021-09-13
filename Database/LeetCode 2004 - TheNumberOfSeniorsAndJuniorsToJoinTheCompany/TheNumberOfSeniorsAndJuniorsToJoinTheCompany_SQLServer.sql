WITH Junior AS (
	SELECT *, SUM(salary) OVER(PARTITION BY experience ORDER BY salary, employee_id) AS SumSalary 
	FROM Candidates WHERE experience = 'Junior' 
),
Senior AS (
	SELECT *, SUM(salary) OVER(PARTITION BY experience ORDER BY salary, employee_id) AS SumSalary 
	FROM Candidates WHERE experience = 'Senior' 
)
SELECT 'Senior' AS experience, COUNT(*) AS accepted_candidates 
FROM Senior 
WHERE SumSalary <= 70000 
UNION ALL
SELECT 'Junior' AS experience, COUNT(*) AS accepted_candidates
FROM Junior 
WHERE SumSalary <= 70000 - ISNULL((SELECT MAX(SumSalary) FROM Senior WHERE SumSalary <= 70000), 0)
