SELECT e1.id, e1.month, ISNULL(e1.salary, 0) + ISNULL(e2.salary, 0) + ISNULL(e3.salary, 0) AS salary
FROM employee e1 
LEFT JOIN employee e2 ON e1.id = e2.id AND e1.month = e2.month + 1
LEFT JOIN employee e3 ON e2.id = e3.id AND e2.month = e3.month + 1
LEFT JOIN (SELECT id, MAX(month) AS month FROM employee GROUP BY id) t ON e1.id = t.id 
WHERE e1.month <> t.month
ORDER BY e1.id, month DESC