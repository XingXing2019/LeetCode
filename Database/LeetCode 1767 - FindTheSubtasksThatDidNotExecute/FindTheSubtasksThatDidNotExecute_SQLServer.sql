WITH recursion AS (SELECT task_id, 1 AS subtask_id , subtasks_count FROM tasks
UNION ALL
SELECT task_id, subtask_id  + 1 as subTask, subtasks_count FROM recursion 
WHERE subtask_id  + 1 <= subtasks_count	
)
SELECT r.task_id, r.subtask_id  FROM recursion r 
LEFT JOIN executed e ON r.task_id = e.task_id AND r.subtask_id  = e.subtask_id 
WHERE e.subtask_id IS NULL