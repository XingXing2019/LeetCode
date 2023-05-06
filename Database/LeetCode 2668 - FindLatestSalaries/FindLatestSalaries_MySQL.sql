select emp_id, firstname, lastname, max(salary) as salary, department_id
from salary
group by emp_id, firstname, lastname, department_id
order by emp_id