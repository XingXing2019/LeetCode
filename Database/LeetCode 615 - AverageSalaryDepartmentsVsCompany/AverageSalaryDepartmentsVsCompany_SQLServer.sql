WITH department AS (SELECT LEFT(pay_date, 7) AS month, department_id, amount FROM salary s LEFT JOIN employee e ON s.employee_id = e.employee_id),
avgAmount AS (SELECT month, department_id, AVG(amount) avgAmount FROM department GROUP BY month, department_id),
companyAvg AS (SELECT month, AVG(amount) companyAvg FROM department GROUP BY month)

SELECT a.month AS pay_month, a.department_id, 
CASE WHEN avgAmount = companyAvg THEN 'same' 
WHEN avgAmount > companyAvg THEN 'higher'
ELSE 'lower' END AS comparison
FROM avgAmount a LEFT JOIN companyAvg c ON a.month = c.month