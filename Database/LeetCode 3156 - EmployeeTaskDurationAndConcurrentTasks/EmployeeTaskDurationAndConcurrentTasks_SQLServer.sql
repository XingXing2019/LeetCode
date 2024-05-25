SELECT employee_id, SUM(task_hours) / 60 AS total_task_hours, MAX(concurrent_tasks) AS max_concurrent_tasks
FROM (
	SELECT t1.employee_id, 
    SUM(IIF(t1.task_id = t2.task_id, DATEDIFF(MINUTE, t1.start_time, t1.end_time), -DATEDIFF(MINUTE, t2.start_time, t1.end_time))) AS task_hours, 
    COUNT(t2.task_id) AS concurrent_tasks
    FROM Tasks t1
    JOIN Tasks t2
    ON t1.employee_id = t2.employee_id 
    AND t1.start_time <= t2.start_time 
    AND t2.start_time < t1.end_time
    GROUP BY t1.employee_id, t1.task_id
) AS t
GROUP BY employee_id
ORDER BY employee_id