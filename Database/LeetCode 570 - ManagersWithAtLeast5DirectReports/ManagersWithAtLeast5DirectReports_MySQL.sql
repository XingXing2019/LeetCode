SELECT t.Name FROM 
(SELECT e2.Name, COUNT(*) count
FROM employee e1 LEFT JOIN employee e2 
ON e1.ManagerId = e2.Id
GROUP BY e1.ManagerId) t
WHERE t.count >= 5 AND t.name IS NOT NULL;