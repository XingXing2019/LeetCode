select emp_id, dept
from (
	select *, dense_rank() over(partition by dept order by salary desc) as salary_rank
	from Employees
) as t
where salary_rank = 2
order by emp_id