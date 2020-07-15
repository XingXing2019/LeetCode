SELECT d.Name AS department, e1.Name AS employee, e1.Salary
FROM employee e1 INNER JOIN department d
ON e1.DepartmentId = d.Id
WHERE 3 > (SELECT
            COUNT(DISTINCT e2.Salary)
        		FROM
            	Employee e2
        		WHERE
            	e2.Salary > e1.Salary
               AND e1.DepartmentId = e2.DepartmentId
        );