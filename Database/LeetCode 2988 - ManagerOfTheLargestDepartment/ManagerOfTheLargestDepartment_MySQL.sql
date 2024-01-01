with EmployeeCount as (
	select dep_id, count(emp_id) as emp_count
    from Employees group by dep_id
)

select e.emp_name as manager_name, e.dep_id
from EmployeeCount ec 
join Employees e on ec.dep_id = e.dep_id
where ec.emp_count = (
	select max(emp_count) from EmployeeCount
)
and e.position = 'Manager'
order by e.dep_id