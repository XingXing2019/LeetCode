select employee_id, floor(sum(task_hour) / 60) as total_task_hours, max(concurrent_tasks) as max_concurrent_tasks 
from (
	select t1.employee_id, sum(
		case
			when t1.task_id = t2.task_id then timestampdiff(minute, t1.start_time, t1.end_time)
			else timestampdiff(minute, t1.end_time, t2.start_time)
		end
	) as task_hour, count(t2.task_id) as concurrent_tasks
	from Tasks t1
	join Tasks t2
	on t1.employee_id = t2.employee_id
	and t1.start_time <= t2.start_time
	and t2.start_time < t1.end_time
	group by t1.employee_id, t1.task_id
) as t
group by employee_id