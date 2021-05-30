with salary as (select salary, 1 as dummy from employees group by salary having count(*) > 1),
teams as (select salary, row_number() over (partition by dummy order by salary) as team_id from salary)
select employee_id, name, e.salary, team_id
from teams t join employees e on t.salary = e.salary
order by team_id, employee_id