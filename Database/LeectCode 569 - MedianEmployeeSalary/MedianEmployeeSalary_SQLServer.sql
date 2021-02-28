WITH salaryRank AS (SELECT *, RANK() OVER(PARTITION BY company ORDER BY salary) AS salaryRank FROM employee),
employeeRank AS (SELECT company, COUNT(*) AS counts FROM salaryRank GROUP BY company),
results AS (SELECT distinct s.id, e.company, s.salary FROM salaryRank s INNER JOIN employeeRank e ON s.company = e.company
WHERE s.salaryRank = FLOOR((e.counts + 1) / 2) OR s.salaryRank = FLOOR((e.counts + 2) / 2))
SELECT MIN(id) AS id, company, salary FROM results GROUP BY salary, company