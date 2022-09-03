with LoginTime AS (
	select employee_id, ceiling(sum(timestampdiff(second, in_time, out_time)) / 60) as login_time
	from Logs
	group by employee_id
)

select e.employee_id
from Employees e
left join LoginTime l
on e.employee_id = l.employee_id
where needed_hours * 60 > ifnull(l.login_time, 0)