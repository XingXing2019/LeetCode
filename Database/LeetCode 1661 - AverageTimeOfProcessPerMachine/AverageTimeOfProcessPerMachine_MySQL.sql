SELECT t1.machine_id, ROUND(AVG(t1.timestamp - t2.timestamp), 3) AS processing_time FROM 
(SELECT * FROM activity
WHERE activity_type = 'end'
GROUP BY  machine_id, process_id) t1
JOIN 
(SELECT * FROM activity
WHERE activity_type = 'start'
GROUP BY  machine_id, process_id) t2
ON t1.machine_id = t2.machine_id AND t1.process_id = t2.process_id
GROUP BY machine_id;
