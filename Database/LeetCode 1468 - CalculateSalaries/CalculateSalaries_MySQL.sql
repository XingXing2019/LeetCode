SELECT s1.company_id, s1.employee_id, s1.employee_name, (
	case when MAX < 1000 then round(s1.salary, 0)
	when MAX <= 10000 then round(s1.salary * 0.76, 0)
	ELSE round(s1.salary * 0.51, 0) END 
) AS salary FROM salaries s1 LEFT JOIN 
(SELECT s2.company_id, MAX(s2.salary) max
FROM salaries s2 GROUP BY s2.company_id) t1
ON s1.company_id = t1.company_id;