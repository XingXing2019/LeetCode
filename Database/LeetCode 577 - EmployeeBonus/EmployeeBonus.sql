SELECT e.Name, b.Bonus
FROM employee e LEFT JOIN bonus b
ON e.EmpId = b.EmpId
WHERE b.Bonus < 1000 OR b.Bonus IS NULL;