SELECT p1.project_id, e1.employee_id 
FROM project p1 JOIN employee e1 ON p1.employee_id = e1.employee_id 
WHERE (p1.project_id, e1.experience_years) IN
(SELECT p2.project_id, MAX(e2.experience_years) max FROM 
project p2 JOIN employee e2
ON p2.employee_id = e2.employee_id
GROUP BY p2.project_id);