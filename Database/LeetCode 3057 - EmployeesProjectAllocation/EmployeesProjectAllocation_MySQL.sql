with EmployeeProject as (
	select p.*, e.name, e.team from Project p
	join Employees e on p.employee_id = e.employee_id
),

TeamWorkload as (
	select team, sum(workload) / count(*) as team_workload from EmployeeProject
	group by team
),

EmployeeWorkload as (
	select project_id, team, employee_id, name, workload
	from EmployeeProject
)

select employee_id, project_id, name AS employee_name, workload AS project_workload
from TeamWorkload t
join EmployeeWorkload e ON t.team = e.team
where workload > team_workload
order by employee_id, project_id
