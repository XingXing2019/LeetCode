with recursive Hierarchy as (
    select *, 0 as hierarchy_level  
    from Employees
    where manager_id is null
    union all
    select e.*, h.hierarchy_level + 1
    from Hierarchy h
    join Employees e on e.manager_id = h.employee_id    
)

select
    h1.employee_id as subordinate_id,
    h1.employee_name as subordinate_name,
    h1.hierarchy_level,
    (h1.salary - h2.salary) as salary_difference
from Hierarchy h1
join Hierarchy h2 on h2.manager_id is null
where h1.manager_id is not null 
order by h1.hierarchy_level, h1.employee_id
