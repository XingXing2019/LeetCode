with recursive recursion as (select task_id, 1 as subtask_id, subtasks_count from tasks
union all 
select task_id, subtask_id + 1 as subtask_id, subtasks_count from recursion
where subtask_id + 1 <= subtasks_count
)
select r.task_id, r.subtask_id from recursion r left join executed e 
on r.task_id = e.task_id and r.subtask_id = e.subtask_id
where e.subtask_id is null