with SessionTime as (
	select session_status, status_time as start_time,
	lead(status_time, 1) over(partition by server_id order by status_time) as end_time
	from Servers
)

select floor(sum(timestampdiff(second, start_time, end_time)) / 24 / 60 / 60) as total_uptime_days 
from SessionTime
where session_status = 'start'