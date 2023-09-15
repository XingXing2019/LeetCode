with DepartmentMax as (
	select max(salary) as salary, department from salaries group by department
)

select abs(d1.salary - d2.salary) as salary_difference
from DepartmentMax d1 
join DepartmentMax d2
on d1.department <> d2.department
where d1.department = 'Marketing'
and d2.department = 'Engineering'
