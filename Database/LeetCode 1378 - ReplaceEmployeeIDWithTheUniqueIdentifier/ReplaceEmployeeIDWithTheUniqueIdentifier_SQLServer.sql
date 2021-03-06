SELECT e2.unique_id, e1.name FROM employees e1 LEFT JOIN employeeUNI e2
ON e1.id = e2.id