SELECT e1.employee_id, COUNT(e1.employee_id) AS overlapping_shifts
FROM EmployeeShifts e1
LEFT JOIN EmployeeShifts e2 
ON e1.end_time > e2.start_time 
AND e1.start_time < e2.start_time
AND e1.employee_id = e2.employee_id
AND e1.start_time <> e2.start_time
WHERE e2.employee_id IS NOT NULL
GROUP BY e1.employee_id