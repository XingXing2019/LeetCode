WITH Junior AS (
	SELECT *, SUM(salary) OVER(PARTITION BY experience ORDER BY salary) AS sum_salary 
	FROM Candidates
	WHERE experience = 'junior'
),

Senior AS (
	SELECT *, SUM(salary) OVER(PARTITION BY experience ORDER BY salary) AS sum_salary 
	FROM Candidates
	WHERE experience = 'senior'
)

SELECT employee_id FROM Senior 
WHERE sum_salary <= 70000
UNION ALL
SELECT employee_id FROM Junior 
WHERE sum_salary <= 70000 - ISNULL((SELECT MAX(sum_salary) FROM Senior WHERE sum_salary <= 70000), 0)